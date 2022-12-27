using BookLibraryBackend.Data;
using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.GenericRepository;
using BookLibraryBackend.Repositories.LocationRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryBackend.Repositories.LocationRepository
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(BooksLibraryContext context) : base(context) { }
        
        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await GetAllAsync();
        }

        public Task<Location> GetLocation(Guid locationId)
        {
            throw new NotImplementedException();
        }


        public async Task AddLocation(LocationDTO locationDTO)
        {
            var location = new Location
            {
                Street = locationDTO.Street,
                City = locationDTO.City,
                Region = locationDTO.Region,
                PostalCode = locationDTO.PostalCode,
                Country = locationDTO.Country,
                Number = locationDTO.Number
            };
            await CreateAsync(location);
            await SaveAsync();
        }

        public async Task<Location> DeleteLocation(Guid locationId)
        {
            var location = await FindByIdAsync(locationId);
            if (location != null)
            {
                Delete(location);
                await _context.SaveChangesAsync();
            }
            return location;
        }

        public async Task<Location> UpdateLocation(Guid locationId, LocationDTO locationDTO)
        {
            var location = FindById(locationId);

            location.Street = locationDTO.Street;
            location.City = locationDTO.City;
            location.Region = locationDTO.Region;
            location.PostalCode = locationDTO.PostalCode;
            location.Country = locationDTO.Country;
            location.Number = locationDTO.Number;

            await SaveAsync();
            return location;
        }

        public bool LocationExists(Guid id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }
    }
}
