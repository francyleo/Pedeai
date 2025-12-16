using Microsoft.EntityFrameworkCore;
using Pedeai.App.Auth.Entities;
using Pedeai.App.Catalog.Restaurants.Entities;

namespace Pedeai.App.Shared.Infra.Persistence
{
  public class AppDbContext : DbContext
  {
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<RestaurantEntity> Restaurants => Set<RestaurantEntity>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
      base.OnModelCreating(modelBuilder);
    }
  }  
}

