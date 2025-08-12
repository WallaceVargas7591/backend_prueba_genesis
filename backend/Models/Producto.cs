using backend.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Producto
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(20)]
    public string Tipo { get; set; } = null!; // Tamal, Bebida

    [Required, MaxLength(20)]
    public string Tamano { get; set; } = null!;

    public decimal PrecioBase { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime ActualizadoEn { get; set; }

    public ICollection<ConfiguracionProducto>? ConfiguracionesProducto { get; set; }
}
