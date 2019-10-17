using MFI.Domain.Entities;

namespace MFI.Application.ViewModels.Clients.Providers
{
    public class CardProviderView
    {
        public CardProviderView(ClientProvider item)
        {
            this.CompanyName = item.CompanyName;
            this.Description = item.Description;
            this.Name = item.Name;
        }

        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}