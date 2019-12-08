namespace MFI.Application.ViewModels.Clients.Providers
{
    public class ServiceProviderItemView
    {
        public ServiceProviderItemView()
        {
        }

        public ServiceProviderItemView(
            string description,
            string name,
            int serviceId,
            string clientId)
        {
            Description = description;
            Name = name;
            ServiceId = serviceId;
            ClientId = clientId;
        }

        public bool Active { get; set; }
        public string ClientId { get; set; }
        public string Description { get; set; }
        public decimal MinimalAmount { get; set; }
        public string MinimalAmountText { get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
    }
}