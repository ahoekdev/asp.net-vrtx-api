using Microsoft.EntityFrameworkCore;
using api.Entities;
using api.Models;

namespace api.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
  {
    public DbSet<User> Users { get; set; }

    public DbSet<Lodge> Lodges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<User>()
          .Property(u => u.Role)
          .HasConversion(
              // Store uppercase string in database
              v => v.ToUpper(),
              // Return string that represents UserRole (PascalCase)
              v => UserRole.All.FirstOrDefault(r => r.Equals(v, StringComparison.CurrentCultureIgnoreCase))!
          );
    }
  }
}