using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class ConfiguracionProductoReadDto
{
    public Guid Id { get; set; }
    public Guid IdProducto { get; set; }
    public int? IdTipoMasa { get; set; }
    public int? IdTipoRelleno { get; set; }
    public int? IdTipoEnvoltura { get; set; }
    public int? IdNivelPicante { get; set; }
    public int? IdTipoBebida { get; set; }
    public int? IdTipoEndulzante { get; set; }
    public int? IdTipoTopping { get; set; }
    public decimal CostoExtra { get; set; }
}

public class ConfiguracionProductoCreateDto
{
    [Required]
    public Guid IdProducto { get; set; }

    public int? IdTipoMasa { get; set; }
    public int? IdTipoRelleno { get; set; }
    public int? IdTipoEnvoltura { get; set; }
    public int? IdNivelPicante { get; set; }
    public int? IdTipoBebida { get; set; }
    public int? IdTipoEndulzante { get; set; }
    public int? IdTipoTopping { get; set; }

    [Range(0, double.MaxValue)]
    public decimal CostoExtra { get; set; }
}

public class ConfiguracionProductoUpdateDto : ConfiguracionProductoCreateDto
{
}
