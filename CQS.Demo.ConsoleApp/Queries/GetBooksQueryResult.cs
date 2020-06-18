using CQS.Demo.ConsoleApp.Cqs;
using CQS.Demo.ConsoleApp.Entities;
using System.Collections.Generic;

namespace CQS.Demo.ConsoleApp.Queries
{
    public class GetBooksQueryResult : IResult
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
