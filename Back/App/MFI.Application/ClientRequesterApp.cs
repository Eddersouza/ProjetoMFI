using MFI.Application.Interfaces;
using MFI.Domain.Contracts.Repositories.Base;
using MFI.Domain.Entities;

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

        public ClientRequester Create(
            string name,
            string email,
            string password)
        {
            User user = new User(email, password);

            ClientRequester requester =
                new ClientRequester(email, name, user);

            this._unityOfWork.ClientRequester.Create(requester);
            this._unityOfWork.SaveChanges();

            return requester;
        }
    }
}