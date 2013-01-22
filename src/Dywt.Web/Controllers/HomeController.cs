using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dywt.Web.Framework;
using Dywt.App;

namespace Dywt.Web.Controllers
{
    public class HomeController : DywtController
    {
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Entry", "Day");
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
