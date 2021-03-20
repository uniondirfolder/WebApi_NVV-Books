using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_NVV_Books.Data.Models;
using WebApi_NVV_Books.Data.ViewModels;

namespace WebApi_NVV_Books.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM authorVM) 
        {
            var _author = new Author() { FullName = authorVM.FullName };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM  GetuthorWithBooks(int authorId) 
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Books_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }
    }
}
