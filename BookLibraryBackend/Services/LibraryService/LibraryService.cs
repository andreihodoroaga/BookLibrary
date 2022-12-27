using BookLibraryBackend.Models;
using BookLibraryBackend.Repositories.LibraryRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryBackend.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public IEnumerable<Library> GetAllAsList()
        {
            return _libraryRepository.GetLibraries();
        }

        public Library GetByName(string name)
        {
            var lib = _libraryRepository.GetByName(name);
            return lib;
        }
    }
}
