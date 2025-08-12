namespace backend.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = null!;
        public Guid UsuarioId { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Rol { get; set; } = null!;
    }
}
