using Pedeai.App.Auth.Exceptions;
using Pedeai.App.Auth.Repos;
using Pedeai.App.Auth.Services;
using Pedeai.Auth.Domain.Entities;

namespace Pedeai.App.Auth.Commands
{
  public class RegisterCommandHandler(
    IUserRepository userRepository,
    IPasswordHasherService hashService
  ) {
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasherService _hashService = hashService;

    public async Task<RegisterResult> Execute(RegisterCommand command)
    {
      var user = await _userRepository.GetByEmailAsync(command.Email);

      if(user != null) throw new EmailInUseException();
      
      var hashedPassword = _hashService.Hash(command.Password);

      var newUser = new User(
        command.Name,
        command.Email,
        hashedPassword
      );

      await _userRepository.AddAsync(newUser);

      return new RegisterResult(
        "Usuário registrado com sucesso.",
        newUser.Id.ToString()
      );
    }
  }
}
