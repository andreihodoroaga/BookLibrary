using BookLibraryBackend.Models.Base;

namespace BookLibraryBackend.Models
{
    public class Library : BaseEntity
    {
        public string Name { get; set; }
        public LibraryLocation Location { get; set; }
        public ICollection<BookLibrary> BookLibraries { get; set;}
    }
}
