using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Notificacion
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(20)]
    public string Tipo { get; set; } = null!; // Venta, FinCoccion

    [Required]
    public string Mensaje { get; set; } = null!;

    public DateTime EnviadoEn { get; set; }

    public Guid IdUsuario { get; set; }

    [ForeignKey(nameof(IdUsuario))]
    public Usuario Usuario { get; set; } = null!;

    public DateTime CreadoEn { get; set; }
}
