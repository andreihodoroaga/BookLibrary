using BookLibraryBackend.Data;
using BookLibraryBackend.Models;

namespace BookLibraryBackend.Helpers.Seeders
{
    public class LibraryLocationsSeeder
    {
        public readonly BooksLibraryContext _context;

        public LibraryLocationsSeeder(BooksLibraryContext context)
        {
            _context = context;
        }

        public void SeedInitialLibraryLocations()
        {
            if (!_context.Locations.Any())
            {

                List<Location> locations = new List<Location>
                {
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 1", Street = "Str", PostalCode = "020028", Number = "24" },
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 2", Street = "Strada Veche", PostalCode = "020028", Number = "102" },
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 3", Street = "Strada Noua", PostalCode = "020028", Number = "40" },
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 4", Street = "Strada", PostalCode = "020028", Number = "60" },
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 5", Street = "Street", PostalCode = "020028", Number = "2" },
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 6", Street = "Iuliu Maniu", PostalCode = "020028", Number = "8" }
                };

                foreach(var location in locations)
                {
                    _context.Add(location);
                }

                _context.SaveChanges();
            }
        }
    }
}
