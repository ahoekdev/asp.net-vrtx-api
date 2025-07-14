using System.ComponentModel.DataAnnotations;

namespace api.DTOs;

public class LodgeDto
{
    [Required(ErrorMessage = "Name is required.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Country is required.")]
    public required string Country { get; set; }
}