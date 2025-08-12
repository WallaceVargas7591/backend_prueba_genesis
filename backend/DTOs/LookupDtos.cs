using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class LookupCreateUpdateDto
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Nombre { get; set; } = null!;
}

public class LookupReadDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}
