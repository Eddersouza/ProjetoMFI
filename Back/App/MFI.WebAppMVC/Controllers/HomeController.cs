using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            var test = HttpContext.User.Identity;
            return View();
        }
    }
}