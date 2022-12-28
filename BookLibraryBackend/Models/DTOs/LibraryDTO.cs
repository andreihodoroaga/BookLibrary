using System.Text.Json.Serialization;

namespace BookLibraryBackend.Models.DTOs
{
    public class LibraryDTO
    {
        public string Name { get; set; } 
        public LocationDTO LocationDTO { get; set; }
    }
}
