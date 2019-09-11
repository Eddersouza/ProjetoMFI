using MFI.Application.Interfaces;
using MFI.Domain.Entities;

namespace MFI.Application
{
    public class ClientRequesterApp : ClientRequesterAppContract
    {
        public ClientRequester Create(
            string name,
            string email,
            string password)
        {
            User user = new User(email, password);

            ClientRequester requester =
                new ClientRequester(email, name, user);

            return requester;
        }
    }
}