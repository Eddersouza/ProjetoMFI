using System;
using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}