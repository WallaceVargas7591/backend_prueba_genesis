using backend.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ConfiguracionProducto
{
    [Key]
    public Guid Id { get; set; }

    public Guid IdProducto { get; set; }

    [ForeignKey(nameof(IdProducto))]
    public Producto Producto { get; set; } = null!;

    public int? IdTipoMasa { get; set; }
    public int? IdTipoRelleno { get; set; }
    public int? IdTipoEnvoltura { get; set; }
    public int? IdNivelPicante { get; set; }
    public int? IdTipoBebida { get; set; }
    public int? IdTipoEndulzante { get; set; }
    public int? IdTipoTopping { get; set; }

    [ForeignKey(nameof(IdTipoMasa))]
    public TipoMasa? TipoMasa { get; set; }

    [ForeignKey(nameof(IdTipoRelleno))]
    public TipoRelleno? TipoRelleno { get; set; }

    [ForeignKey(nameof(IdTipoEnvoltura))]
    public TipoEnvoltura? TipoEnvoltura { get; set; }

    [ForeignKey(nameof(IdNivelPicante))]
    public NivelPicante? NivelPicante { get; set; }

    [ForeignKey(nameof(IdTipoBebida))]
    public TipoBebida? TipoBebida { get; set; }

    [ForeignKey(nameof(IdTipoEndulzante))]
    public TipoEndulzante? TipoEndulzante { get; set; }

    [ForeignKey(nameof(IdTipoTopping))]
    public TipoTopping? TipoTopping { get; set; }

    public decimal CostoExtra { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime ActualizadoEn { get; set; }

    public ICollection<ItemCombo>? ItemsCombo { get; set; }

    public ICollection<ItemOrden>? ItemsOrden { get; set; }

    public ICollection<IngredienteReceta>? IngredientesReceta { get; set; }

    public ICollection<TemporizadorLote>? TemporizadoresLote { get; set; }
}
