using BookLibraryBackend.Data;
using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs;
using BookLibraryBackend.Repositories.GenericRepository;
using Microsoft.Identity.Client;

namespace BookLibraryBackend.Repositories.AuthorRepository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BooksLibraryContext context) : base(context) { }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await GetAllAsync();
        }

        public async Task<Author> GetAuthorById(Guid authorId)
        {
            return await FindByIdAsync(authorId);
        }

        public async Task AddAuthor(AuthorDTO authorDTO)
        {
            var author = new Author
            {
                Name = authorDTO.Name
            };
            await CreateAsync(author);
            await SaveAsync();
        }

        public async Task<Author> DeleteAuthor(Guid authorId)
        {
            var author = await FindByIdAsync(authorId);
            if (author != null)
            {
                Delete(author);
                await _context.SaveChangesAsync();
            }
            return author;
        }

        public async Task<Author> UpdateAuthor(Guid authorId, AuthorDTO authorDTO)
        {
            var author = FindById(authorId);

            if(author != null)
            {
                author.Name = authorDTO.Name;
                Update(author);
                await SaveAsync();
            }
            return author;
        }

        public bool AuthorExists(Guid id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
