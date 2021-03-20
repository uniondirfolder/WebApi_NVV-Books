namespace WebApi_NVV_Books.Data.Models
{
    public class Books_Authors
    {
        public int Id { get; set; }

        //Navigations Properties
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
