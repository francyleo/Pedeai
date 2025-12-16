namespace Pedeai.App.Auth.Entities
{  
  public sealed class UserEntity(
    string name,
    string email,
    string password
    ) {
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
  }
}
