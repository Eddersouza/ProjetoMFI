using edrsys.Utils.extensions;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Providers;
using MFI.Domain.Contracts.Repositories;
using MFI.Domain.Contracts.Repositories.Base;
using MFI.Domain.Entities;
using System;

namespace MFI.Application
{
    public class ProviderServiceApp : ProviderServiceAppContract
    {
        private readonly UnityOfWorkContract _unityOfWork;

        public ProviderServiceApp(
            UnityOfWorkContract unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public bool Add(
            ServiceProviderItemView serviceProvider)
        {
            ProviderService providerService = new ProviderService()
            {
                ClientId = Guid.Parse(serviceProvider.ClientId),
                CreateDate = DateTime.Now,
                CreatedByUserId = serviceProvider.ClientId,
                MinimunAmount = serviceProvider.MinimalAmountText.ToDecimal(),
                ServiceId = serviceProvider.ServiceId
            };

            _unityOfWork.ProviderService.Create(providerService);
            _unityOfWork.SaveChanges();

            return true;
        }

        public bool Remove(
            int serviceId, 
            string providerId)
        {
            Guid clientId = Guid.Parse(providerId);

            _unityOfWork.ProviderService.Delete(new object[] { clientId, serviceId });
            _unityOfWork.SaveChanges();
            return true;
        }
    }
}