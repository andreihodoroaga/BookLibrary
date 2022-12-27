using BookLibraryBackend.Models.Base;
using System.Text.Json.Serialization;

namespace BookLibraryBackend.Models
{
    public class Location : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Number { get; set; }
        [JsonIgnore]
        public Library? Library { get; set; }
    }
}
