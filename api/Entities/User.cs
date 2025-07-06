using api.Enums;

namespace api.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Email { get; set; } = string.Empty;
        public required string PasswordHash { get; set; } = string.Empty;
        public required UserRole Role { get; set; } = UserRole.User;
    }
}