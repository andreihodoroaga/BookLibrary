using BookLibraryBackend.Data;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Models;
using BookLibraryBackend.Repositories.BookRepository;
using BookLibraryBackend.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using BookLibraryBackend.Models.Enums;

namespace BookLibraryBackend.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BooksLibraryContext context) : base(context) { }

        public async Task<IEnumerable<BookWithAuthorDTO>> GetBooks()
        {
            var books = from book in _context.Books
                        join author in _context.Authors on book.AuthorId equals author.Id
                        select new BookWithAuthorDTO
                        {
                            Title = book.Title,
                            Description = book.Description,
                            PublishedDate = book.PublishedDate,
                            PageCount = book.PageCount,
                            Genre = book.Genre,
                            Rating = book.Rating,
                            AuthorName = author.Name
                        }; 

            return await books.ToListAsync();
        }

        public async Task<Book> GetBookById(Guid bookId)
        {
            return await FindByIdAsync(bookId);
        }

        public async Task AddBook(BookWithAuthorDTO bookDTO)
        {
            var authorId = _context.Authors.Single(x => x.Name == bookDTO.AuthorName).Id;

            var book = new Book
            {
                Title = bookDTO.Title,
                Description = bookDTO.Description,
                PublishedDate = bookDTO.PublishedDate,
                PageCount = bookDTO.PageCount,
                Genre = bookDTO.Genre,
                Rating = bookDTO.Rating,
                AuthorId = authorId
            };

            await CreateAsync(book);
            await SaveAsync();
        }

        public async Task<Book> DeleteBook(Guid bookId)
        {
            var book = await FindByIdAsync(bookId);
            if (book != null)
            {
                Delete(book);
                await _context.SaveChangesAsync();
            }
            return book;
        }

        public async Task<Book> UpdateBook(Guid bookId, BookDTO bookDTO)
        {
            var book = FindById(bookId);

            if (book != null)
            {
                book.Title = bookDTO.Title;
                book.Description = bookDTO.Description;
                book.PublishedDate = bookDTO.PublishedDate;
                book.PageCount = bookDTO.PageCount;
                book.Genre = bookDTO.Genre;
                book.Rating = bookDTO.Rating;
                book.AuthorId = bookDTO.AuthorId;
                Update(book);
                await SaveAsync();
            }
            return book;
        }

        public bool BookExists(Guid id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
