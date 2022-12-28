using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.GenericRepository;

namespace BookLibraryBackend.Repositories.LibraryRepository
{
    public interface ILibraryRepository : IGenericRepository<Library>
    {
        public IEnumerable<Library> GetLibraries();
        public Library GetByName(string name);
        public Library GetById(Guid id);    
        public Task<Location> GetLocationByLibraryId(Guid id);
        public Task<Library> AddLibrary(LibraryDTO libraryDTO);
        public Task<IEnumerable<Book>> GetBooksByLibraryId(Guid id);
        public Task<BookLibrary> AddBook(Guid libraryId, Guid bookId);
        public Task<Library> DeleteLibrary(Guid libraryId);
        public Task<Library> UpdateLibrary(Guid libraryId, LibraryDTO libraryDTO);
        public bool LibraryExists(Guid id);
    }
}
