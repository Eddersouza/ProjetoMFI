using MFI.Application.ViewModels.Clients.Providers;

namespace MFI.Application.Interfaces
{
    public interface ServiceAppContract
    {
        ServiceProviderListView GetServicesProvider(string providerId);
    }
}