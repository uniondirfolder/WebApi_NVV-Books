using Microsoft.EntityFrameworkCore;
using WebApi_NVV_Books.Data.Models;

namespace WebApi_NVV_Books.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
