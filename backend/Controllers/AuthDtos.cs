using System.ComponentModel.DataAnnotations;

namespace backend.Controllers;

public class LoginDto
{
    [Required]
    public string NombreUsuario { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}

public class LoginResponseDto
{
    public string Token { get; set; } = null!;
    public Guid UsuarioId { get; set; }
    public string NombreUsuario { get; set; } = null!;
    public string Rol { get; set; } = null!;
}
