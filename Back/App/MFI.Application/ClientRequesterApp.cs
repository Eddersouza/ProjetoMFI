using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Requesters;
using MFI.Domain.Contracts.Repositories.Base;
using MFI.Domain.Entities;
using MFI.Domain.Enums;
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
            CreatedClientRequester createdClient = null;

            bool requesterExists =
                this._unityOfWork.ClientRequester
                    .Get(cli => cli.Email == client.Email)
                    .FirstOrDefault(cli => cli.Type.Equals(ClientType.Requester)) != null;

            if (requesterExists)
                return CreateResultHasClient(client);

            User user = new User(client.Email, client.Password);

            ClientRequester requester =
                new ClientRequester(client.Email, client.Name, user);

            if (!requester.IsValid())
                return CreateResultInvalidRequester(requester);

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

        private NotCreatedClientRequester CreateResultInvalidRequester(ClientRequester requester)
        {
            NotCreatedClientRequester createdClient = new NotCreatedClientRequester
            {
                Email = requester?.Email,
                Name = requester?.Name
            };
            createdClient.AddWarnings(requester.EventNotification.Warnings.Select(x => x.ToString()).ToList());
            return createdClient;
        }
    }
}