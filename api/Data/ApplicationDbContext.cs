using Microsoft.EntityFrameworkCore;
using api.Entities;

namespace api.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
  {
    public DbSet<User> Users { get; set; }
  }
}