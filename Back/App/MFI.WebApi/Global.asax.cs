using MFI.WebApi.App_Start;
using System.Web.Http;

namespace MFI.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            SimpleInjectorConfig.InitDI();
        }
    }
}