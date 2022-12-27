using BookLibraryBackend.Data;
using BookLibraryBackend.Models;

namespace BookLibraryBackend.Helpers.Seeders
{
    public class AuthorsSeeder
    {
        public readonly BooksLibraryContext _context;

        public AuthorsSeeder(BooksLibraryContext context)
        {
            _context = context;
        }

        public void SeedInitialAuthors()
        {
            List<Author> authors = new List<Author>
            {
                new Author { Name = "Frank Herbert" },
                new Author { Name = "J.K. Rowling" },
                new Author { Name = "Robert C. Martin" },
                new Author { Name = "Yuval Noah Harari" },
                new Author { Name = "Stephen Hawking" },
                new Author { Name = "Liviu Rebreanu" },
                new Author { Name = "Tara Westover" },
                new Author { Name = "Mihai Eminescu" }
            };

            foreach (var author in authors)
            {
                _context.Add(author);
            }

            _context.SaveChanges();
        }
    }
}
