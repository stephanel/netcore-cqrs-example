namespace CQS.Demo.ConsoleApp.Cqs
{
    public interface ICommandHandler<TParameter>
    {
        void Execute(TParameter command);
    }
}
