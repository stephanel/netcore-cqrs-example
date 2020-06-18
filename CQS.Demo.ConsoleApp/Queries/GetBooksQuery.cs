using CQS.Demo.ConsoleApp.Cqs;

namespace CQS.Demo.ConsoleApp.Queries
{
    public class GetBooksQuery : IQuery
    {
        public int? YearOfPublication { get; set; }
    }
}
