using Autofac;
using System;

namespace CQS.Demo.ConsoleApp.Cqs
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _Context;

        public CommandDispatcher(IComponentContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispatch<TParameter>(TParameter query) where TParameter : ICommand
        {
            var _handler = _Context.Resolve<ICommandHandler<TParameter>>();
            _handler.Execute(query);
        }
    }
}
