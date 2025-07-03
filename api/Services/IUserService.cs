using api.Entities;
using api.Models;

namespace api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto> GetUserByIdAsync(Guid id);

        Task<User?> GetUserByEmailAsync(string email);
        Task<UserResponseDto> AddUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }

}
