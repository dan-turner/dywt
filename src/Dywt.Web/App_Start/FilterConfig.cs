using Dywt.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace Dywt.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, bool requireHttps)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AtomicFilter());

            if (requireHttps)
            {
                filters.Add(new RequireHttpsAttribute());
            }
        }
    }
}