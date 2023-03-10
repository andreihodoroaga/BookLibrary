using BookLibraryBackend.Models;
using BookLibraryBackend.Models.DTOs.Users;

namespace BookLibraryBackend.Services.Users
{
    public interface IUsersService
    {
        UserResponseDto Authenticate(UserRequestDto model);
        Task<List<User>> GetAllUsers();
        User GetById(Guid id);
        Task Create(User newUser);
    }
}
