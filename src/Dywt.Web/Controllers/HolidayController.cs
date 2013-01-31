using Dywt.App.Commands;
using Dywt.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dywt.Web.Controllers
{
    public class HolidayController : DywtController
    {
        public ActionResult Entry()
        {
            var command = new HolidayEntryCommand();
            return View(command);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Entry(HolidayEntryCommand command)
        {
            CommandBus.Execute(command);
            Notifier.Success("Holiday entered for {0} until {1}", command.DateFrom.Value.ToShortDateString(), command.DateTo.Value.ToShortDateString());
            return RedirectToAction("Entry", "Day");
        }
    }
}
