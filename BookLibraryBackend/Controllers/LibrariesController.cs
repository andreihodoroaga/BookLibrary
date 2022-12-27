using BookLibraryBackend.Data;
using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.LibraryRepository;
using BookLibraryBackend.Services.LibraryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly ILibraryRepository _libraryRepository;

        public LibrariesController(ILibraryService libraryService, ILibraryRepository libraryRepository) {
            _libraryService = libraryService;
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public IActionResult GetLibraries()
        {
            var libraries = _libraryService.GetAllAsList();
            return Ok(libraries);
        }

        [HttpGet("{name}")]
        public IActionResult GetLibraryByName(string name)
        {
            var library = _libraryService.GetByName(name);
            return Ok(library);
        }

        [HttpGet("location/{libraryId}")]
        public async Task<IActionResult> GetLocationByLibraryId(Guid libraryId)
        {
            var location = await _libraryRepository.GetLocationByLibraryId(libraryId);
            return Ok(location);
        }

        [HttpPost("addLibrary")]
        public async Task<ActionResult<Library>> PostLibrary(LibraryDTO libraryDTO)
        {
            try
            {
                if (libraryDTO == null)
                    return BadRequest();
                var library = await _libraryRepository.AddLibrary(libraryDTO);
                return Ok(library);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new library record");
            }

        }

    }
}
