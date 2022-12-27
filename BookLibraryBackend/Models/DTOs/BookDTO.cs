using BookLibraryBackend.Models.Enums;
using System.Text.Json.Serialization;

namespace BookLibraryBackend.Models.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int PageCount { get; set; }
        public Genre Genre { get; set; }
        public double Rating { get; set; }
        public Guid AuthorId { get; set; }
    }
}
