﻿using MFI.Application.Base;
using MFI.Application.Interfaces;
using MFI.Application.ViewModels.Clients.Requesters;
using MFI.Domain.Enums;
using MFI.WebAppMVC.Utils.Security;
using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    [RoutePrefix("Usuario")]
    public class UserController : BaseController
    {
        private readonly UserAppContract _clientRequesterApp;

        public UserController(
            UserAppContract clientRequesterApp)
        {
            _clientRequesterApp = clientRequesterApp;
        }

        [Route("Tipo")]
        public ActionResult ChooseType()
        {
            return View();
        }

        public ActionResult Login(
            string email,
            string password,
            ClientType? clientType)
        {
            MFIResult result = _clientRequesterApp.Login(email, password, clientType);

            if (result.HasSuccess)
            {
                LoginRequester requester = result as LoginRequester;

                CookieHelper.Set(requester.User, HttpContext);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            CookieHelper.Clean();

            return RedirectToAction("Index", "Home");
        }
    }
}