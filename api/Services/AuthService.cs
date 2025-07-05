using api.Entities;
using api.Enums;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

class ApplicationUser
{
    public string Email { get; set; } = String.Empty;
}

namespace api.Services
{
    public class AuthService(UserService userService)
    {
        private static readonly PasswordHasher<ApplicationUser> passwordHasher = new();

        public async Task<User> Register(RegisterDto dto)
        {
            string PasswordHash = passwordHasher.HashPassword(new()
            {
                Email = dto.Email
            }, dto.Password);

            User user = new()
            {
                Email = dto.Email,
                Role = UserRole.User,
                PasswordHash = PasswordHash
            };


            return await userService.AddUserAsync(user);
        }

        public async Task<User?> Login(LoginDto loginDto)
        {
            var user = await userService.GetUserByEmailAsync(loginDto.Email);

            if (user is null)
            {
                return null;
            }


            var result = passwordHasher.VerifyHashedPassword(new()
            {
                Email = loginDto.Email
            }, user.PasswordHash, loginDto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return user;
        }

    }
}