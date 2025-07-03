using api.Entities;
using api.Enums;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IUserService usersService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> Register(RegisterDto dto)
        {
            var passwordHasher = new PasswordHasher<RegisterDto>();

            User user = new()
            {
                Email = dto.Email,
                Role = UserRole.User,
                PasswordHash = passwordHasher.HashPassword(dto, dto.Password),
            };

            var createdUser = await usersService.AddUserAsync(user);
            return Ok(createdUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto dto)
        {
            Console.WriteLine("TEST");
            var user = await usersService.GetUserByEmailAsync(dto.Email);

            if (user is null)
            {
                return BadRequest();
            }

            return user.Email;
        }
    }
}