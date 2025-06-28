using api.Entities;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Email = u.Email
            });

        }

        public async Task<UserResponseDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("User not found");

            return new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email
            };
        }

        public async Task<UserResponseDto> AddUserAsync(UserRequestDto dto)
        {
            var newUser = await _userRepository.AddAsync(dto);
            return new UserResponseDto
            {
                Id = newUser.Id,
                Email = newUser.Email
            };
        }

        public async Task UpdateUserAsync(Guid id, UserRequestDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("User not found");

            user.Email = userDto.Email;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("User not found");

            await _userRepository.DeleteAsync(id);
        }
    }
}