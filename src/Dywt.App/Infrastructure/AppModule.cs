using System.Reflection;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dywt.App.Commands.Handlers;
using Dywt.App.Infrastructure.Autofac;
using Dywt.App.Models.Factories;
using Raven.Client;
using Module = Autofac.Module;

namespace Dywt.App.Infrastructure
{
    public class AppModule : Module
    {
        private static readonly Assembly AppAssembly = typeof(AppModule).Assembly;
        
        private readonly IDocumentStore _documentStore;

        public AppModule(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacCommandBus>().As<ICommandBus>();
            builder.RegisterType<AutofacModelBuilder>().As<IModelBuilder>();

            builder.Register(x => _documentStore.OpenSession()).As<IDocumentSession>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(AppAssembly)
                .Where(IsHandlerType)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        private static bool IsHandlerType(Type type)
        {
            return type.IsClosedTypeOf(typeof(IModelFactory<>))
                || type.IsClosedTypeOf(typeof(IModelFactory<,>))
                || type.IsClosedTypeOf(typeof(ICommandHandler<>));
        }
    }
}
