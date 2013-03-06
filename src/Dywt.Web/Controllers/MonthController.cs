using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dywt.App.Models;
using Dywt.Web.Framework;

namespace Dywt.Web.Controllers
{
    public class MonthController : DywtController
    {
        public ActionResult Index(int year, int month)
        {
            var date = new DateTime(year, month, 1);

            var model = ModelBuilder.Create<DateTime, MonthViewModel>(date);

            return View(model);
        }
    }
}
