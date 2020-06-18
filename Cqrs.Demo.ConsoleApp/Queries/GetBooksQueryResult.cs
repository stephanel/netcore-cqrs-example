using Cqrs.Demo.ConsoleApp.Cqrs;
using Cqrs.Demo.ConsoleApp.Entities;
using System.Collections.Generic;

namespace Cqrs.Demo.ConsoleApp.Queries
{
    public class GetBooksQueryResult : IResult
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
