using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
        new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
        new Claim(ClaimTypes.Email, userEmail)
      };      

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        claims: claims,
        issuer: _settings.Issuer,
        audience: _settings.Audience,
        signingCredentials: credentials,
        expires: DateTime.UtcNow.AddMinutes(_settings.ExpiryInMinutes)
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}