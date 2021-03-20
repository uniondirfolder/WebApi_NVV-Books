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
    }
}
