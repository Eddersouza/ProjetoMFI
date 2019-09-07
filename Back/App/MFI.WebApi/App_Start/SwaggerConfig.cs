using System.Web.Http;
using WebActivatorEx;
using MFI.WebApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MFI.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Quero Fazer festa");

                        c.PrettyPrint();
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.IgnoreObsoleteProperties();
                        c.DescribeAllEnumsAsStrings();
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("Quero fazer Festa");
                    });
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\MFI.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
