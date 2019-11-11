using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Requesters;
using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [RoutePrefix("Cliente")]
    public class ClientRequesterController : BaseController
    {
        private readonly ClientRequesterAppContract _clientRequesterApp;

        public ClientRequesterController(
            ClientRequesterAppContract clientRequesterApp)
        {
            _clientRequesterApp = clientRequesterApp;
        }

        [HttpPost]
        [Route("")]
        public JsonResult Create(CreateClientRequester create)
        {
            MFIResultContract result = null;
            try
            {
                result = _clientRequesterApp.Create(create);

                if (result.HasSuccess)
                    return Json(result);

                Response.StatusCode = 400;

                return Json(result);
            }
            catch
            {
                result = new MFIResult();

                result.AddWarning("Ocorreu um erro ao executar a ação.");
                result.AddWarning("Tente novamente ou entre em contato com o administrador.");

                Response.StatusCode = 500;

                return Json(result);
            }
        }

        [Route("Novo")]
        public ActionResult New()
        {
            return View();
        }
    }
}