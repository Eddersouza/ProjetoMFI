using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Requesters;
using MFI.Domain.Entities;
using MFI.WebApi.Utils.ActionResults;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace MFI.WebApi.Controllers
{
    /// <summary>
    /// Controller to Client Requester
    /// </summary>
    [RoutePrefix("mfiapi/requester")]
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
        [SwaggerResponse(HttpStatusCode.OK, "Not applicable.")]
        [SwaggerResponse(HttpStatusCode.Created, "Client Requester successfully Created.", typeof(CreatedClientRequester))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Error on create Client Requester.", typeof(NotCreatedClientRequester))]
        public IHttpActionResult Post([FromBody]CreateClientRequester view)
        {
            MFIResultContract requester = _clientRequesterApp.Create(view);

            if (requester.HasSuccess)
                return new CreatedRequestResult("Cliente criado com sucesso", Request, requester);

            

            return new BadRequestResult("Erro ao criar Cliente", Request, requester);
        }
    }
}