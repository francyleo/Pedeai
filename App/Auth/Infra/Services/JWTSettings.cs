namespace Pedeai.App.Auth.Infra.Services
{
    public class JWTSettings
  {
    public required string SecretKey { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required int ExpiryInMinutes { get; init; }
  }
}