namespace BookLibraryBackend.Models
{
    public class BookLibrary
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
