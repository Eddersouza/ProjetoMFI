using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MFI.WebApi.Utils.ActionResults
{
    /// <summary>
    /// Classe custom para response do status BadResult
    /// </summary>
    public class BadRequestResult : IHttpActionResult
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="reasonPhrase">Razão do erro.</param>
        /// <param name="request">Request da aplicação.</param>
        public BadRequestResult(string reasonPhrase, HttpRequestMessage request)
        {
            this.ReasonPhrase = reasonPhrase;
            this.Request = request;
        }

        /// <summary>
        /// Razão do erro.
        /// </summary>
        public string ReasonPhrase { get; }

        /// <summary>
        /// Request da aplicação.
        /// </summary>
        public HttpRequestMessage Request { get; }

        /// <summary>
        /// Excução assincrona.
        /// </summary>
        /// <param name="cancellationToken">Token de Tempo de cancelamento.</param>
        /// <returns>Resultado da execução.</returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(this.Execute());
        }

        /// <summary>
        /// Executa ação de autenticação falha.
        /// </summary>
        /// <returns>response com erros.</returns>
        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                RequestMessage = this.Request,
                ReasonPhrase = this.ReasonPhrase
            };

            return response;
        }
    }
}