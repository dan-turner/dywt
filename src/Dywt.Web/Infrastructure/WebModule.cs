using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Dywt.Mobile.Notifications;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Module = Autofac.Module;
using System.Security.Principal;

namespace Dywt.Web.Infrastructure
{
    public class WebModule : Module
    {
        private static readonly Assembly WebAssembly = typeof(WebModule).Assembly;

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterControllers(WebAssembly).PropertiesAutowired();
            builder.RegisterType<Notifier>().As<INotifier>().InstancePerLifetimeScope();
            builder.Register(x => x.Resolve<HttpContextBase>().User).As<IPrincipal>();
        }
    }
}