namespace Dywt.App.Infrastructure
{
    public interface ICommandBus
    {
        void Execute<TCommand>(TCommand command);
    }
}