using Microsoft.EntityFrameworkCore;
using Pedeai.App.Auth.Repos;
using Pedeai.App.Auth.Infra.Persistence;  
using Pedeai.App.Auth.Entities;

namespace Pedeai.App.Auth.Infra.Repos
{
  public class UserRepository(AuthDbContext dbContext) : IUserRepository
  {
    private readonly AuthDbContext _dbContext = dbContext;
    
    public Task<UserEntity?> GetByEmailAsync(string email)
    {     
      return _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task AddAsync(UserEntity user)
    {
      await _dbContext.Users.AddAsync(user);
      await _dbContext.SaveChangesAsync();
    }
  }
}