namespace Pedeai.App.Auth.Exceptions
{
  public class UserNotFoundException : Exception
  {
    public UserNotFoundException() : base("User not found") {}
  }
}