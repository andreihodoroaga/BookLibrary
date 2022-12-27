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
    }
}
