using api.Entities;
using api.Repositories;

namespace api.Services
{

    public class LodgeService(LodgeRepository repository)
    {
        private static readonly string notFoundMessage = "Lodge not found";

        public async Task<IEnumerable<Lodge>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Lodge> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id) ?? throw new KeyNotFoundException(notFoundMessage);
        }

        public async Task<Lodge> AddAsync(Lodge entity)
        {
            return await repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await repository.GetByIdAsync(id) ?? throw new KeyNotFoundException(notFoundMessage);
            await repository.DeleteAsync(entity.Id);
        }

        public async Task UpdateAsync(Lodge entity)
        {
            await repository.UpdateAsync(entity);
        }
    }
}