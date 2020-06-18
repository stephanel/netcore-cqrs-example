using Autofac;
using System;

namespace CQS.Demo.ConsoleApp.Cqs
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _Context;

        public QueryDispatcher(IComponentContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IResult
        {
            var _handler = _Context.Resolve<IQueryHandler<TParameter, TResult>>();
            return _handler.Execute(query);
        }
    }
}
