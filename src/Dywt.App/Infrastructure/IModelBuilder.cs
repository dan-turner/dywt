namespace Dywt.App.Infrastructure
{
    public interface IModelBuilder
    {
        TOutput Create<TQuery, TOutput>(TQuery input);

        TOutput Create<TOutput>();
    }
}