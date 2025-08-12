using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TransaccionInventario
{
    [Key]
    public Guid Id { get; set; }

    public Guid IdIngrediente { get; set; }

    [ForeignKey(nameof(IdIngrediente))]
    public Ingrediente Ingrediente { get; set; } = null!;

    [Required, MaxLength(20)]
    public string Tipo { get; set; } = null!; // Entrada, Salida, Merma

    public decimal Cantidad { get; set; }

    public decimal? Costo { get; set; }

    public DateTime Fecha { get; set; }

    public Guid IdSucursal { get; set; }

    [ForeignKey(nameof(IdSucursal))]
    public Sucursal Sucursal { get; set; } = null!;

    public string? Notas { get; set; }

    public DateTime CreadoEn { get; set; }
}
