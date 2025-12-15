using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Pedeai.App.Auth.Services;

namespace Pedeai.App.Auth.Infra.Services
{
  public class JWTTokenService : ITokenService
  {
    private readonly JWTSettings _settings;
    
    public JWTTokenService(IOptions<JWTSettings> options)
    {
      _settings = options.Value;
    }

    public string Generate(Guid userId, string userEmail)
    {
      var claims = new[]
      {
        new Claim("id", userId.ToString()),
        new Claim("email", userEmail)
      };

      // TODO: Implement token signing and expiration
      // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
      // var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        issuer: _settings.Issuer,
        audience: _settings.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(_settings.ExpiryInMinutes)
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}