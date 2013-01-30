using Dywt.App;
using Dywt.App.Commands;
using Dywt.App.Infrastructure;
using Dywt.App.Models;
using Dywt.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dywt.Web.Controllers
{
    [Authorize]
    public class DayController : DywtController
    {
        public ActionResult Entry(DateTime? date)
        {
            if(!date.HasValue)
            {
                var today = UserTime.LocalNow().Date;
                return RedirectToAction("Entry", new { date = today.ToString("yyyy-MM-dd") });
            }

            var model = ModelBuilder.Create<DateTime, DayEntryModel>(date.Value);
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Entry(DayEntryCommand command)
        {
            CommandBus.Execute(command);
            Notifier.Success("Entry saved for {0}", command.Date);
            return RedirectToAction("Entry", new { date = command.Date.ToString("yyyy-MM-dd") });
        }
    }
}
