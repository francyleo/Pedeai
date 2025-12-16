namespace Pedeai.App.Auth.Commands
{
  public record MeResult(
    Guid UserId,
    string FullName
  );
}
