using Cqrs.Demo.ConsoleApp.Database;
using Cqrs.Demo.ConsoleApp.Infrastructure;
using System;

namespace Cqrs.Demo.ConsoleApp.Cqrs
{
    public abstract class CommandHandler<TParameter> : ICommandHandler<TParameter>
    {
        protected readonly IBookRepository Repository;
        private readonly ILogger _logger;

        protected CommandHandler(IBookRepository repository, ILogger logger)
        {
            Repository = repository;
            _logger = logger;
        }

        public void Execute(TParameter command)
        {
            try
            {
                _logger.Info($"Executing command {typeof(TParameter).Name}.");

                Handle(command);
            }
            catch (Exception _exception)
            {
                _logger.Error($"Error in {typeof(TParameter).Name} queryHandler. \n" +
                    $" Message: {_exception.Message} \n" +
                    $" Stacktrace: {_exception.StackTrace}");

                throw;
            }
        }

        protected abstract void Handle(TParameter request);
    }
}
