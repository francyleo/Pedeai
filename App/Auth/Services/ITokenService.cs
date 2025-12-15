namespace Pedeai.App.Auth.Services
{
  public interface ITokenService
  {
    public string Generate(Guid userId, string userEmail);
  }
}