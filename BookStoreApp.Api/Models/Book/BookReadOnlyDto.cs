namespace BookStoreApp.Api.Models.Book
{
    public class BookReadOnlyDto : BaseDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Isbn { get; set; }
        public string Summary { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public string Authorname { get; set; }
    }
}
