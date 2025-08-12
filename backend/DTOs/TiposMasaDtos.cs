using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class TiposMasaCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }

    public class TiposMasaUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }

    public class TiposMasaReadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
