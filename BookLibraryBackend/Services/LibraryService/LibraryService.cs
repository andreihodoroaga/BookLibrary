using BookLibraryBackend.Models;
using BookLibraryBackend.Repositories.LibraryRepository;

namespace BookLibraryBackend.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {
        public ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<List<Library>> GetAllLibraries()
        {
            return await _libraryRepository.GetAllAsync();
        }
    }
}
