using BookLibraryBackend.Data;
using BookLibraryBackend.Models;
using BookLibraryBackend.Models.Enums;

namespace BookLibraryBackend.Helpers.Seeders
{
    public class BooksSeeder
    {
        public readonly BooksLibraryContext _context;

        public BooksSeeder(BooksLibraryContext context)
        {
            _context = context;
        }

        public void SeedInitialBooks()
        {
            if (!_context.Books.Any())
            {

                List<Book> books = new List<Book>
                {
                    new Book { Title = "Dune", Description = "book", PublishedDate = new DateTime(1965, 8, 1), PageCount = 500,  Genre=Genre.ScienceFiction, Rating=4.3 },
                    new Book { Title = "Harry Potter", Description = "book", PublishedDate = new DateTime(1997, 6, 27), PageCount =450,  Genre=Genre.ScienceFiction, Rating=4.5 },
                    new Book { Title = "Clean Code", Description = "book", PublishedDate = new DateTime(2008, 8, 1), PageCount = 300,  Genre=Genre.Technology, Rating=4.2 },
                    new Book { Title = "Sapiens", Description = "book", PublishedDate = new DateTime(2011, 2, 1), PageCount = 443,  Genre=Genre.History, Rating=4.4 },
                    new Book { Title = "The Universe in a Nutshell", Description = "book", PublishedDate = new DateTime(2001, 1, 1), PageCount = 219,  Genre=Genre.Science, Rating=4.0 },
                    new Book { Title = "Ion", Description = "book", PublishedDate = new DateTime(1920, 2, 1), PageCount = 501,  Genre=Genre.Fantasy, Rating=3.4 },
                    new Book { Title = "Educated", Description = "book", PublishedDate = new DateTime(2018, 2, 18), PageCount = 340,  Genre=Genre.Biography, Rating=4.5 }
                };

                foreach(var book in books)
                {
                    _context.Add(book);
                }

                _context.SaveChanges();
            }
        }
    }
}
