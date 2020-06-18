using CQS.Demo.ConsoleApp.Database;
using CQS.Demo.ConsoleApp.Infrastructure;
using System;

namespace CQS.Demo.ConsoleApp.Cqs
{
    public abstract class QueryHandler<TParameter, TResult> : IQueryHandler<TParameter, TResult>
        where TResult : IResult, new()
        where TParameter : IQuery, new()
    {
        protected readonly IBookRepository Repository;
        private readonly ILogger _logger;

        protected QueryHandler(IBookRepository repository, ILogger logger)
        {
            Repository = repository;
            _logger = logger;
        }

        public TResult Execute(TParameter query)
        {
            TResult _queryResult;

            try
            {
                _logger.Info($"Executing query {typeof(TParameter).Name}.");

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
