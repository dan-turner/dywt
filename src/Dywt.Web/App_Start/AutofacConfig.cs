using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Dywt.Web.Infrastructure;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dywt.Web
{
    public static class AutofacConfig
    {
        public static void RegisterModules(IDocumentStore documentStore)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new WebModule(documentStore));
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}