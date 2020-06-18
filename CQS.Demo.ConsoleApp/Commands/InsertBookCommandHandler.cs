using CQS.Demo.ConsoleApp.Cqs;
using CQS.Demo.ConsoleApp.Database;
using CQS.Demo.ConsoleApp.Infrastructure;

namespace CQS.Demo.ConsoleApp.Commands
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
