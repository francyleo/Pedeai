using Pedeai.App.Auth.Services;

namespace Pedeai.App.Auth.Infra.Services
{
  public class BCryptPasswordHasher : IPasswordHasherService
  {
    public string Hash(string input)
    {
      return BCrypt.Net.BCrypt.HashPassword(input);
    }

    public bool Verify(string input, string hash)
    {
      return BCrypt.Net.BCrypt.Verify(input, hash);
    }
  }
}