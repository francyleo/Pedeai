namespace Pedeai.App.Auth.Commands
{
  public record LoginResult(string Message, string Token, DateTime ExpiresAt);
}
