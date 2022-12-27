using BookLibraryBackend.Models.Base;
using System.Text.Json.Serialization;

namespace BookLibraryBackend.Models
{
    public class Library : BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public Location Location { get; set; }
        public Guid LocationId { get; set; }
        [JsonIgnore]
        public ICollection<BookLibrary>? BookLibraries { get; set;}
    }
}
