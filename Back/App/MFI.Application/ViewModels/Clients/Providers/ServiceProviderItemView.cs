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
            int serviceId)
        {
            Description = description;
            Name = name;
            ServiceId = serviceId;
        }

        public bool Active { get; set; }
        public string Description { get; set; }
        public decimal MinimalAmount { get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
    }
}