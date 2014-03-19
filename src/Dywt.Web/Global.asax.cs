using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Dywt.Web.Infrastructure;

namespace Dywt.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var documentStore = DocumentStoreFactory.Create("RavenDB");

            var requireHttps = bool.Parse(ConfigurationManager.AppSettings["RequireHttps"]);

            AutofacConfig.RegisterModules(documentStore);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, requireHttps);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            MigrationConfig.UpgradeToLatest(documentStore);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if(Request.UserLanguages != null)
            {
                var culture = Request.UserLanguages.FirstOrDefault();

                if(!String.IsNullOrWhiteSpace(culture))
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
                }
            }
        }
    }
}