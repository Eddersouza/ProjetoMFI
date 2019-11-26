using System;

namespace MFI.Application.ViewModels.Clients.Providers
{
    public class ClientProviderView
    {
        public ClientProviderView()
        {
        }

        public ClientProviderView(
            Guid clientId,
            string email,
            string name,
            string companyName,
            string description)
        {
            ClientId = clientId.ToString();
            Email = email;
            Name = name;
            CompanyName = companyName;
            Description = description;
        }

        public string ClientId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}