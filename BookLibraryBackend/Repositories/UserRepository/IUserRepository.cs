using BookLibraryBackend.Models;
using BookLibraryBackend.Repositories.GenericRepository;

namespace BookLibraryBackend.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User FindByUsername(string username);   
    }
}
