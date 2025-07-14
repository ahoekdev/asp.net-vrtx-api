
using api.DTOs;
using api.Entities;

namespace api.Mapping
{
    public class UserMapper
    {
        public static UserResponseDto ToDto(User user)
        {
            return new()
            {
                Id = user.Id,
                Email = user.Email
            };
        }

        public static List<UserResponseDto> ToListDto(IEnumerable<User> users)
        {
            return [.. users.Select(ToDto)];
        }
    }
}