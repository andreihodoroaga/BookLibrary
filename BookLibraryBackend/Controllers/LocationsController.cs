using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.LocationRepository;
using BookLibraryBackend.Services.LocationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
    
namespace BookLibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILocationRepository _locationRepository;

        public LocationsController(ILocationService locationService, ILocationRepository locationRepository)
        {
            _locationService = locationService;
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _locationService.GetLocations();
            return Ok(locations);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetLocationById(Guid id)
        {
            var location = _locationRepository.FindById(id);
            return Ok(location);
        }

        [HttpPost("addLocation")]
        public async Task<ActionResult<LocationDTO>> PostLibrary(LocationDTO locationDTO)
        {
            try
            {
                if (locationDTO == null)
                    return BadRequest();
                await _locationService.AddLocation(locationDTO);
                return Ok(locationDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new location record");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(Guid id, LocationDTO locationDTO)
        {
            try
            {
               await _locationRepository.UpdateLocation(id, locationDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_locationRepository.LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {
            var location = await _locationRepository.DeleteLocation(id);
            if (location == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
