using MFI.Application.Base;
using MFI.Application.ViewModels.Clients.Requesters;

namespace MFI.Application.Interfaces
{
    public interface ClientRequesterAppContract
    {
        MFIResult Create(
            CreateClientRequester client);

        MFIResult Login(
            string email,
            string password);
    }
}