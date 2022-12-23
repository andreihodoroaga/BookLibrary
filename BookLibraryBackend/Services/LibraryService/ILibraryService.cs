using BookLibraryBackend.Models;

namespace BookLibraryBackend.Services.LibraryService
{
    public interface ILibraryService
    {
        Task<List<Library>> GetAllLibraries();
    }
}
