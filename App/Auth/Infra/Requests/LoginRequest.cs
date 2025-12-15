using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pedeai.App.Auth.Infra.Requests
{
  public record LoginRequest
  {
    [Required]
    [EmailAddress]
    [DefaultValue("email@pedeai.com.br")]
    public required string Email { get; init; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    [DefaultValue("sua-senha-secreta")]
    public required string Password { get; init; }
  }  
}
