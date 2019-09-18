using MFI.WebApi.Utils.ActionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace MFI.WebApi.Utils.Filters
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            List<string> erros = new List<string>() { "Ocorreu um erro no Sistema, Tente novamente ou entre em contato com o adminstrador." };

            context.Result = new InternalServerErrorResult("Quero fazer festa - Ocorreu um erro no Sistema.", context.Request, erros);
        }
    }
}