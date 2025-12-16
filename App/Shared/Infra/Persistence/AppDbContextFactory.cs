using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pedeai.App.Shared.Infra.Persistence
{
  public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
  {
    public AppDbContext CreateDbContext(string[] args)
    {
      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

      var connectionString = config.GetConnectionString("AppDb");

      var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlite(connectionString)
        .Options;

      return new AppDbContext(options);
    }
  }  
}

