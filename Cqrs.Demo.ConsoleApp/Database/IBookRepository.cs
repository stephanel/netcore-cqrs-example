using Cqrs.Demo.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cqrs.Demo.ConsoleApp.Database
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();
        void Add(Book entity);
        void RemoveRange(IEnumerable<Book> books);
        void SaveChanges();
    }
}
