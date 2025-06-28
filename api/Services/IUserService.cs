using api.Models;

namespace api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto> GetUserByIdAsync(Guid id);
        Task<UserResponseDto> AddUserAsync(UserRequestDto userDto);
        Task UpdateUserAsync(Guid id, UserRequestDto userDto);
        Task DeleteUserAsync(Guid id);
    }

}
