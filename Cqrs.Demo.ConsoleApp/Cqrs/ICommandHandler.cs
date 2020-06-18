namespace Cqrs.Demo.ConsoleApp.Cqrs
{
    public interface ICommandHandler<TParameter>
    {
        void Execute(TParameter command);
    }
}
