using MFI.Domain.Entities;
using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MFI.WebAppMVC.Controllers
{
    public class BaseController : Controller
    {
        public SystemUser SystemUser
        {
            get
            {
                SystemUser user = null;

                if (HttpContext.Request.IsAuthenticated)
                {
                    FormsAuthenticationTicket authTicket = null;
                    var authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (authCookie != null)
                    {
                        authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                        if (authTicket != null && !authTicket.Expired)
                        {
                            user = new JavaScriptSerializer().Deserialize<SystemUser>(authTicket.UserData);
                        }
                    }
                }

                return user;
            }
        }

        public bool IsAuthenticated
        {
            get { return HttpContext.User.Identity.IsAuthenticated; }
        }

        protected override void EndExecute(IAsyncResult asyncResult)
        {
            ViewBag.Name = SystemUser?.UserName;
            ViewBag.IsAuthenticated = IsAuthenticated;
            ViewBag.ClientId = SystemUser?.UserId;
            base.EndExecute(asyncResult);
        }
    }
}