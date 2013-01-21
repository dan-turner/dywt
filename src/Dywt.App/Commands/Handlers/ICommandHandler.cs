namespace Dywt.App.Commands.Handlers
{
    public interface ICommandHandler<TCommand>
    {
        void Execute(TCommand command);
    }
}