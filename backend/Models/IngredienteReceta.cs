using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class IngredienteReceta
{
    [Key]
    public Guid Id { get; set; }

    public Guid IdConfiguracionProducto { get; set; }

    [ForeignKey(nameof(IdConfiguracionProducto))]
    public ConfiguracionProducto ConfiguracionProducto { get; set; } = null!;

    public Guid IdIngrediente { get; set; }

    [ForeignKey(nameof(IdIngrediente))]
    public Ingrediente Ingrediente { get; set; } = null!;

    public decimal CantidadPorUnidad { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime ActualizadoEn { get; set; }
}
