using api.Enums;

namespace api.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Email { get; set; } = string.Empty;
        public required UserRole Role { get; set; } = UserRole.User;
    }
}