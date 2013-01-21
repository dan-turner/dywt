using Autofac;
using Dywt.App.Models.Factories;

namespace Dywt.App.Infrastructure.Autofac
{
    /// <summary>
    /// This class acts as a service locator for models. Its purpose is to return
    /// the appropriate type of model based upon the type of the input model
    /// 
    /// For the most part DI should be chosen in favour of service location,
    /// however in this instance I believe it is justified for two reasons:
    /// 
    /// 1) It abstracts the concern of selecting the correct IModelFactory away from the caller.
    /// 
    /// 2) It reduces the number of direct dependencies within controllers. The alternative
    ///    would have controllers depend directly on all their required IModelFactory's.
    /// </summary>
    public class AutofacModelBuilder : IModelBuilder
    {
        private readonly IComponentContext _container;

        public AutofacModelBuilder(IComponentContext container)
        {
            _container = container;
        }

        #region IModelBuilder Members

        public TOutput Create<TInput, TOutput>(TInput input)
        {
            return _container.Resolve<IModelFactory<TInput, TOutput>>()
                            .Create(input);
        }

        public TOutput Create<TOutput>()
        {
            return _container.Resolve<IModelFactory<TOutput>>()
                            .Create();
        }

        #endregion
    }
}