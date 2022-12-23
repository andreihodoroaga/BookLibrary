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

                _context.Add(library1);
                _context.Add(library2);

                _context.SaveChanges();
            }
        }
    }
}
