using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Providers;
using MFI.Domain.Contracts.Repositories.Base;
using MFI.Domain.Entities;
using MFI.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MFI.Application
{
    public class ClientProviderApp : ClientProviderAppContract
    {
        private readonly UnityOfWorkContract _unityOfWork;

        public ClientProviderApp(
            UnityOfWorkContract unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public MFIResult Create(
            CreateClientProvider client)
        {
            bool providerExists =
                this._unityOfWork.ClientProvider
                    .Get(cli => cli.Email == client.Email)
                    .FirstOrDefault(cli => cli.Type.Equals(ClientType.Provider)) != null;

            if (providerExists)
                return CreateResultHasClient(client);

            User user = new User(client.Email, client.Password);
            user.ValidadeToCreation();
            user.EncriptPassword();

            if (!user.IsValid())
                return CreateResultInvalidProvider(
                    client.Email,
                    client.Name,
                    client.CompanyName,
                    client.Description,
                    user.EventNotification.List);

            ClientProvider provider =
                new ClientProvider(
                    client.Email,
                    client.Name,
                    client.CompanyName,
                    client.Description,
                    user);

            provider.ValidadeToCreation();

            if (!provider.IsValid())
                return CreateResultInvalidProvider(
                    provider.Email,
                    provider.Name,
                    provider.CompanyName,
                    provider.Description,
                    provider.EventNotification.List);

            return CreateNewProvider(provider);
        }

        public MFIResult ListCardsProvider()
        {
            CardsProviderView view = new CardsProviderView();

            var list = _unityOfWork.ClientProvider.Get().ToList();

            foreach (var item in list)
            {
                view.Items.Add(new CardProviderView(item));
            }

            return view;
        }

        private MFIResult CreateNewProvider(
            ClientProvider provider)
        {
            this._unityOfWork.ClientProvider.Create(provider);
            this._unityOfWork.SaveChanges();

            return new CreatedClientProvider()
            {
                CompanyName = provider.CompanyName,
                Description = provider.Description,
                Email = provider.Email,
                Id = provider.ClientId.ToString(),
                Name = provider.Name
            };
        }

        private NotCreatedClientProvider CreateResultHasClient(
                   CreateClientProvider client)
        {
            NotCreatedClientProvider createdClient = new NotCreatedClientProvider
            {
                Email = client?.Email,
                Name = client?.Name,
                CompanyName = client?.CompanyName,
                Description = client?.Description
            };

            createdClient.AddWarning("Cliente Já Existente.");

            return createdClient;
        }

        private NotCreatedClientProvider CreateResultInvalidProvider(
            string email,
            string name,
            string companyName,
            string description,
            IList<object> warnings)
        {
            NotCreatedClientProvider createdClient = new NotCreatedClientProvider
            {
                Email = email,
                Name = name,
                CompanyName = companyName,
                Description = description
            };
            createdClient.AddWarnings(warnings.Select(x => x.ToString()).ToList());
            return createdClient;
        }
    }
}