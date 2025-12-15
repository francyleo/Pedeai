using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Pedeai.App.Auth.Exceptions;
using Pedeai.App.Auth.Repos;
using Pedeai.App.Auth.Services;

namespace Pedeai.App.Auth.Commands
{
  public class LoginCommandHandler(
    IUserRepository userRepository,
    ITokenService tokenService
  ) {
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<LoginResult> Execute(LoginCommand command)
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
