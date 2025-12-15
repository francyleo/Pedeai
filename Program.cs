using Microsoft.OpenApi.Models;
using Pedeai.App.Auth;

var builder = WebApplication.CreateBuilder(args);

// Setup
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Modules
builder.Services.AddAuthModule(builder.Configuration);

// Swagger
builder.Services.AddSwaggerGen(static c =>
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(options =>
  {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "🍔 Pedeai API");
  });
}

if(app.Environment.IsProduction()) app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();