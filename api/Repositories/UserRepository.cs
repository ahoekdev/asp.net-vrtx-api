using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Entities;
using api.Models;
using api.Enums;

namespace api.Repositories
{
  public class UserRepository(ApplicationDbContext context) : IUserRepository
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
      return await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException($"User with ID {id} not found.");
    }

    public async Task<User> AddAsync(UserRequestDto dto)
    {
      var user = new User
      {
        Email = dto.Email,
        Role = UserRole.User,
        Password = dto.Password, // In a real application, ensure to hash the password before saving
      };

      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();

      return user;
    }

    public async Task UpdateAsync(User user)
    {
      _context.Users.Update(user);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
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
