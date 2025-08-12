using backend.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Combo
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(100)]
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public bool EsEstacional { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime ActualizadoEn { get; set; }

    public ICollection<ItemCombo>? ItemsCombo { get; set; }

    public ICollection<ItemOrden>? ItemsOrden { get; set; }
}
