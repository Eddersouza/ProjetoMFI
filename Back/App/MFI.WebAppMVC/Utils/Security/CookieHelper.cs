﻿using MFI.Domain.Entities;
using System;
using System.Web;
using System.Web.Security;

namespace MFI.WebAppMVC.Utils.Security
{
    public class CookieHelper
    {
        public static void Clean()
        {
            FormsAuthentication.SignOut();
        }

        public static void Set(
             SystemUser auth,
             HttpContextBase httpContext)
        {
            FormsAuthentication.SignOut();

            FormsAuthentication.SetAuthCookie(auth.UserId, false);

            var authTicket = new FormsAuthenticationTicket(
                1,
                auth.UserId,
                DateTime.Now,
                DateTime.Now.AddMinutes(20),
                false,
                auth.ToString());

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            httpContext.Response.Cookies.Add(authCookie);
        }
    }
}