using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pedeai.App.Auth.Infra.Requests
{ 
  public record RegisterRequest
  {
    [Required]
    [DefaultValue("João Silva")]
    public required string FullName { get; init; }

    [Required]
    [EmailAddress]
    [DefaultValue("email@pedeai.com.br")]
    public required string Email { get; init; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    [DefaultValue("sua-senha-secreta")]
    public required string Password { get; init; }

    [Required]
    [Compare("Password", ErrorMessage = "As senhas não conferem.")]
    [DefaultValue("sua-senha-secreta")]
    public required string PasswordConfirmation { get; init; }
  }
}

