using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [RoutePrefix("Servicos")]
    public class ServicesController : BaseController
    {
        // GET: Services
        public ActionResult ProviderServices()
        {
            return View();
        }
    }
}