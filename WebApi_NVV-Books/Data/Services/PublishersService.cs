using System;
using System.Linq;
using System.Text.RegularExpressions;
using WebApi_NVV_Books.Data.Models;
using WebApi_NVV_Books.Data.ViewModels;
using WebApi_NVV_Books.Exception;

namespace WebApi_NVV_Books.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _appDbContext;

        public PublishersService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Publisher AddPublisher(PublisherVM  publisherVM)
        {
            if (StringStartsWithNumber(publisherVM.Name)) throw new PublisherNameException("Name starts with number", publisherVM.Name);

            var _publisher = new Publisher() { Name = publisherVM.Name };
            _appDbContext.Publishers.Add(_publisher);
            _appDbContext.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherById(int id) => _appDbContext.Publishers.FirstOrDefault(n => n.Id == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId) 
        {
            var _publisherData = _appDbContext.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM() 
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName=n.Title,
                        BookAuthors = n.Books_Authors.Select(n=>n.Author.FullName).ToList()
                    }).ToList()
            }).FirstOrDefault();

            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _appDbContext.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher != null) 
            {
                _appDbContext.Publishers.Remove(_publisher);
                _appDbContext.SaveChanges();
            }
            else
            {
                throw new System.Exception($"The publisher with id: {id} does not exist");
            }
        }

        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));

    }
}
