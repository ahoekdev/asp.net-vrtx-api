using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Entities;
using api.Enums;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

class ApplicationUser
{
    public string Email { get; set; } = string.Empty;
}

namespace api.Services
{
    public class AuthService(IConfiguration configuraton, UserService userService)
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

        public async Task<string?> Login(LoginDto loginDto)
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

            return CreateToken(user);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuraton.GetValue<string>("AppSettings:Token")!)
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuraton.GetValue<string>("AppSettings:Issuer"),
                audience: configuraton.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}