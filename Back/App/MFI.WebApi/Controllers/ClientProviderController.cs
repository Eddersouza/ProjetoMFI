using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Providers;
using MFI.WebApi.Utils.ActionResults;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;

namespace MFI.WebApi.Controllers
{
    [RoutePrefix("mfiapi/provider")]
    public class ClientProviderController : ApiController
    {
        private readonly ClientProviderAppContract _clientProviderApp;

        public ClientProviderController(
            ClientProviderAppContract clientProviderApp)
        {
            this._clientProviderApp = clientProviderApp;
        }

        /// <summary>
        /// Create new Client Provider.
        /// </summary>
        /// <param name="view">Object with data to create Client Provider.</param>
        /// <remarks>
        /// Add new Client Provider and return Created Client.
        /// </remarks>
        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Not applicable.")]
        [SwaggerResponse(HttpStatusCode.Created, "Client Provider successfully Created.", typeof(CreatedClientProvider))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Error on create Client Provider.", typeof(NotCreatedClientProvider))]
        public IHttpActionResult Post([FromBody]CreateClientProvider view)
        {
            MFIResultContract requester = _clientProviderApp.Create(view);

            if (requester.HasSuccess)
                return new CreatedRequestResult("Fornecedor criado com sucesso", Request, requester);

            return new BadRequestResult("Erro ao criar Fornecedor", Request, requester);
        }


        /// <summary>
        /// List Clients Providers.
        /// </summary>
        /// <returns>List cards with Provider Data.</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "List cards to Providers.", typeof(CardsProviderView))]
        public IHttpActionResult GetCards()
        {
            return Ok(_clientProviderApp.ListCardsProvider());
        }
    }
}