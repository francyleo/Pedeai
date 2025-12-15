namespace Pedeai.App.Auth.Services
{
  public interface IPasswordHasherService
  {
    public string Hash(string input);
    public bool Verify(string input, string hash);
  }
}