using BookLibraryBackend.Models.Base;

namespace BookLibraryBackend.Models
{
    public class LibraryLocation : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Number { get; set; }
        public Library Library { get; set; }
        public Guid LibraryId { get; set; }
    }
}
