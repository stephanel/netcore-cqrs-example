namespace Cqrs.Demo.ConsoleApp.Cqrs
{
    public interface ICommandDispatcher
    {
        void Dispatch<TParameter>(TParameter query)
            where TParameter : ICommand;
    }
}
