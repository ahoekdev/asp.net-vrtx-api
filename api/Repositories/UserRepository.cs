using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Entities;
using api.Models;
using api.Enums;

namespace api.Repositories
{
  public class UserRepository(ApplicationDbContext context) : IUserRepository
  {
    public async Task<IEnumerable<User>> GetAllAsync()
    {
      return await context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
      return await context.Users.FindAsync(id) ?? throw new KeyNotFoundException($"User with ID {id} not found.");
    }

    public async Task<User> AddAsync(UserRequestDto dto)
    {
      var user = new User
      {
        Email = dto.Email,
        Role = UserRole.User,
        Password = dto.Password, // In a real application, ensure to hash the password before saving
      };

      await context.Users.AddAsync(user);
      await context.SaveChangesAsync();

      return user;
    }

    public async Task UpdateAsync(User user)
    {
      context.Users.Update(user);
      await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
      var user = await context.Users.FindAsync(id);
      if (user != null)
      {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
      }
    }
  }
}
