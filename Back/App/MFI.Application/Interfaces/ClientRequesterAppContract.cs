using MFI.Domain.Entities;

namespace MFI.Application.Interfaces
{
    public interface ClientRequesterAppContract
    {
        ClientRequester Create(
            string name, 
            string email, 
            string password);
    }
}