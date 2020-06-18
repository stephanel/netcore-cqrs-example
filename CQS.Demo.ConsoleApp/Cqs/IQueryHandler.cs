namespace CQS.Demo.ConsoleApp.Cqs
{
    public interface IQueryHandler<TParameter, TResult>
    {
        TResult Execute(TParameter parameter);
    }
}
