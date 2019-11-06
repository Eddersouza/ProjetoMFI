using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [RoutePrefix("Fornecedor")]
    public class ClientProviderController : Controller
    {
        [Route("Novo")]
        public ActionResult New()
        {
            return View();
        }
    }
}