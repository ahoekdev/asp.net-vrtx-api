using api.Enums;

namespace api.Models;

public class UserResponseDto
{
  public required Guid Id { get; set; }
  public required string Email { get; set; } = string.Empty;
  public required UserRole Role { get; set; } = UserRole.User;
}