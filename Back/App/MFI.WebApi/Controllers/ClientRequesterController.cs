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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "System error in action.", typeof(List<string>))]
        public IHttpActionResult Post([FromBody]CreateClientRequester view)
        {
            try
            {
                return new CreatedRequestResult(
                    "Usuário criado com sucesso",
                    Request,
                    new CreatedClientRequester
                    {
                        Email = view.Email,
                        Id = "IdCriado",
                        Name = view.Name
                    });
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }
    }
}