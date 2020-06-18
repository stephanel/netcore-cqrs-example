using CQS.Demo.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQS.Demo.ConsoleApp.Database
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void Add(Book entity)
        {
            _context.Books.Add(entity);
        }

        public IQueryable<Book> GetAll()
        {
            return _context.Books.AsQueryable();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
