using MFI.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace MFI.WebAppMVC.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void InitDI()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DIModule.InitializeIoc(container, Lifestyle.Scoped);

            //GlobalConfiguration.Configuration.DependencyResolver
            //   = new SimpleInjectorWebApiDependencyResolver(container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}