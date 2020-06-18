using Autofac;
using CQS.Demo.ConsoleApp.Cqs;
using CQS.Demo.ConsoleApp.Commands;
using CQS.Demo.ConsoleApp.Database;
using CQS.Demo.ConsoleApp.Entities;
using CQS.Demo.ConsoleApp.Infrastructure;
using CQS.Demo.ConsoleApp.Queries;
using System;
using System.Linq;

namespace CQS.Demo.ConsoleApp
{
    class Program
    {
        static ILogger _logger;        

        static void Main(string[] args)
        {
            var _container = Bootstrapper.Bootstrap();
            _logger = _container.Resolve<ILogger>();

            LogInfo("Bootsrapping application..");
            WithoutCqs(_container);
            WithCqs(_container);
            System.Console.ReadLine();
        }

        private static void WithoutCqs(IContainer container)
        {
            LogInfo("Without CQS...");

            //resolve context
            var _context = container.Resolve<ApplicationDbContext>();

            //save some books if there are none in the database
            if (!_context.Books.Any())
            {
                _context.Books.Add(Books.ExtremeProgrammingExplained);
                _context.Books.Add(Books.ThePragmaticProgammer);
                _context.Books.Add(Books.TheCleanCoder);
                _context.Books.Add(Books.Refactoring);

                _context.SaveChanges();

                LogInfo("Books saved!");
            }

            LogInfo("Get all books...");

            foreach (var _book in _context.Books)
            {
                LogBook(_book);
            }

            LogInfo("Get books published in 2004...");

            var booksResults = _context.Books.Where(book => book.DatePublished.Year == 2004);

            foreach (var _book in booksResults)
            {
                LogBook(_book);
            }

            _context.Books.RemoveRange(_context.Books);
            _context.SaveChanges();
        }

        private static void WithCqs(IContainer container)
        {
            LogInfo("Using CQS...");

            var _commandDispatcher = container.Resolve<ICommandDispatcher>();

            _commandDispatcher.Dispatch<InsertBookCommand>(new InsertBookCommand(Books.ExtremeProgrammingExplained));
            _commandDispatcher.Dispatch<InsertBookCommand>(new InsertBookCommand(Books.ThePragmaticProgammer));
            _commandDispatcher.Dispatch<InsertBookCommand>(new InsertBookCommand(Books.TheCleanCoder));
            _commandDispatcher.Dispatch<InsertBookCommand>(new InsertBookCommand(Books.Refactoring));

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

        static void LogInfo(string message) => _logger.Info(message);
        
        static void LogBook(Book book)
            => _logger.Info("Title: {0}, Authors: {1}, DatePublished: {2:MM/dd/yyyy}", book.Title, book.Authors, book.DatePublished);
    }
}
