using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.AuthorRepository;
using BookLibraryBackend.Repositories.LocationRepository;
using BookLibraryBackend.Services.LocationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorRepository.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetAuthorById(Guid id)
        {
            var author = _authorRepository.FindById(id);
            return Ok(author);
        }

        [HttpPost("addAuthor")]
        public async Task<ActionResult<AuthorDTO>> PostLibrary(AuthorDTO authorDTO)
        {
            try
            {
                if (authorDTO == null)
                    return BadRequest();
                await _authorRepository.AddAuthor(authorDTO);
                return Ok(authorDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new author record");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(Guid id, AuthorDTO authorDTO)
        {
            try
            {
                await _authorRepository.UpdateAuthor(id, authorDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_authorRepository.AuthorExists(id))
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
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var author = await _authorRepository.DeleteAuthor(id);
            if (author == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
