﻿using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Module = Autofac.Module;

namespace Dywt.Web.Infrastructure
{
    public class WebModule : Module
    {
        private static readonly Assembly WebAssembly = typeof(WebModule).Assembly;

        private readonly IDocumentStore _documentStore;

        public WebModule(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_documentStore).As<IDocumentStore>();

            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterControllers(WebAssembly).PropertiesAutowired();
        }
    }
}