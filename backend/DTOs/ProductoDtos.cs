using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class ProductoReadDto
{
    public Guid Id { get; set; }
    public string Tipo { get; set; } = null!;
    public string Tamano { get; set; } = null!;
    public decimal PrecioBase { get; set; }
}

public class ProductoCreateDto
{
    [Required]
    [StringLength(20)]
    public string Tipo { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string Tamano { get; set; } = null!;

    [Range(0, double.MaxValue)]
    public decimal PrecioBase { get; set; }
}

public class ProductoUpdateDto : ProductoCreateDto
{
}
