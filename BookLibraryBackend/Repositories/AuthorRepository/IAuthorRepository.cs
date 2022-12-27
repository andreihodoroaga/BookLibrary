using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.GenericRepository;

namespace BookLibraryBackend.Repositories.AuthorRepository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthorById(Guid authorId);
        Task AddAuthor(AuthorDTO authorDTO);
        Task<Author> DeleteAuthor(Guid authorId);
        Task<Author> UpdateAuthor(Guid authorId, AuthorDTO authorDTO);
        public bool AuthorExists(Guid id);
    }
}
