using Cqrs.Demo.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Demo.ConsoleApp
{
    class Books
    {
        public static Book ExtremeProgrammingExplained = new Book()
        {
            Authors = "Kent Beck",
            Title = "Extreme Programming Explained: Embrace Change (2nd edition)",
            DatePublished = new DateTime(2004, 11, 16),
        };

        public static Book ThePragmaticProgammer = new Book()
        {
            Authors = "Andrew Hunt, David Thomas",
            Title = "The Pragmatic Programmer",
            DatePublished = new DateTime(1999, 10, 20),
        };

        public static Book TheCleanCoder = new Book()
        {
            Authors = "Robert C. Martin",
            Title = "The Clean Coder: A Code of Conduct for Professional Programmers",
            DatePublished = new DateTime(2011, 05, 13),
        };

        public static Book Refactoring = new Book()
        {
            Authors = "Martin Fowler, Kent Beck & alt.",
            Title = "Refactoring - Improving the Design of Existing Code",
            DatePublished = new DateTime(1999, 06, 30),
        };
    }
}
