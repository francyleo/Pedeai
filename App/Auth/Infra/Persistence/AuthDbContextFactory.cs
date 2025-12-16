using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pedeai.App.Auth.Infra.Persistence;

namespace Pedeai.Auth.Infra.Persistence
{
  public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
  {
    public AuthDbContext CreateDbContext(string[] args)
    {
      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

      var connectionString = config.GetConnectionString("AuthDb");

      var options = new DbContextOptionsBuilder<AuthDbContext>()
        .UseSqlite(connectionString)
        .Options;

      return new AuthDbContext(options);
    }
  }  
}

