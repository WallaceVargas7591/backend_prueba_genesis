using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class IngredienteReadDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Categoria { get; set; } = null!;
    public string Unidad { get; set; } = null!;
    public decimal CantidadStock { get; set; }
    public decimal UmbralCritico { get; set; }
    public decimal CostoPromedio { get; set; }
}

public class IngredienteCreateDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Categoria { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string Unidad { get; set; } = null!;

    [Range(0, double.MaxValue)]
    public decimal CantidadStock { get; set; }

    [Range(0, double.MaxValue)]
    public decimal UmbralCritico { get; set; }

    [Range(0, double.MaxValue)]
    public decimal CostoPromedio { get; set; }
}

public class IngredienteUpdateDto : IngredienteCreateDto
{
}
