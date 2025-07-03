using api.Entities;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();

            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Email = u.Email,
                Role = u.Role
            });

        }

        public async Task<UserResponseDto> GetUserByIdAsync(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("User not found");

            return new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<UserResponseDto> AddUserAsync(User user)
        {
            var newUser = await userRepository.AddAsync(user);

            return new UserResponseDto
            {
                Id = newUser.Id,
                Email = newUser.Email,
                Role = newUser.Role
            };
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("User not found");

            await userRepository.DeleteAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await userRepository.GetByEmailAsync(email);
        }
    }
}