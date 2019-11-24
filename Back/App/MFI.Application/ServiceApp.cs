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
            IEnumerable<Service> services = _unityOfWork.Service.Get();

            foreach (var service in services)
            {
                serviceProviders.Add(new ServiceProviderItemView(
                    service.Description,
                    service.Name,
                    service.ServiceId));
            }

            serviceProvidersList.Items = serviceProviders;

            return serviceProvidersList;
        }
    }
}