using System.ComponentModel.DataAnnotations;

namespace BookLibraryBackend.Models.DTOs.Users
{
    public class UserRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
