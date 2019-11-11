using System;
using System.Web.Mvc;

namespace MFI.WebAppMVC.Controllers
{
    public class BaseController : Controller
    {
        public bool IsAuthenticated
        {
            get { return HttpContext.User.Identity.IsAuthenticated; }
        }

        protected override void EndExecute(IAsyncResult asyncResult)
        {
            ViewBag.IsAuthenticated = IsAuthenticated;
            base.EndExecute(asyncResult);
        }
    }
}