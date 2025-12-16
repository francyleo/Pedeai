using Microsoft.EntityFrameworkCore;
using Pedeai.App.Shared.Infra.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Pedeai.App.Shared
{
  public static class SharedModule
  {
    public static IServiceCollection AddSharedModule(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseSqlite(configuration.GetConnectionString("AppDb"));
      });      

      return services;
    }
  }  
}