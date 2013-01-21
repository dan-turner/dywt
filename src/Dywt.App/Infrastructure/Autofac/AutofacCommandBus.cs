using System;
using Autofac;
using Dywt.App.Commands.Handlers;

namespace Dywt.App.Infrastructure.Autofac
{
    /// <summary>
    /// This class acts as a service locator for command handlers.  Its purpose is to
    /// execute the appropriate ICommandHandler based on the type of the supplied command.
    /// 
    /// For the most part DI should be chosen in favour of service location,
    /// however in this instance I believe it is justified for two reasons:
    /// 
    /// 1) It reduces the number of direct dependencies within controllers. The alternative
    ///    would have controllers depend directly on all their required ICommandHandler's.
    ///    
    /// 2) It abstracts the concern of selecting the correct ICommandHandler away from the caller.
    /// </summary>
    public class AutofacCommandBus : ICommandBus
    {
        private readonly IComponentContext _container;

        public AutofacCommandBus(IComponentContext container)
        {
            _container = container;
        }

        #region ICommandBus Members

        public void Execute<TCommand>(TCommand command)
        {
            var handler = _container.Resolve<ICommandHandler<TCommand>>();
            handler.Execute(command);
        }

        #endregion
    }
}