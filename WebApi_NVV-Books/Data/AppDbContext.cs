using Microsoft.EntityFrameworkCore;
using WebApi_NVV_Books.Data.Models;

namespace WebApi_NVV_Books.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Books_Authors>()
                .HasOne(book => book.Book)
                .WithMany(authors => authors.Books_Authors)
                .HasForeignKey(bookId => bookId.BookId);

            modelBuilder.Entity<Books_Authors>()
                .HasOne(author => author.Author)
                .WithMany(book => book.Books_Authors)
                .HasForeignKey(authorId => authorId.AuthorId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Books_Authors> Books_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }
}
