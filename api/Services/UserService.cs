using api.Entities;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class UserService(UserRepository userRepository)
    {
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await userRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("User not found");
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await userRepository.AddAsync(user);
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