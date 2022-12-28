using BookLibraryBackend.Models;

namespace BookLibraryBackend.Helpers.Jwt
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
