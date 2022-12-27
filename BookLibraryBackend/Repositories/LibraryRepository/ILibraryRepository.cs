using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.GenericRepository;

namespace BookLibraryBackend.Repositories.LibraryRepository
{
    public interface ILibraryRepository : IGenericRepository<Library>
    {
        public IEnumerable<Library> GetLibraries();
        public Library GetByName(string name);
        public Task<Location> GetLocationByLibraryId(Guid id);
        public Task<Library> AddLibrary(LibraryDTO libraryDTO);
    }
}
