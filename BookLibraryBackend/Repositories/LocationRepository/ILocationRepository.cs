using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.GenericRepository;

namespace BookLibraryBackend.Repositories.LocationRepository
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location> GetLocation(Guid locationId);
        Task AddLocation(LocationDTO locationDTO);
        Task<Location> DeleteLocation(Guid locationId);
        Task<Location> UpdateLocation(Guid locationId, LocationDTO locationDTO);
        bool LocationExists(Guid id);
    }
}
