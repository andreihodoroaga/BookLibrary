using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Models;
using BookLibraryBackend.Repositories.GenericRepository;

namespace BookLibraryBackend.Repositories.BookRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<BookWithAuthorDTO>> GetBooks();
        Task<Book> GetBookById(Guid bookId);
        Task AddBook(BookDTO bookDTO);
        Task<Book> DeleteBook(Guid bookId);
        Task<Book> UpdateBook(Guid bookId, BookDTO bookDTO);
        public bool BookExists(Guid id);
    }
}
