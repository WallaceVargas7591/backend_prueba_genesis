using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TemporizadorLote
{
    [Key]
    public Guid Id { get; set; }

    public DateTime HoraInicio { get; set; }

    public DateTime? HoraFin { get; set; }

    public Guid IdConfiguracionProducto { get; set; }

    [ForeignKey(nameof(IdConfiguracionProducto))]
    public ConfiguracionProducto ConfiguracionProducto { get; set; } = null!;

    [Required, MaxLength(20)]
    public string Estado { get; set; } = null!; // EnProgreso, Completado

    public DateTime CreadoEn { get; set; }

    public DateTime ActualizadoEn { get; set; }
}
