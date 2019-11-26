using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Providers;
using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [Authorize]
    [RoutePrefix("Fornecedor")]
    public class ClientProviderController : BaseController
    {
        private readonly ClientProviderAppContract _clientProviderApp;
        private readonly ServiceAppContract _serviceApp;

        public ClientProviderController(
            ClientProviderAppContract clientProviderApp,
            ServiceAppContract serviceApp)
        {
            this._clientProviderApp = clientProviderApp;
            this._serviceApp = serviceApp;
        }

        [HttpGet]
        [AllowAnonymous]
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
        public ActionResult Manage()
        {
            return View();
        }

        [HttpGet]
        [Route("Novo")]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet]
        [Route("Servicos/{clientId}")]
        public PartialViewResult Services(string clientId)
        {
            MFIResultContract result = null;

            result = _serviceApp.GetServicesProvider(clientId);

            return PartialView("_ServicesProvider", result);

        }
    }
}