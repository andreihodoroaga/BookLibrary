using BookLibraryBackend.Models.Enums;

namespace BookLibraryBackend.Models.DTOs
{
    public class BookGenreStatisticsDTO
    {
        public Genre Genre { get; set; }
        public double AveragePageCount { get; set; }
        public double AverageRating { get; set; }
    }
}
