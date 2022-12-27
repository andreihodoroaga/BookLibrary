using BookLibraryBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryBackend.Services.LibraryService
{
    public interface ILibraryService
    {
        IEnumerable<Library> GetAllAsList();
        Library GetByName(string name);
    }
}
