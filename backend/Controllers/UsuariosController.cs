using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]  // Solo Admin puede gestionar usuarios
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReadDto>>> GetAll()
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Sucursal)
                .Select(u => new UsuarioReadDto
                {
                    Id = u.id,
                    NombreUsuario = u.nombre_usuario,
                    Rol = u.rol,
                    IdSucursal = u.id_sucursal
                }).ToListAsync();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioReadDto>> GetById(Guid id)
        {
            var u = await _context.Usuarios
                .Include(u => u.Sucursal)
                .FirstOrDefaultAsync(x => x.id == id);

            if (u == null) return NotFound();

            return new UsuarioReadDto
            {
                Id = u.id,
                NombreUsuario = u.nombre_usuario,
                Rol = u.rol,
                IdSucursal = u.id_sucursal
            };
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioReadDto>> Create(UsuarioCreateDto dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.nombre_usuario == dto.NombreUsuario))
                return BadRequest("El nombre de usuario ya existe.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var usuario = new Usuario
            {
                id = Guid.NewGuid(),
                nombre_usuario = dto.NombreUsuario,
                hash_contrasena = hashedPassword,
                rol = dto.Rol,
                id_sucursal = dto.IdSucursal
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var resultDto = new UsuarioReadDto
            {
                Id = usuario.id,
                NombreUsuario = usuario.nombre_usuario,
                Rol = usuario.rol,
                IdSucursal = usuario.id_sucursal
            };

            return CreatedAtAction(nameof(GetById), new { id = usuario.id }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UsuarioUpdateDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            usuario.rol = dto.Rol;
            usuario.id_sucursal = dto.IdSucursal;

            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                usuario.hash_contrasena = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
