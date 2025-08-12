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
    [Authorize]
    public class ConfiguracionesProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConfiguracionesProductoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfiguracionProductoReadDto>>> GetAll()
        {
            var configs = await _context.ConfiguracionesProducto
                .Select(c => new ConfiguracionProductoReadDto
                {
                    Id = c.Id,
                    IdProducto = c.IdProducto,
                    IdTipoMasa = c.IdTipoMasa,
                    IdTipoRelleno = c.IdTipoRelleno,
                    IdTipoEnvoltura = c.IdTipoEnvoltura,
                    IdNivelPicante = c.IdNivelPicante,
                    IdTipoBebida = c.IdTipoBebida,
                    IdTipoEndulzante = c.IdTipoEndulzante,
                    IdTipoTopping = c.IdTipoTopping,
                    CostoExtra = c.CostoExtra
                }).ToListAsync();

            return Ok(configs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConfiguracionProductoReadDto>> GetById(Guid id)
        {
            var c = await _context.ConfiguracionesProducto.FindAsync(id);
            if (c == null) return NotFound();

            return new ConfiguracionProductoReadDto
            {
                Id = c.Id,
                IdProducto = c.IdProducto,
                IdTipoMasa = c.IdTipoMasa,
                IdTipoRelleno = c.IdTipoRelleno,
                IdTipoEnvoltura = c.IdTipoEnvoltura,
                IdNivelPicante = c.IdNivelPicante,
                IdTipoBebida = c.IdTipoBebida,
                IdTipoEndulzante = c.IdTipoEndulzante,
                IdTipoTopping = c.IdTipoTopping,
                CostoExtra = c.CostoExtra
            };
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Empleado")]
        public async Task<ActionResult<ConfiguracionProductoReadDto>> Create(ConfiguracionProductoCreateDto dto)
        {
            var config = new ConfiguracionProducto
            {
                Id = Guid.NewGuid(),
                IdProducto = dto.IdProducto,
                IdTipoMasa = dto.IdTipoMasa,
                IdTipoRelleno = dto.IdTipoRelleno,
                IdTipoEnvoltura = dto.IdTipoEnvoltura,
                IdNivelPicante = dto.IdNivelPicante,
                IdTipoBebida = dto.IdTipoBebida,
                IdTipoEndulzante = dto.IdTipoEndulzante,
                IdTipoTopping = dto.IdTipoTopping,
                CostoExtra = dto.CostoExtra
            };

            _context.ConfiguracionesProducto.Add(config);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = config.Id }, dto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Empleado")]
        public async Task<IActionResult> Update(Guid id, ConfiguracionProductoUpdateDto dto)
        {
            var config = await _context.ConfiguracionesProducto.FindAsync(id);
            if (config == null) return NotFound();

            config.IdProducto = dto.IdProducto;
            config.IdTipoMasa = dto.IdTipoMasa;
            config.IdTipoRelleno = dto.IdTipoRelleno;
            config.IdTipoEnvoltura = dto.IdTipoEnvoltura;
            config.IdNivelPicante = dto.IdNivelPicante;
            config.IdTipoBebida = dto.IdTipoBebida;
            config.IdTipoEndulzante = dto.IdTipoEndulzante;
            config.IdTipoTopping = dto.IdTipoTopping;
            config.CostoExtra = dto.CostoExtra;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var config = await _context.ConfiguracionesProducto.FindAsync(id);
            if (config == null) return NotFound();

            _context.ConfiguracionesProducto.Remove(config);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
