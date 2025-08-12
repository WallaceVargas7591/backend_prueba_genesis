using backend.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Sucursal
{
    [Key]
    public Guid id { get; set; }

    [Required, MaxLength(100)]
    public string nombre { get; set; } = null!;

    public string? direccion { get; set; }

    public DateTime creado_en { get; set; }

    public DateTime actualizado_en { get; set; }

    public ICollection<Usuario>? Usuarios { get; set; }

    //public ICollection<Orden>? Ordenes { get; set; }

    public ICollection<TransaccionInventario>? TransaccionesInventario { get; set; }
}
