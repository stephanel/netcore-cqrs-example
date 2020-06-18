using Cqrs.Demo.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Demo.ConsoleApp.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }
    }
}
