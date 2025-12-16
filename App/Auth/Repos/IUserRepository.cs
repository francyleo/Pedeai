using Pedeai.App.Auth.Entities;

namespace Pedeai.App.Auth.Repos
{
  public interface IUserRepository
  {
    public Task<UserEntity?> GetByEmailAsync(string email);
    public Task AddAsync(UserEntity user);
  }
}