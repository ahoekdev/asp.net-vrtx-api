using Microsoft.EntityFrameworkCore;
using api.Entities;
using api.Enums;

namespace api.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
  {
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<User>()
          .Property(u => u.Role)
          .HasConversion(
              v => v.ToString().ToUpper(),
              v => (UserRole)Enum.Parse(typeof(UserRole), v, true));
    }
  }
}