using CQS.Demo.ConsoleApp.Cqs;
using CQS.Demo.ConsoleApp.Database;
using CQS.Demo.ConsoleApp.Entities;
using CQS.Demo.ConsoleApp.Infrastructure;
using System.Linq;

namespace CQS.Demo.ConsoleApp.Queries
{
    public class GetBooksQueryHandler : QueryHandler<GetBooksQuery, GetBooksQueryResult>
    {
        public GetBooksQueryHandler(IBookRepository repository, ILogger logger)
            : base(repository, logger)
        {
        }

        protected override GetBooksQueryResult Handle(GetBooksQuery request)
        {
            var _result = new GetBooksQueryResult();

            var _bookQuery = Repository.GetAll();

            if (request.YearOfPublication != null)
            {
                _bookQuery = _bookQuery.Where(c => c.DatePublished.Year == (int)request.YearOfPublication);
            }

            _result.Books = _bookQuery.ToList();

            return _result;
        }
    }
}
