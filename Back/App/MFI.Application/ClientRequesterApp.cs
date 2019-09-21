using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Requesters;
using MFI.Domain.Contracts.Repositories.Base;
using MFI.Domain.Entities;
using MFI.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MFI.Application
{
    public class ClientRequesterApp : ClientRequesterAppContract
    {
        private readonly UnityOfWorkContract _unityOfWork;

        public ClientRequesterApp(
            UnityOfWorkContract unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public MFIResult Create(
           CreateClientRequester client)
        {
            bool requesterExists =
                this._unityOfWork.ClientRequester
                    .Get(cli => cli.Email == client.Email)
                    .FirstOrDefault(cli => cli.Type.Equals(ClientType.Requester)) != null;

            if (requesterExists)
                return CreateResultHasClient(client);

            User user = new User(client.Email, client.Password);
            user.ValidadeToCreation();
            user.EncriptPassword();

            if (!user.IsValid())
                return CreateResultInvalidRequester(
                    client.Email,
                    client.Name,
                    user.EventNotification.List);

            ClientRequester requester =
                new ClientRequester(client.Email, client.Name, user);

            requester.ValidadeToCreation();

            if (!requester.IsValid())
                return CreateResultInvalidRequester(
                    requester.Email,
                    requester.Name,
                    requester.EventNotification.List);

            return CreateNewRequester(requester);
        }

        private CreatedClientRequester CreateNewRequester(ClientRequester requester)
        {
            CreatedClientRequester createdClient;
            this._unityOfWork.ClientRequester.Create(requester);
            this._unityOfWork.SaveChanges();

            createdClient = new CreatedClientRequester
            {
                Email = requester?.Email,
                Id = requester.ClientId.ToString(),
                Name = requester?.Name
            };
            return createdClient;
        }

        private NotCreatedClientRequester CreateResultHasClient(
            CreateClientRequester client)
        {
            NotCreatedClientRequester createdClient = new NotCreatedClientRequester
            {
                Email = client?.Email,

                Name = client?.Name
            };

            createdClient.AddWarning("Cliente Já Existente.");

            return createdClient;
        }

        private NotCreatedClientRequester CreateResultInvalidRequester(
            string email,
            string name,
            IList<object> warnings)
        {
            NotCreatedClientRequester createdClient = new NotCreatedClientRequester
            {
                Email = email,
                Name = name
            };
            createdClient.AddWarnings(warnings.Select(x => x.ToString()).ToList());
            return createdClient;
        }
    }
}