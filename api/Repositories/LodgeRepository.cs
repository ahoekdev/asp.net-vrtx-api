using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Entities;

namespace api.Repositories
{
    public class LodgeRepository(ApplicationDbContext context)
    {
        public async Task<IEnumerable<Lodge>> GetAllAsync()
        {
            return await context.Lodges.ToListAsync();
        }

        public async Task<Lodge> GetByIdAsync(Guid id)
        {
            return await context.Lodges.FindAsync(id) ?? throw new KeyNotFoundException($"Lodge with ID {id} not found.");
        }

        public async Task<Lodge> AddAsync(Lodge lodge)
        {
            await context.Lodges.AddAsync(lodge);
            await context.SaveChangesAsync();

            return lodge;
        }

        public async Task UpdateAsync(Lodge lodge)
        {
            context.Lodges.Update(lodge);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var lodge = await context.Lodges.FindAsync(id);
            if (lodge != null)
            {
                context.Lodges.Remove(lodge);
                await context.SaveChangesAsync();
            }
        }
    }
}
