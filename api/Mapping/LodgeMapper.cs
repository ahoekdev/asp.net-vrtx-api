using api.DTOs;
using api.Entities;

namespace api.Mapping
{
    public class LodgeMapper
    {
        public static Lodge ToEntity(LodgeDto dto)
        {
            return new()
            {
                Name = dto.Name,
                Country = dto.Country
            };
        }
    }
}