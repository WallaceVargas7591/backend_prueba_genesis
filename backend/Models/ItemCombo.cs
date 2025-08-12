using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ItemCombo
{
    [Key]
    public Guid Id { get; set; }

    public Guid IdCombo { get; set; }

    [ForeignKey(nameof(IdCombo))]
    public Combo Combo { get; set; } = null!;

    public Guid IdConfiguracionProducto { get; set; }

    [ForeignKey(nameof(IdConfiguracionProducto))]
    public ConfiguracionProducto ConfiguracionProducto { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateTime CreadoEn { get; set; }
}
