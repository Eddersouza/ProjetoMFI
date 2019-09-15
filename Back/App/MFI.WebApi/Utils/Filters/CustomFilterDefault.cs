using MFI.Domain.Contracts.Repositories.Base;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MFI.WebApi.Utils.Filters
{
    public class CustomFilterDefault : ActionFilterAttribute
    {
        public UnityOfWorkContract _unitOfWork { get; set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _unitOfWork = GlobalConfiguration.Configuration.DependencyResolver
                .GetService(typeof(UnityOfWorkContract)) as UnityOfWorkContract;

            if (actionExecutedContext.Exception == null)
            {
                this._unitOfWork.Commit();
            }
            else
            {
                this._unitOfWork.Rowback();

                this.GetException(actionExecutedContext);

                actionExecutedContext.Response = this.CreateInternalErrorResponse();
            }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            this._unitOfWork = GlobalConfiguration.Configuration.DependencyResolver
                .GetService(typeof(UnityOfWorkContract)) as UnityOfWorkContract;

            this._unitOfWork.BeginTransaction();

            base.OnActionExecuting(actionContext);
        }

        private HttpResponseMessage CreateInternalErrorResponse()
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Ocorreu um erro no Sistema, Tente novamente ou entre em contato com o adminstrador."),
                ReasonPhrase = "Quero fazer festa - Ocorreu um erro no Sistema."
            };
        }

        private void GetException(HttpActionExecutedContext actionExecutedContext)
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
        }
    }
}