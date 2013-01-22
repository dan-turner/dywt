using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dywt.App.Infrastructure;
using Dywt.Mobile.Notifications;

namespace Dywt.Web.Framework
{
    public abstract class DywtController : Controller
    {
        public INotifier Notifier { get; set; }
        public ICommandBus CommandBus { get; set; }
        public IModelBuilder ModelBuilder { get; set; }
    }
}