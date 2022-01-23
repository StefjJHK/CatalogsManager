namespace BusinessLogic.Services.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : class
    {
        void Execute(TCommand command);
    }
}
