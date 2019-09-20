using MFI.Application.ViewModels.Clients.Requesters;

namespace MFI.Application.Interfaces
{
    public interface ClientRequesterAppContract
    {
        CreatedClientRequester Create(
            CreateClientRequester client);
    }
}