using BookLibraryBackend.Data;
using BookLibraryBackend.Models;
using BookLibraryBackend.Repositories.GenericRepository;

namespace BookLibraryBackend.Repositories.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(BooksLibraryContext context): base(context)
        {

        }

        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.Username == username);
        }
    }
}
