using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;

namespace BookLibraryBackend.Services.LocationService
{
    public interface ILocationService
    {
        public Task<IEnumerable<Location>> GetLocations();
        public Task AddLocation(LocationDTO locationDTO);
    }
}
