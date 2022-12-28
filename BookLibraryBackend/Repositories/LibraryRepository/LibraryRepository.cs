using BookLibraryBackend.Data;
using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryBackend.Repositories.LibraryRepository
{
    public class LibraryRepository: GenericRepository<Library>, ILibraryRepository
    {
        public LibraryRepository(BooksLibraryContext context) : base(context) { }

        public IEnumerable<Library> GetLibraries()
        {
            return _context.Libraries.ToList();
        }

        public Library GetByName(string name)
        {
            return _table.FirstOrDefault(x => x.Name.ToLower().Trim().Equals(name.ToLower().Trim()));
        }

        public Library GetById(Guid id)
        {
            var library = _context.Libraries.FirstOrDefault(l => l.Id == id);
            return library;
        }

        public async Task<IEnumerable<Book>> GetBooksByLibraryId(Guid id)
        {
            var books = from book in _context.Books
                         join bookLibraries in _context.BookLibraries on book.Id equals bookLibraries.BookId
                         where bookLibraries.LibraryId == id
                         select book;

            return await books.ToListAsync();
        }

        public async Task<Location> GetLocationByLibraryId(Guid id)
        {
            var library = await FindByIdAsync(id);
            if(library != null)
            {
                var locationId = library.LocationId;
                var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == locationId);
                return location;
            }
            return null;
        }

        public async Task<Library> AddLibrary(LibraryDTO libraryDTO)
        {
            var library = new Library {
                Name = libraryDTO.Name, 
                Location = libraryDTO.Location 
            };
            await CreateAsync(library);
            await SaveAsync();
            return library;
        }

        public async Task<BookLibrary> AddBook(Guid libraryId, Guid bookId)
        {
            var library = await _context.Libraries
                .Where(l => l.Id == libraryId)
                .Include(l => l.BookLibraries)
                .FirstOrDefaultAsync();

            var book = await _context.Books.FindAsync(bookId);

            BookLibrary newBookLibrary = null;
            if(library != null && book != null)
            {
                newBookLibrary = new BookLibrary
                {
                    LibraryId = libraryId,
                    BookId = bookId,
                    Library = library,
                    Book = book
                };
                library.BookLibraries.Add(newBookLibrary);
                //await _context.BookLibraries.AddAsync(newBookLibrary); - alta varianta 
                await SaveAsync();
            }

            return newBookLibrary;
        }

        public async Task<Library> DeleteLibrary(Guid libraryId)
        {
            var library = await FindByIdAsync(libraryId);
            if (library != null)
            {
                Delete(library);
                await _context.SaveChangesAsync();
            }
            return library;
        }

        public async Task<Library> UpdateLibrary(Guid libraryId, LibraryDTO libraryDTO)
        {
            var library = FindById(libraryId);

            if (library != null)
            {
                library.Name = libraryDTO.Name;
                Update(library);
                await SaveAsync();
            }
            return library;
        }

        public bool LibraryExists(Guid id)
        {
            return _context.Libraries.Any(e => e.Id == id);
        }
    }
}
