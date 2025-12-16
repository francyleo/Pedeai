using Microsoft.AspNetCore.Mvc;
using Pedeai.App.Auth.Commands;
using Pedeai.App.Auth.Infra.Requests;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
  [HttpPost("register")]
  public async Task<IActionResult> Register(
    [FromBody] RegisterRequest body,
    [FromServices] RegisterCommandHandler handler
  ) {
    var command = new RegisterCommand(
      body.FullName,
      body.Email,
      body.Password
    );

    var result = await handler.ExecuteAsync(command);

    return Ok(result);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(
    [FromBody] LoginRequest body,
    [FromServices] LoginCommandHandler handler
  ) {
    var command = new LoginCommand(
      body.Email,
      body.Password
    );

    var result = await handler.ExecuteAsync(command);

    return Ok(result);
  }

  [Authorize]
  [HttpPost("me")]
  public async Task<IActionResult> GetMe([FromServices] MeCommandHandler handler) {
    var userId = User.GetUserId();

    var command = new MeCommand(userId);

    var result = await handler.ExecuteAsync(command);

    return Ok(result);
  }
}