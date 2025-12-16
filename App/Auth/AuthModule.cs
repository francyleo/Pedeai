using Microsoft.EntityFrameworkCore;
using Pedeai.App.Auth.Commands;
using Pedeai.App.Auth.Repos;
using Pedeai.App.Auth.Services;
using Pedeai.App.Auth.Infra.Persistence;
using Pedeai.App.Auth.Infra.Repos;
using Pedeai.App.Auth.Infra.Services;

namespace Pedeai.App.Auth
{
  public static class AuthModule
  {
    public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<AuthDbContext>(options =>
      {
        options.UseSqlite(configuration.GetConnectionString("AuthDb"));
        // options.EnableSensitiveDataLogging();
      });

      // Services
      services.Configure<JWTSettings>(configuration.GetSection("Jwt"));
      services.AddScoped<ITokenService, JWTTokenService>();
      services.AddScoped<IPasswordHasherService, BCryptPasswordHasher>();

      // Repositories
      services.AddScoped<IUserRepository, UserRepository>();

      // Command Handlers
      services.AddScoped<LoginCommandHandler>();
      services.AddScoped<RegisterCommandHandler>();

      return services;
    }
  }  
}