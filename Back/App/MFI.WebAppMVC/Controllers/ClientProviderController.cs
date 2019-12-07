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
        private readonly ProviderServiceAppContract _providerServiceApp;

        public ClientProviderController(
            ClientProviderAppContract clientProviderApp,
            ServiceAppContract serviceApp,
            ProviderServiceAppContract providerServiceApp)
        {
            this._clientProviderApp = clientProviderApp;
            this._serviceApp = serviceApp;
            _providerServiceApp = providerServiceApp;
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
        [AllowAnonymous]
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
        public ActionResult Manage(
            string tabs = null)
        {
            ViewBag.Tabs = tabs;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Novo")]
        public ActionResult New()
        {
            return View(new ClientProviderView());
        }

        [HttpGet]
        [Route("Dados/{clientId}")]
        public PartialViewResult PartialClientProvider(string clientId)
        {
            ClientProviderView result = null;

            result = _clientProviderApp.getClient(clientId);

            return PartialView("_ClientProvider", result);
        }

        [HttpGet]
        [Route("Servicos/{clientId}")]
        public PartialViewResult Services(string clientId)
        {
            MFIResultContract result = null;

            result = _serviceApp.GetServicesProvider(clientId);

            return PartialView("_ServicesProvider", result);
        }

        [HttpPost]
        [Route("Servico/Gerenciar")]
        public JsonResult ServiceManage(
            ServiceProviderItemView service)
        {
            MFIResultContract result = new MFIResult();
            try
            {
                bool add = _providerServiceApp.Add(service);

                if (add)
                {
                    result.AddWarning("Erro ao alterar Serviço.");
                    Response.StatusCode = 400;

                    return Json(result);
                }


                return Json(result);
            }
            catch
            {
                result.AddWarning("Ocorreu um erro ao executar a ação.");
                result.AddWarning("Tente novamente ou entre em contato com o administrador.");

                Response.StatusCode = 500;

                return Json(result);
            }
        }
    }
}