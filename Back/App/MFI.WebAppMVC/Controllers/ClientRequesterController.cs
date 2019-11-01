using MFI.Application.ViewModels.Clients.Requesters;
using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [RoutePrefix("Cliente")]
    public class ClientRequesterController : Controller
    {
        [Route("Novo")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public JsonResult Create(CreateClientRequester create)
        {
            return Json(null);
        }
    }
}