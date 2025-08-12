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
    public class SucursalesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SucursalesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SucursalReadDto>>> GetAll()
        {
            var sucursales = await _context.Sucursales
                .Select(s => new SucursalReadDto
                {
                    Id = s.id,
                    Nombre = s.nombre,
                    Direccion = s.direccion
                }).ToListAsync();

            return Ok(sucursales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalReadDto>> GetById(Guid id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null) return NotFound();

            return new SucursalReadDto
            {
                Id = sucursal.id,
                Nombre = sucursal.nombre,
                Direccion = sucursal.direccion
            };
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<SucursalReadDto>> Create(SucursalCreateDto dto)
        {
            var sucursal = new Sucursal
            {
                id = Guid.NewGuid(),
                nombre = dto.Nombre,
                direccion = dto.Direccion
            };

            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = sucursal.id }, dto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, SucursalUpdateDto dto)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null) return NotFound();

            sucursal.nombre = dto.Nombre;
            sucursal.direccion = dto.Direccion;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null) return NotFound();

            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
