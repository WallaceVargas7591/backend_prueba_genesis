using backend.Data;
using backend.DTOs;
using backend.Models;
using backend.Models.Lookups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposMasaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiposMasaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposMasaReadDto>>> GetAll()
        {
            var list = await _context.TiposMasa
                .Where(x => x.estado == 1)
                .Select(x => new TiposMasaReadDto { Id = x.id, Nombre = x.nombre })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TiposMasaReadDto>> GetById(int id)
        {
            var masa = await _context.TiposMasa.FindAsync(id);
            if (masa == null) return NotFound();

            var dto = new TiposMasaReadDto { Id = masa.id, Nombre = masa.nombre };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TiposMasaReadDto>> Create(TiposMasaCreateDto dto)
        {
            var masa = new TipoMasa { nombre = dto.Nombre };
            _context.TiposMasa.Add(masa);
            await _context.SaveChangesAsync();

            var readDto = new TiposMasaReadDto { Id = masa.id, Nombre = masa.nombre };
            return CreatedAtAction(nameof(GetById), new { id = masa.id }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TiposMasaUpdateDto dto)
        {
            var masa = await _context.TiposMasa.FindAsync(id);
            if (masa == null) return NotFound();

            masa.nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var masa = await _context.TiposMasa.FindAsync(id);
            if (masa == null) return NotFound();

            masa.estado = 2;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
