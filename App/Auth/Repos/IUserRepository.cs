using Pedeai.Auth.Domain.Entities;

namespace Pedeai.App.Auth.Repos
{
  public interface IUserRepository
  {
    public Task<User?> GetByEmailAsync(string email);
    public Task AddAsync(User user);
  }
}