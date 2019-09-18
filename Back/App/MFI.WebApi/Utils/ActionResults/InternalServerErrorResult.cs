using MFI.WebApi.Utils.Contents;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MFI.WebApi.Utils.ActionResults
{
    /// <summary>
    /// Classe para lançamento do erro do tipo Internal Server Erro.
    /// </summary>
    public class InternalServerErrorResult : IHttpActionResult
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="reasonPhrase">Razão do erro.</param>
        /// <param name="request">Request da aplicação.</param>
        public InternalServerErrorResult(string reasonPhrase, HttpRequestMessage request, List<string> errorsContent)
        {
            this.ReasonPhrase = reasonPhrase;
            this.Request = request;
            this.ErrorsContent = errorsContent;
        }
        public List<string> ErrorsContent { get; set; }
        /// <summary>
        /// Descrição do .
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
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                RequestMessage = this.Request,
                ReasonPhrase = this.ReasonPhrase,
                Content = new JsonContent(ErrorsContent)
            };

            return response;
        }
    }
}