using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MFI.WebApi.Utils.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(
            HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Ocorreu um erro no Sistema, Tente novamente ou entre em contato com o adminstrador."),
                ReasonPhrase = "Quero fazer festa - Ocorreu um erro no Sistema."
            };

            actionExecutedContext.Response = response;
        }
    }
}