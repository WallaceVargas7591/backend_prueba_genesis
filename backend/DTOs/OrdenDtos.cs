using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class OrdenReadDto
{
    public Guid Id { get; set; }
    public DateTime FechaOrden { get; set; }
    public decimal MontoTotal { get; set; }
    public string Estado { get; set; } = null!;
    public Guid IdSucursal { get; set; }
    public Guid IdUsuario { get; set; }
    public bool EsOffline { get; set; }
}

public class OrdenCreateDto
{
    [Required]
    public DateTime FechaOrden { get; set; }

    [Range(0, double.MaxValue)]
    public decimal MontoTotal { get; set; }

    [Required]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [Required]
    public Guid IdSucursal { get; set; }

    [Required]
    public Guid IdUsuario { get; set; }

    public bool EsOffline { get; set; } = false;
}

public class OrdenUpdateDto : OrdenCreateDto
{
}
