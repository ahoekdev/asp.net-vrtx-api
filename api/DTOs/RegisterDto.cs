using System.ComponentModel.DataAnnotations;

namespace api.DTOs;

public class RegisterDto
{
  [Required(ErrorMessage = "Email is required.")]
  [EmailAddress(ErrorMessage = "Invalid email format.")]
  public required string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = "Password is required.")]
  [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
  public required string Password { get; set; } = string.Empty;
}