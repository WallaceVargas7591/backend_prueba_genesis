using backend.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{
    [Key]
    public Guid id { get; set; }

    [Required, MaxLength(50)]
    public string nombre_usuario{ get; set; } = null!;

    [Required, MaxLength(255)]
    public string hash_contrasena { get; set; } = null!;

    [Required, MaxLength(20)]
    public string rol { get; set; } = null!; // Admin, Empleado

    public Guid? id_sucursal { get; set; }

    [ForeignKey(nameof(id_sucursal))]
    public Sucursal? Sucursal { get; set; }

    public DateTime creado_en { get; set; }

    public DateTime actualizado_en { get; set; }
}
