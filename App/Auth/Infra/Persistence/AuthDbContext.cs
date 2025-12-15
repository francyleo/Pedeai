using Microsoft.EntityFrameworkCore;
using Pedeai.Auth.Domain.Entities;

namespace Pedeai.Auth.Infra.Persistence
{
  public class AuthDbContext : DbContext
  {
    public DbSet<User> Users => Set<User>();

    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
      base.OnModelCreating(modelBuilder);
    }
  }  
}

