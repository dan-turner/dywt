using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dywt.Mobile.Notifications;

namespace Dywt.Mobile.Helpers
{
    public static class NotificationExtensions
    {
        public static IHtmlString Notifications(this HtmlHelper htmlHelper)
        {
            var service = DependencyResolver.Current.GetService<INotifier>();
            var notifications = service.Pop();

            if(!notifications.Any())
            {
                return new HtmlString(String.Empty);
            }

            var dictionary = notifications.GroupBy(x => x.Type)
                .ToDictionary(g => g.Key, g => g.ToList());

            return htmlHelper.Partial("_Notifications", dictionary);
        }
    }
}