using System.ComponentModel.DataAnnotations;

public class NivelPicante
{
    [Key]
    public int id { get; set; }

    [Required, MaxLength(50)]
    public string nombre { get; set; } = null!;
    public int estado { get; set; } = 1;
}