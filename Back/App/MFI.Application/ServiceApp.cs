using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Providers;
using MFI.Domain.Contracts.Repositories.Base;
using MFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MFI.Application
{
    public class ServiceApp : ServiceAppContract
    {
        private readonly UnityOfWorkContract _unityOfWork;

        public ServiceApp(
            UnityOfWorkContract unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public ServiceProviderListView GetServicesProvider(string providerId)
        {
            ServiceProviderListView serviceProvidersList = new ServiceProviderListView();
            List<ServiceProviderItemView> serviceProviders = new List<ServiceProviderItemView>();
            Guid clientId = Guid.Parse(providerId);

            IEnumerable<Service> services = _unityOfWork.Service.Get();
            IEnumerable<ProviderService> providerServices =
                _unityOfWork.ProviderService
                .Get(providerService => providerService.ClientId == clientId).ToList();

            string createdBy = string.Empty;

            foreach (var service in services)
            {
                var providerServiceView = new ServiceProviderItemView(
                    service.Description,
                    service.Name,
                    service.ServiceId,
                    providerId);

                var providerServiceItem = providerServices.FirstOrDefault(providerService => providerService.ServiceId == service.ServiceId);

                providerServiceView.MinimalAmountText = (providerServiceItem?.MinimunAmount ?? 0).ToString("N2");
                providerServiceView.Active = providerServiceItem != null;

                serviceProviders.Add(providerServiceView);
            }

            serviceProvidersList.Items = serviceProviders;

            return serviceProvidersList;
        }
    }
}