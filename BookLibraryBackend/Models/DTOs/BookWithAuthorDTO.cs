using BookLibraryBackend.Models.Enums;

namespace BookLibraryBackend.Models.DTOs
{
    public class BookWithAuthorDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int PageCount { get; set; }
        public Genre Genre { get; set; }
        public double Rating { get; set; }
        public string AuthorName { get; set; }
    }
}
