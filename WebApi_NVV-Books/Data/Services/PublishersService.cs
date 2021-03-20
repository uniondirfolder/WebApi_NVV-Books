using WebApi_NVV_Books.Data.Models;
using WebApi_NVV_Books.Data.ViewModels;

namespace WebApi_NVV_Books.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _appDbContext;

        public PublishersService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddPublisher(PublisherVM  publisherVM)
        {
            var _publisher = new Publisher() { Name = publisherVM.Name };
            _appDbContext.Publishers.Add(_publisher);
            _appDbContext.SaveChanges();
        }
    }
}
