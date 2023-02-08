using BookLibraryBackend.Data;
using BookLibraryBackend.Helpers.Attributes;
using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Models.Enums;
using BookLibraryBackend.Repositories.LibraryRepository;
using BookLibraryBackend.Services.LibraryService;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("byName/{name}")]
        public IActionResult GetLibraryByName(string name)
        {
            var library = _libraryService.GetByName(name);
            return Ok(library);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetLibraryById(Guid id)
        {
            var library = _libraryRepository.GetById(id);
            return Ok(library);
        }

        [HttpGet("location/{libraryId}")]
        public async Task<IActionResult> GetLocationByLibraryId(Guid libraryId)
        {
            var location = await _libraryRepository.GetLocationByLibraryId(libraryId);
            return Ok(location);
        }

        [HttpGet("books/{libraryId}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByLibraryId(Guid libraryId)
        {
            var books = await _libraryRepository.GetBooksByLibraryId(libraryId);
            return Ok(books);
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

        [HttpPost("addBook")]
        public async Task<ActionResult<BookLibrary>> PostBook(Guid libraryId, Guid bookId)
        {
            try
            {
                var bookLibrary = await _libraryRepository.AddBook(libraryId, bookId);
                return Ok(bookLibrary);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new book record");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrary(Guid id, LibraryDTO libraryDTO)
        {
            try
            {
                await _libraryRepository.UpdateLibrary(id, libraryDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_libraryRepository.LibraryExists(id))
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

        [Authorization(Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrary(Guid id)
        {
            var library = await _libraryRepository.DeleteLibrary(id);
            if (library == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
