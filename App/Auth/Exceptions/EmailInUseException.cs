namespace Pedeai.App.Auth.Exceptions
{
  public class EmailInUseException : Exception
  {
    public EmailInUseException() : base("Email is already in use") {}
  }
}