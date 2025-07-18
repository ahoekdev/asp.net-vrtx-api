using api.Entities;
using api.Repositories;

namespace api.Services
{
    public class UserService(UserRepository repository)
    {
        private static readonly string notFoundMessage = "User not found";

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id) ?? throw new KeyNotFoundException(notFoundMessage);
        }

        public async Task<User> AddUserAsync(User entity)
        {
            return await repository.AddAsync(entity);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var entity = await repository.GetByIdAsync(id) ?? throw new KeyNotFoundException(notFoundMessage);

            await repository.DeleteAsync(entity.Id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await repository.GetByEmailAsync(email);
        }

        public async Task UpdateUserAsync(User entity)
        {
            await repository.UpdateAsync(entity);
        }
    }
}