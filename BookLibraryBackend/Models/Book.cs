using BookLibraryBackend.Models.Base;
using BookLibraryBackend.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibraryBackend.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int PageCount { get; set; }
        public Genre Genre { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Rating { get; set; }
        public ICollection<BookLibrary> BookLibraries { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
