using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Requesters;
using MFI.Domain.Contracts.Repositories.Base;
using MFI.Domain.Entities;
using MFI.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MFI.Application
{
    public class UserApp : UserAppContract
    {
        private readonly UnityOfWorkContract _unityOfWork;

        public UserApp(
            UnityOfWorkContract unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public MFIResult Login(
           string email,
           string password,
           ClientType? type)
        {
            LoginRequester loginRequester = new LoginRequester();
            List<string> warnings = new List<string>();

            if (string.IsNullOrEmpty(email))
                loginRequester.AddWarning("Campo Email obrigatório.");

            if (string.IsNullOrEmpty(password))
                loginRequester.AddWarning("Campo Senha obrigatório.");

            if (!loginRequester.HasSuccess)
                return loginRequester;

            Client client = null;
            switch (type)
            {
                case ClientType.Requester:
                    client = _unityOfWork.ClientRequester.Get(user => user.Email == email).FirstOrDefault();
                    break;

                case ClientType.Provider:
                    client = _unityOfWork.ClientProvider.Get(user => user.Email == email).FirstOrDefault();
                    break;

                default:
                    client = _unityOfWork.ClientRequester.Get(user => user.Email == email).FirstOrDefault();

                    if (client == null)
                        client = _unityOfWork.ClientProvider.Get(user => user.Email == email).FirstOrDefault();
                    break;
            }

            if (client != null)
            {
                User loginClient = null;
                loginClient = new User { Email = email, Password = password, UserId = client.User.UserId };
                loginClient.EncriptPassword();

                if (client.User.Password == loginClient.Password)
                    loginRequester.User = new SystemUser
                    {
                        UserEmail = client.Email,
                        UserName = client.Name,
                        UserId = client.ClientId.ToString(),
                        Roles = new string[] { client.Type.ToString() },
                        ClientType = client.Type
                    };
                else
                    loginRequester.Warnings.Add("Usuário ou Senha Inválidos.");
            }
            else
            {
                loginRequester.Warnings.Add("Usuário ou Senha Inválidos.");
            }

            return loginRequester;
        }
    }
}