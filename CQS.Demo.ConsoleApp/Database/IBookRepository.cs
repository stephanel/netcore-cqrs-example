using CQS.Demo.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQS.Demo.ConsoleApp.Database
{
    public interface IBookRepository
    {
        void Add(Book entity);
        IQueryable<Book> GetAll();
        void SaveChanges();
    }
}
