using BookLibraryBackend.Data;
using BookLibraryBackend.Models;

namespace BookLibraryBackend.Helpers.Seeders
{
    public class LibrariesSeeder
    {
        public readonly BooksLibraryContext _context;

        public LibrariesSeeder(BooksLibraryContext context)
        {
            _context = context;
        }

        public void SeedIntialLibraries()
        {
            if (!_context.Libraries.Any())
            {
                var library1 = new Library
                {
                    Name = "Libraria numarul 1"
                };

                var library2 = new Library
                {
                    Name = "Libraria numarul 2"
                };

                var library3 = new Library
                {
                    Name = "Libraria numarul 3"
                };

                var library4 = new Library
                {
                    Name = "Libraria numarul 4"
                };

                var library5 = new Library
                {
                    Name = "Libraria numarul 5"
                };

                var library6 = new Library
                {
                    Name = "Libraria numarul 6"
                };

                List<Location> locations = new List<Location>
                {
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 1", Street = "Str", PostalCode = "020028", Number = "24", Library = library1 },
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 2", Street = "Strada Veche", PostalCode = "020028", Number = "102", Library = library2 },
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 3", Street = "Strada Noua", PostalCode = "020028", Number = "40", Library = library3 },
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 4", Street = "Strada", PostalCode = "020028", Number = "60", Library = library4 },
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 5", Street = "Street", PostalCode = "020028", Number = "2", Library = library5 },
                    new Location { City = "Bucharest", Country = "Romania", Region = "District 6", Street = "Iuliu Maniu", PostalCode = "020028", Number = "8", Library = library6 }
                };

                _context.AddRange(locations);
                _context.SaveChanges();
            }
        }
    }
}
