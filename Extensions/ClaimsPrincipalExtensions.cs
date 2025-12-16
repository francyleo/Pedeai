using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
  public static Guid GetUserId(this ClaimsPrincipal user)
  {
    var id = user.FindFirstValue(ClaimTypes.NameIdentifier);

    if (string.IsNullOrWhiteSpace(id))
    {      
      throw new UnauthorizedAccessException("UserId claim not found");
    }

    return Guid.Parse(id);
  }
}
