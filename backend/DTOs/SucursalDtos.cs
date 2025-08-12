using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class SucursalReadDto
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }
}

public class SucursalCreateDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }
}

public class SucursalUpdateDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }
}
