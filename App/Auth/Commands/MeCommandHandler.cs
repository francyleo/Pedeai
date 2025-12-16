using Pedeai.App.Auth.Exceptions;
using Pedeai.App.Auth.Repos;
using Pedeai.App.Shared.Interfaces;

namespace Pedeai.App.Auth.Commands
{
  public class MeCommandHandler(
    IUserRepository userRepository
  ) : ICommandHandler<MeCommand, MeResult> {
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<MeResult> ExecuteAsync(MeCommand command)
    {
      var user = await _userRepository.GetByIdAsync(command.UserId);

      if(user == null) throw new UserNotFoundException();

      return new MeResult(
        user.Id,
        user.Name
      );
    }
  }
}
