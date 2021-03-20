using System.Collections.Generic;

namespace WebApi_NVV_Books.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksAndAuthorsVM
    {
        public string Name { get; set; }
        public List<BookAuthorVM> BookAuthors { get; set; }
    }

    public class BookAuthorVM 
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
