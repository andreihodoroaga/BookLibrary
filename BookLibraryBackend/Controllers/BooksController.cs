using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.BookRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.GetBooks();
            return Ok(books);
        }
        

        [HttpGet("byId/{id}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = _bookRepository.FindById(id);
            return Ok(book);
        }

        [HttpPost("addBook")]
        public async Task<ActionResult<BookDTO>> PostLibrary(BookDTO bookDTO)
        {
            try
            {
                if (bookDTO == null)
                    return BadRequest();
                await _bookRepository.AddBook(bookDTO);
                return Ok(bookDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new book record");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, BookDTO bookDTO)
        {
            try
            {
                await _bookRepository.UpdateBook(id, bookDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_bookRepository.BookExists(id))
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
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var book = await _bookRepository.DeleteBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
