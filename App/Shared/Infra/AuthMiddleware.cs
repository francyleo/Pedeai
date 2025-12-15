
namespace Pedeai.Controllers;

public class AuthMiddleware
{
  private readonly RequestDelegate _next;

  public AuthMiddleware(RequestDelegate next) => _next = next;

  public async Task Invoke(HttpContext context)
  {
    if (!context.Request.Headers.TryGetValue("Authorization", out var authHeader))
    {
      context.Response.StatusCode = 401;
      await context.Response.WriteAsync("Missing Authorization header");
      return;
    }

    if (!authHeader.ToString().StartsWith("Bearer "))
    {
      context.Response.StatusCode = 401;
      await context.Response.WriteAsync("Invalid Authorization header format.");
      return;
    }

    // TODO: Validate token here and set user in context
    // context.User = new System.Security.Claims.ClaimsPrincipal();

    await _next(context);
  }
}