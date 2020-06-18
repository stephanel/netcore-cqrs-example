using CQS.Demo.ConsoleApp.Database;
using CQS.Demo.ConsoleApp.Infrastructure;
using System;

namespace CQS.Demo.ConsoleApp.Cqs
{
    public abstract class QueryHandler<TParameter, TResult> : IQueryHandler<TParameter, TResult>
        where TResult : IResult, new()
        where TParameter : IQuery, new()
    {
        protected readonly ApplicationDbContext ApplicationDbContext;
        private readonly ILogger _logger;

        protected QueryHandler(ApplicationDbContext applicationDbContext, ILogger logger)
        {
            ApplicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public TResult Execute(TParameter query)
        {
            TResult _queryResult;

            try
            {
                _queryResult = Handle(query);

            }
            catch (Exception _exception)
            {
                _logger.Error($"Error in {typeof(TParameter).Name} queryHandler. \n" +
                    $" Message: {_exception.Message} \n" +
                    $" Stacktrace: {_exception.StackTrace}");

                throw;
            }
            finally
            {
                _logger.Info($"Response for query {typeof(TParameter).Name}.");
            }

            return _queryResult;
        }

        protected abstract TResult Handle(TParameter request);
    }
}
