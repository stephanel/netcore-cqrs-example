using Autofac;
using Cqrs.Demo.ConsoleApp.Cqrs;
using Cqrs.Demo.ConsoleApp.Commands;
using Cqrs.Demo.ConsoleApp.Database;
using Cqrs.Demo.ConsoleApp.Entities;
using Cqrs.Demo.ConsoleApp.Extensions;
using Cqrs.Demo.ConsoleApp.Infrastructure;
using Cqrs.Demo.ConsoleApp.Queries;
using System;
using System.Linq;

namespace Cqrs.Demo.ConsoleApp
{
    class Program
    {
        static ILogger _logger;        

        static void Main(string[] args)
        {
            var _container = Bootstrapper.Bootstrap();
            _logger = _container.Resolve<ILogger>();

            LogInfo("Application started!");
            WithoutCqrs(_container);
            LogEmptyLine();
            UsingCqrs(_container);
            System.Console.ReadLine();
        }

        private static void WithoutCqrs(IContainer container)
        {
            LogInfo("Without CQRS...");

            //resolve context
            var repository = container.Resolve<IBookRepository>();

            var allBooks = repository.GetAll();

            //save some books if there are none in the database
            if (!allBooks.Any())
            {
                LogInfo("Inserting books...");

                repository.Add(Books.ExtremeProgrammingExplained);
                repository.Add(Books.ThePragmaticProgammer);
                repository.Add(Books.TheCleanCoder);
                repository.Add(Books.Refactoring);

                repository.SaveChanges();

                LogInfo("Books saved!");
            }

            LogInfo("Get all books...");

            foreach (var _book in allBooks)
            {
                LogBook(_book);
            }

            LogInfo("Get books published in 2004...");

            var booksResults = allBooks.Where(book => book.DatePublished.Year == 2004);

            foreach (var _book in booksResults)
            {
                LogBook(_book);
            }

            repository.RemoveRange(allBooks);
            repository.SaveChanges();
        }

        private static void UsingCqrs(IContainer container)
        {
            LogInfo("Using CQRS...");

            var _commandDispatcher = container.Resolve<ICommandDispatcher>();

            LogInfo("Inserting books...");

            _commandDispatcher.Dispatch(new InsertBookCommand(Books.ExtremeProgrammingExplained));
            _commandDispatcher.Dispatch(new InsertBookCommand(Books.ThePragmaticProgammer));
            _commandDispatcher.Dispatch(new InsertBookCommand(Books.TheCleanCoder));
            _commandDispatcher.Dispatch(new InsertBookCommand(Books.Refactoring));

            LogInfo("Books saved!");

            LogInfo("Get all books...");

            var _queryDispatcher = container.Resolve<IQueryDispatcher>();
            var _reponse = _queryDispatcher.Dispatch<GetBooksQuery, GetBooksQueryResult>(new GetBooksQuery());

            foreach (var _book in _reponse.Books)
            {
                LogBook(_book);
            }

            LogInfo("Get books published in 2004...");
            var _reponse2 = _queryDispatcher.Dispatch<GetBooksQuery, GetBooksQueryResult>(new GetBooksQuery() { YearOfPublication = 2004 });

            foreach (var _book in _reponse2.Books)
            {
                LogBook(_book);
            }
        }

        static void LogEmptyLine() => _logger.Info("\r\n");
        static void LogInfo(string message) => _logger.Info(message);
        
        static void LogBook(Book book)
            => _logger.Info("Title: {0}, Authors: {1}, DatePublished: {2:MM/dd/yyyy}",
                book.Title.WithEllipsis(30), book.Authors, book.DatePublished);
    }
}
