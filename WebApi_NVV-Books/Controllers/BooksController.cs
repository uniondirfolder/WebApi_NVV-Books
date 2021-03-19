using Microsoft.AspNetCore.Mvc;
using WebApi_NVV_Books.Data.Services;
using WebApi_NVV_Books.Data.ViewModels;

namespace WebApi_NVV_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book) 
        {
            _booksService.AddBook(book);
            return Ok();
        }
    }
}
