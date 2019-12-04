using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Providers;
using MFI.Domain.Contracts.Repositories;
using MFI.Domain.Entities;
using System;

namespace MFI.Application
{
    public class ProviderServiceApp : ProviderServiceAppContract
    {
        private readonly ProviderServiceRepositoryContract _providerServiceRepository;
        public ProviderServiceApp(
            ProviderServiceRepositoryContract providerServiceRepository)
        {
            _providerServiceRepository = providerServiceRepository;
        }

        public bool Add(
            ServiceProviderItemView serviceProvider)
        {
            ProviderService providerService = new ProviderService()
            {
                ClientId = new Guid(serviceProvider.ClientId),
                CreateDate = DateTime.Now,
                CreatedByUserId = serviceProvider.ClientId,
                MinimunAmount = serviceProvider.MinimalAmount,
                ServiceId = serviceProvider.ServiceId
            };

            _providerServiceRepository.Create(providerService);
            return true;
        }

        public bool Remove(int id)
        {
            _providerServiceRepository.Delete(new object[] { id });
            return true;
        }
    }
}