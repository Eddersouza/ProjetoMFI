using MFI.Application.ViewModels.Clients.Providers;

namespace MFI.Application.Interfaces
{
    public interface ProviderServiceAppContract
    {
        bool Add(
            ServiceProviderItemView serviceProvider);

        bool Remove(
            int serviceId,
            string providerId);
    }
}