using api.Models;

namespace api.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto> GetUserByIdAsync(int id);
        Task AddUserAsync(UserRequestDto userDto);
        Task UpdateUserAsync(int id, UserRequestDto userDto);
        Task DeleteUserAsync(int id);
    }

}
