using CQS.Demo.ConsoleApp.Cqs;
using CQS.Demo.ConsoleApp.Database;
using CQS.Demo.ConsoleApp.Infrastructure;

namespace CQS.Demo.ConsoleApp.Commands
{
    public class InsertBookCommandHandler : CommandHandler<InsertBookCommand>
    {
        public InsertBookCommandHandler(ApplicationDbContext applicationDbContext, ILogger logger)
           : base(applicationDbContext, logger)
        {
        }

        protected override void Handle(InsertBookCommand request)
        {
            ApplicationDbContext.Books.Add(request.Book);

            ApplicationDbContext.SaveChanges();
        }
    }
}
