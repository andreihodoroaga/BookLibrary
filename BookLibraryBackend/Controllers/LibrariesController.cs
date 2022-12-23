using BookLibraryBackend.Models;
using BookLibraryBackend.Services.LibraryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        public ILibraryService _libraryService;

        [HttpGet]
        public async Task<List<Library>> GetLibraries()
        {
            return await _libraryService.GetAllLibraries();
        }

    }
}
