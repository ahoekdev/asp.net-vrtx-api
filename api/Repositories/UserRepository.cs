using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Entities;

namespace api.Repositories
{
  public class UserRepository(ApplicationDbContext context) : IUserRepository
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
      var user = await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException($"User with ID {id} not found.");
      return user;
    }

    public async Task AddAsync(User user)
    {
      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
      _context.Users.Update(user);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var user = await _context.Users.FindAsync(id);
      if (user != null)
      {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
      }
    }
  }
}
