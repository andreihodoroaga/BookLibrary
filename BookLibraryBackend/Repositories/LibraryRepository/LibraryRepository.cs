using BookLibraryBackend.Data;
using BookLibraryBackend.Models;
using BookLibraryBackend.Repositories.GenericRepository;

namespace BookLibraryBackend.Repositories.LibraryRepository
{
    public class LibraryRepository: GenericRepository<Library>, ILibraryRepository
    {
        public LibraryRepository(BooksLibraryContext context) : base(context) { }
    }
}
