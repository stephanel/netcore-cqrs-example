using CQS.Demo.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQS.Demo.ConsoleApp.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }
    }
}
