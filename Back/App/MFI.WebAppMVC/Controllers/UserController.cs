using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [RoutePrefix("Usuario")]
    public class UserController : Controller
    {
        [Route("Tipo")]
        public ActionResult ChooseType()
        {
            return View();
        }
    }
}