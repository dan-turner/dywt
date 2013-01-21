namespace Dywt.App.Models.Factories
{
    public interface IModelFactory<TInput, TOutput>
    {
        TOutput Create(TInput input);
    }

    public interface IModelFactory<TOutput>
    {
        TOutput Create();
    }
}