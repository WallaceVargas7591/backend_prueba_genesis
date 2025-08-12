using backend.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Ingrediente
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(100)]
    public string Nombre { get; set; } = null!;

    [Required, MaxLength(50)]
    public string Categoria { get; set; } = null!;

    [Required, MaxLength(20)]
    public string Unidad { get; set; } = null!;

    public decimal CantidadStock { get; set; }

    public decimal UmbralCritico { get; set; }

    public decimal CostoPromedio { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime ActualizadoEn { get; set; }

    public ICollection<TransaccionInventario>? TransaccionesInventario { get; set; }

    public ICollection<IngredienteReceta>? IngredientesReceta { get; set; }
}
