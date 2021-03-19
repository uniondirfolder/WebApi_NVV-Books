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

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks() 
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book) 
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdatebookById(int id, [FromBody]BookVM book) 
        {
            var updateBook = _booksService.UpdateBookById(id, book);
            return Ok(updateBook);
        }
    }
}
