using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Requesters;
using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [RoutePrefix("Cliente")]
    public class ClientRequesterController : Controller
    {
        private readonly ClientRequesterAppContract _clientRequesterApp;
        public ClientRequesterController(
            ClientRequesterAppContract clientRequesterApp)
        {
            _clientRequesterApp = clientRequesterApp;
        }

        [Route("Novo")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public JsonResult Create(CreateClientRequester create)
        {
            MFIResultContract requester = _clientRequesterApp.Create(create);

            if (requester.HasSuccess)
                return Json(requester);

            Response.StatusCode = 400;

            return Json(requester);
        }
    }
}