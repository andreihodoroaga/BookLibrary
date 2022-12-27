using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.LocationRepository;

namespace BookLibraryBackend.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _locationRepository.GetAllAsync();
        }

        public async Task AddLocation(LocationDTO locationDTO)
        {
            await _locationRepository.AddLocation(locationDTO);
        }
    }
}
