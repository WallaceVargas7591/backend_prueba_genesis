using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposRellenoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiposRellenoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposRellenoReadDto>>> GetAll()
        {
            var list = await _context.TiposRelleno
                .Where(x => x.estado == 1)
                .Select(x => new TiposRellenoReadDto { Id = x.id, Nombre = x.nombre })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TiposRellenoReadDto>> GetById(int id)
        {
            var relleno = await _context.TiposRelleno.FindAsync(id);
            if (relleno == null) return NotFound();

            var dto = new TiposRellenoReadDto { Id = relleno.id, Nombre = relleno.nombre };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TiposRellenoReadDto>> Create(TiposRellenoCreateDto dto)
        {
            var relleno = new TipoRelleno { nombre = dto.Nombre };
            _context.TiposRelleno.Add(relleno);
            await _context.SaveChangesAsync();

            var readDto = new TiposRellenoReadDto { Id = relleno.id, Nombre = relleno.nombre };
            return CreatedAtAction(nameof(GetById), new { id = relleno.id }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TiposRellenoUpdateDto dto)
        {
            var relleno = await _context.TiposRelleno.FindAsync(id);
            if (relleno == null) return NotFound();

            relleno.nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var relleno = await _context.TiposRelleno.FindAsync(id);
            if (relleno == null) return NotFound();

            relleno.estado = 2;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
