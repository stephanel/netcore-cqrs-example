using CQS.Demo.ConsoleApp.Cqs;
using CQS.Demo.ConsoleApp.Entities;

namespace CQS.Demo.ConsoleApp.Commands
{
    public class InsertBookCommand : ICommand
    {
        public Book Book { get; private set; }

        public InsertBookCommand(Book book)
        {
            Book = book;
        }
    }
}
