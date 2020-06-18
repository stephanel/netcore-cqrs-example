using Cqrs.Demo.ConsoleApp.Cqrs;
using Cqrs.Demo.ConsoleApp.Database;
using Cqrs.Demo.ConsoleApp.Infrastructure;

namespace Cqrs.Demo.ConsoleApp.Commands
{
    public class InsertBookCommandHandler : CommandHandler<InsertBookCommand>
    {
        public InsertBookCommandHandler(IBookRepository repository, ILogger logger)
           : base(repository, logger)
        {
        }

        protected override void Handle(InsertBookCommand request)
        {
            Repository.Add(request.Book);

            Repository.SaveChanges();
        }
    }
}
