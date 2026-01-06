using Microsoft.OpenApi.Models;

public static class DocumentationExtensions
{
  public static IServiceCollection AddDocumentationModule(this IServiceCollection services, IConfiguration configuration)
  {
    // TODO: Get these settings from configuration
    
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(static c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "🍔 Pedeai API", Version = "v1" });

      c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
      });

      c.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
            {
              Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
            }
          },
          Array.Empty<string>()
        }
      });
    });


    return services;
  }

  public static IApplicationBuilder UseDocumentationUI(this IApplicationBuilder app)
  {
    app.UseSwagger();
    app.UseSwaggerUI(options => {
      options.SwaggerEndpoint("/swagger/v1/swagger.json", "🍔 Pedeai API");
    });

    return app;
  }
}  