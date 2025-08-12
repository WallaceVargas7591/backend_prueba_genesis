using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ItemOrden
{
    [Key]
    public Guid Id { get; set; }

    public Guid IdOrden { get; set; }

    [ForeignKey(nameof(IdOrden))]
    public Orden Orden { get; set; } = null!;

    [Required, MaxLength(20)]
    public string TipoItem { get; set; } = null!; // Producto, Combo

    public Guid? IdConfiguracionProducto { get; set; }

    [ForeignKey(nameof(IdConfiguracionProducto))]
    public ConfiguracionProducto? ConfiguracionProducto { get; set; }

    public Guid? IdCombo { get; set; }

    [ForeignKey(nameof(IdCombo))]
    public Combo? Combo { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public DateTime CreadoEn { get; set; }
}
