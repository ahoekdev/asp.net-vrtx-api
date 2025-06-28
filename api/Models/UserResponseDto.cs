using api.Enums;

namespace api.Models;

public class UserResponseDto
{
  public Guid Id { get; set; }
  public string Email { get; set; } = string.Empty;

  public UserRole Role { get; set; } = UserRole.User;
}