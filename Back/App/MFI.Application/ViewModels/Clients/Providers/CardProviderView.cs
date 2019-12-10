using MFI.Domain.Entities;
using System.Collections.Generic;

namespace MFI.Application.ViewModels.Clients.Providers
{
    public class CardProviderView
    {
        public CardProviderView(ClientProvider item)
        {
            this.CompanyName = item.CompanyName;
            this.Description = item.Description;
            this.Name = item.Name;

            services = new List<ServiceProviderItemView>();

            foreach (var service in item.ProviderServices)
            {
                services.Add(new ServiceProviderItemView(
                    service.ClientId.ToString(),
                    service.ServiceId,
                    service.Service.Name,
                    service.Service.Description,
                    service.MinimunAmount));
            }
        }

        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public List<ServiceProviderItemView> services { get; set; }
    }
}