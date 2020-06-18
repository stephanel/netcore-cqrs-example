namespace Cqrs.Demo.ConsoleApp.Cqrs
{
    public interface IQueryHandler<TParameter, TResult>
    {
        TResult Execute(TParameter parameter);
    }
}
