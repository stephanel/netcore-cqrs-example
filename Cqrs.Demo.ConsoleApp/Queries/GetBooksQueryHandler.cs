using Cqrs.Demo.ConsoleApp.Cqrs;
using Cqrs.Demo.ConsoleApp.Database;
using Cqrs.Demo.ConsoleApp.Entities;
using Cqrs.Demo.ConsoleApp.Infrastructure;
using System.Linq;

namespace Cqrs.Demo.ConsoleApp.Queries
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
