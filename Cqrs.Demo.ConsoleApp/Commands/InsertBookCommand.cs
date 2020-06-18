using Cqrs.Demo.ConsoleApp.Cqrs;
using Cqrs.Demo.ConsoleApp.Entities;

namespace Cqrs.Demo.ConsoleApp.Commands
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
