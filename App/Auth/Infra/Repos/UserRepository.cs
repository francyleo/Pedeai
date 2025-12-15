using Microsoft.EntityFrameworkCore;
using Pedeai.App.Auth.Repos;
using Pedeai.Auth.Domain.Entities;
using Pedeai.Auth.Infra.Persistence;

namespace Pedeai.App.Auth.Infra.Repos
{
  public class UserRepository(AuthDbContext dbContext) : IUserRepository
  {
    private readonly AuthDbContext _dbContext = dbContext;
    
    public Task<User?> GetByEmailAsync(string email)
    {     
      return _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task AddAsync(User user)
    {
      await _dbContext.Users.AddAsync(user);
      await _dbContext.SaveChangesAsync();
    }
  }
}