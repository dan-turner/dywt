using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dywt.Mobile.Notifications
{
    public class NotifierActionFilter : ActionFilterAttribute
    {
        private const string TempDataKey = "___Notifications";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var service = DependencyResolver.Current.GetService<INotifier>();

            if (filterContext.Controller.TempData.ContainsKey(TempDataKey))
            {
                var notifications = (IEnumerable<Notification>)filterContext.Controller.TempData[TempDataKey];
                service.Push(notifications);
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var service = DependencyResolver.Current.GetService<INotifier>();
            var notifications = service.Pop();

            if (notifications.Any())
            {
                //Between OnActionExecuting of this request and now another Ajax request
                //may have pushed more notifications to TempData, therefore union these
                //messages with any existing.
                //This "if" block should probably even be synchronised on session.
                if (filterContext.Controller.TempData.ContainsKey(TempDataKey))
                {
                    var additional = (IEnumerable<Notification>)filterContext.Controller.TempData[TempDataKey];
                    notifications = additional.Union(notifications);
                }
                filterContext.Controller.TempData[TempDataKey] = notifications;
            }
        }
    }
}