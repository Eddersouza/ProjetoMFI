using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Requesters;
using MFI.Domain.Contracts.Repositories.Base;
using MFI.Domain.Entities;
using MFI.Domain.Enums;
using System.Linq;

namespace MFI.Application
{
    public class ClientRequesterApp : ClientRequesterAppContract
    {
        private readonly UnityOfWorkContract _unityOfWork;

        public ClientRequesterApp(
            UnityOfWorkContract unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public CreatedClientRequester Create(
           CreateClientRequester client)
        {
            CreatedClientRequester createdClient = null;

            bool requesterExists =
                this._unityOfWork.ClientRequester
                    .Get(cli => cli.Email == client.Email)
                    .FirstOrDefault(cli => cli.Type.Equals(ClientType.Requester)) != null;

            
            if (requesterExists)
            {
                createdClient = new CreatedClientRequester
                {
                    Email = client?.Email,
                    Id = string.Empty,
                    Name = client?.Name
                };

                createdClient.AddWarning("Cliente Já Existente.");
            }
            else
            {
                User user = new User(client.Email, client.Password);

                ClientRequester requester =
                    new ClientRequester(client.Email, client.Name, user);

                this._unityOfWork.ClientRequester.Create(requester);
                this._unityOfWork.SaveChanges();

                createdClient = new CreatedClientRequester
                {
                    Email = requester?.Email,
                    Id = requester.ClientId.ToString(),
                    Name = requester?.Name
                };
            }




            return createdClient;
        }
    }
}