using api.Entities;
using api.Enums;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Services
{
    public class AuthService(UserService userService)
    {
        private static readonly PasswordHasher<RegisterDto> passwordHasher = new();

        public async Task<User> Register(RegisterDto dto)
        {
            User user = new()
            {
                Email = dto.Email,
                Role = UserRole.User,
                PasswordHash = passwordHasher.HashPassword(dto, dto.Password),
            };


            return await userService.AddUserAsync(user);
        }

        public Task<string> Register(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

    }
}