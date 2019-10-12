using MFI.Application.Base;

namespace MFI.Application.ViewModels.Clients.Providers
{
    public class CreatedClientProvider : MFIResult
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}