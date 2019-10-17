using MFI.Application.Base;
using System.Collections.Generic;

namespace MFI.Application.ViewModels.Clients.Providers
{
    public class CardsProviderView : MFIResult
    {
        public CardsProviderView()
        {
            this.Items = new List<CardProviderView>();
        }

        public List<CardProviderView> Items { get; set; }
    }
}