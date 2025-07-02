using api.Entities;
using api.Models;

namespace api.Repositories
{
  public interface IUserRepository
  {
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(Guid id);
    Task<User> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
  }
}