using Cqrs.Demo.ConsoleApp.Cqrs;

namespace Cqrs.Demo.ConsoleApp.Queries
{
    public class GetBooksQuery : IQuery
    {
        public int? YearOfPublication { get; set; }
    }
}
