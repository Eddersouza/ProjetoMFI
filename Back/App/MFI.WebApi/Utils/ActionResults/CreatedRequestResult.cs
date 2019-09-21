using edrsys.Utils.extensions;
using MFI.WebApi.Utils.Contents;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MFI.WebApi.Utils.ActionResults
{
    /// <summary>
    /// Custom Created Result to response.
    /// </summary>
    public class CreatedRequestResult : IHttpActionResult
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="reasonPhrase">Razão do erro.</param>
        /// <param name="request">Request da aplicação.</param>
        public CreatedRequestResult(
            string reasonPhrase,
            HttpRequestMessage request)
        {
            this.ReasonPhrase = reasonPhrase;
            this.Request = request;
        }


        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="reasonPhrase">Razão do erro.</param>
        /// <param name="request">Request da aplicação.</param>
        /// <param name="objectToReturn">Object to return</param>
        public CreatedRequestResult(
            string reasonPhrase,
            HttpRequestMessage request,
            object objectToReturn) : this(reasonPhrase, request)
        {
            this.ObjectToReturn = objectToReturn;
        }

        /// <summary>
        /// Object to Return.
        /// </summary>
        public object ObjectToReturn { get; }

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
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                RequestMessage = this.Request,
            };

            if (!this.ReasonPhrase.IsNullOrEmpty())
                response.ReasonPhrase = this.ReasonPhrase;

            if (ObjectToReturn != null)
                response.Content = new JsonContent(ObjectToReturn);

            return response;
        }
    }
}