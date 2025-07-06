using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Entities;
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

            return await userService.AddUserAsync(new()
            {
                Email = dto.Email,
                Role = UserRole.Admin,
                PasswordHash = PasswordHash
            });
        }

        public async Task<string?> Login(LoginDto loginDto)
        {
            var user = await userService.GetUserByEmailAsync(loginDto.Email);

            if (user is null || !IsCorrectPassword(user, loginDto))
            {
                return null;
            }

            return CreateToken(user);
        }

        private static bool IsCorrectPassword(User user, LoginDto loginDto)
        {
            var result = passwordHasher.VerifyHashedPassword(new()
            {
                Email = loginDto.Email
            }, user.PasswordHash, loginDto.Password);

            return result != PasswordVerificationResult.Failed;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Email, user.Email),
                new (ClaimTypes.Role, user.Role.ToString())
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