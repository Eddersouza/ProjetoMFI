using MFI.Application.Interfaces;
using MFI.Domain.Contracts.Repositories;
using MFI.Domain.Contracts.Repositories.Base;
using MFI.Domain.Entities;

namespace MFI.Application
{
    public class ClientRequesterApp : ClientRequesterAppContract
    {
        private readonly UserRepositoryContract _userRepository;

        private readonly UnityOfWorkContract _unityOfWork;

        public ClientRequesterApp(
            UserRepositoryContract userRepository,
            UnityOfWorkContract unityOfWork)
        {
            this._userRepository = userRepository;
            this._unityOfWork = unityOfWork;
        }

        public ClientRequester Create(
            string name,
            string email,
            string password)
        {
            User user = new User(email, password);

            this._userRepository.Create(user);
            this._unityOfWork.SaveChanges();

            ClientRequester requester =
                new ClientRequester(email, name, user);

            return requester;
        }
    }
}