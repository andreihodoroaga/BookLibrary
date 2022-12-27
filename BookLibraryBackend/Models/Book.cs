using BookLibraryBackend.Models.Base;
using BookLibraryBackend.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookLibraryBackend.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int PageCount { get; set; }
        public Genre Genre { get; set; }
        public double Rating { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        [JsonIgnore]
        public ICollection<BookLibrary>? BookLibraries { get; set; }
    }
}
