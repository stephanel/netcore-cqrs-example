namespace CQS.Demo.ConsoleApp.Cqs
{
    public interface ICommandDispatcher
    {
        void Dispatch<TParameter>(TParameter query)
            where TParameter : ICommand;
    }
}
