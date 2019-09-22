using MFI.Utils;
using MFI.WebApi.Utils.Filters;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace MFI.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute(MFISetting.CorsSite, "*", "*");

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            config.Filters.Add(new CustomFilterDefault());

            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "mfiapi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}