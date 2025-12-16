using Microsoft.EntityFrameworkCore;
using Pedeai.App.Auth.Repos;
using Pedeai.App.Auth.Entities;
using Pedeai.App.Shared.Infra.Persistence;

namespace Pedeai.App.Auth.Infra.Repos
{
  public class UserRepository(AppDbContext dbContext) : IUserRepository
  {
    private readonly AppDbContext _dbContext = dbContext;
    
    public Task<UserEntity?> GetByEmailAsync(string email)
    {     
      return _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task AddAsync(UserEntity user)
    {
      await _dbContext.Users.AddAsync(user);
      await _dbContext.SaveChangesAsync();
    }

    public Task<UserEntity?> GetByIdAsync(Guid id)
    {
      return _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
    }
  }
}