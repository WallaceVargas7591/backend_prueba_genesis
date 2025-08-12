using backend.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Orden
{
    [Key]
    public Guid Id { get; set; }

    public DateTime FechaOrden { get; set; }

    public decimal MontoTotal { get; set; }

    [Required, MaxLength(20)]
    public string Estado { get; set; } = null!; // Pendiente, Completada

    public Guid IdSucursal { get; set; }

    [ForeignKey(nameof(IdSucursal))]
    public Sucursal Sucursal { get; set; } = null!;

    public Guid IdUsuario { get; set; }

    [ForeignKey(nameof(IdUsuario))]
    public Usuario Usuario { get; set; } = null!;

    public bool EsOffline { get; set; }

    public DateTime CreadoEn { get; set; }

    public ICollection<ItemOrden>? ItemsOrden { get; set; }
}
