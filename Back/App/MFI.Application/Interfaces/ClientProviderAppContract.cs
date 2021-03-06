﻿using MFI.Application.Base;
using MFI.Application.ViewModels.Clients.Providers;

namespace MFI.Application.Interfaces
{
    public interface ClientProviderAppContract
    {
        MFIResult Create(
           CreateClientProvider client);

        ClientProviderView getClient(string clientId);

        MFIResult ListCardsProvider();
    }
}