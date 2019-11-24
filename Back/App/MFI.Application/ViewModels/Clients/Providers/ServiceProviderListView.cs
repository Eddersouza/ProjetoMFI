using MFI.Application.Base;
using System.Collections.Generic;

namespace MFI.Application.ViewModels.Clients.Providers
{
    public class ServiceProviderListView : MFIResult
    {
        public List<ServiceProviderItemView> Items { get; set; }
    }
}