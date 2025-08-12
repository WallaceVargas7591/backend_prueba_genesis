using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class UsuarioReadDto
{
    public Guid Id { get; set; }
    public string NombreUsuario { get; set; } = null!;
    public string Rol { get; set; } = null!;
    public Guid? IdSucursal { get; set; }
}

public class UsuarioCreateDto
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string NombreUsuario { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = null!;

    [Required]
    [RegularExpression("Admin|Empleado", ErrorMessage = "Rol debe ser 'Admin' o 'Empleado'")]
    public string Rol { get; set; } = null!;

    public Guid? IdSucursal { get; set; }
}

public class UsuarioUpdateDto
{
    [StringLength(100, MinimumLength = 6)]
    public string? Password { get; set; }

    [Required]
    [RegularExpression("Admin|Empleado", ErrorMessage = "Rol debe ser 'Admin' o 'Empleado'")]
    public string Rol { get; set; } = null!;

    public Guid? IdSucursal { get; set; }
}