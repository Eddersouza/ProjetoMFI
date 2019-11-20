using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Providers;
using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [RoutePrefix("Fornecedor")]
    public class ClientProviderController : BaseController
    {
        private readonly ClientProviderAppContract _clientProviderApp;

        public ClientProviderController(
            ClientProviderAppContract clientProviderApp)
        {
            this._clientProviderApp = clientProviderApp;
        }

        [HttpGet]
        [Route("Cards")]
        public PartialViewResult Cards()
        {
            MFIResultContract result = null;

            result = _clientProviderApp.ListCardsProvider();
            return PartialView("_ProviderCardList", result);
        }

        [HttpPost]
        [Route("")]
        public JsonResult Create(
           CreateClientProvider client)
        {
            MFIResultContract result = null;
            try
            {
                result = _clientProviderApp.Create(client);

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

        [HttpGet]
        [Route("Gerenciar")]
        public ActionResult Manage(string email)
        {
            return View();
        }

        [HttpGet]
        [Route("Novo")]
        public ActionResult New()
        {
            return View();
        }
    }
}