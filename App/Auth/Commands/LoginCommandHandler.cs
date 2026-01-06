using Pedeai.App.Auth.Repos;
using Pedeai.App.Auth.Services;
using Pedeai.App.Shared.Exceptions;
using Pedeai.App.Shared.Interfaces;

namespace Pedeai.App.Auth.Commands
{
  public class LoginCommandHandler(
    IUserRepository userRepository,
    ITokenService tokenService
  ) : ICommandHandler<LoginCommand, LoginResult> {
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<LoginResult> ExecuteAsync(LoginCommand command)
    {
      var user = await _userRepository.GetByEmailAsync(command.Email);

      if(user == null) throw new UserNotFoundException();

      var tokenJWT = _tokenService.Generate(user.Id, user.Email);

      return new LoginResult(
        "Usuário logado com sucesso.",
        tokenJWT,
        DateTime.UtcNow.AddMinutes(60)
      );
    }
  }
}
