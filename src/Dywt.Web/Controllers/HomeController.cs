using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dywt.Web.Framework;
using Dywt.App;
using Dywt.App.Infrastructure;

namespace Dywt.Web.Controllers
{
    public class HomeController : DywtController
    {
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var today = UserTime.LocalNow().Date;
                return RedirectToAction("Index", "Month", new { today.Year, today.Month });
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
