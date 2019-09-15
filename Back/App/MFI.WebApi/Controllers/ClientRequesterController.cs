using MFI.Application.Interfaces;
using MFI.Domain.Entities;
using MFI.WebApi.Utils.ActionResults;
using MFI.WebApi.ViewModels.Clients.Requesters;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace MFI.WebApi.Controllers
{
    /// <summary>
    /// Controller to Client Requester
    /// </summary>
    [RoutePrefix("requester")]
    public class ClientRequesterController : ApiController
    {
        private readonly ClientRequesterAppContract _clientRequesterApp;

        public ClientRequesterController(
            ClientRequesterAppContract clientRequesterApp)
        {
            _clientRequesterApp = clientRequesterApp;
        }

        /// <summary>
        /// Create new Client Requester.
        /// </summary>
        /// <param name="view">Object with data to create Client Requester.</param>
        /// <remarks>
        /// Add new Client requester and return Created Client.
        /// </remarks>
        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, "Client Requester successfully Created.", typeof(CreatedClientRequester))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Error on create Client Requester.", typeof(List<string>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "System error in action.", typeof(string))]
        public IHttpActionResult Post([FromBody]CreateClientRequester view)
        {
            ClientRequester requester = _clientRequesterApp.Create(view.Name, view.Email, view.Password);

            return new CreatedRequestResult(
                "Usuário criado com sucesso",
                Request,
                new CreatedClientRequester
                {
                    Email = view.Email,
                    Id = requester.ClientId.ToString(),
                    Name = view.Name
                });

        }
    }
}