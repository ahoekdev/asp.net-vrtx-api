using System.ComponentModel.DataAnnotations;

namespace api.DTOs;

public class LoginDto
{
  [Required(ErrorMessage = "Email is required.")]
  public required string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = "Password is required.")]
  public required string Password { get; set; } = string.Empty;
}