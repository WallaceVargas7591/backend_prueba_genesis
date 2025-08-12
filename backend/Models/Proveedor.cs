using System;
using System.ComponentModel.DataAnnotations;

public class Proveedor
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(100)]
    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime ActualizadoEn { get; set; }
}
