namespace MFI.Domain.Entities
{
    public class ClientProvider : Client
    {
        public const int CompanyNameMaxLength = 80;
        public const int CompanyNameMinLength = 10;
        public const int DescriptionMaxLength = 500;
        public const int DescriptionMinLength = 10;


        public ClientProvider()
        {
        }

        public ClientProvider(
           string email,
           string name,
           string companyName,
           string description,
           User user) : base(email, name, user)
        {
            this.Type = Enums.ClientType.Provider;
            this.CompanyName = companyName;
            this.Description = description;
        }

        public string Description { get; set; }

        public string CompanyName { get; set; }
    }
}