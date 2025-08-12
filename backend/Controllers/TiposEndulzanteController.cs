using backend.Data;
using backend.DTOs;
using backend.Models.Lookups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposEndulzanteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiposEndulzanteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposEndulzanteReadDto>>> GetAll()
        {
            var list = await _context.TiposEndulzante
                .Where(x => x.estado == 1)
                .Select(x => new TiposEndulzanteReadDto { Id = x.id, Nombre = x.nombre })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TiposEndulzanteReadDto>> GetById(int id)
        {
            var endulzante = await _context.TiposEndulzante.FindAsync(id);
            if (endulzante == null) return NotFound();

            var dto = new TiposEndulzanteReadDto { Id = endulzante.id, Nombre = endulzante.nombre };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TiposEndulzanteReadDto>> Create(TiposEndulzanteCreateDto dto)
        {
            var endulzante = new TipoEndulzante { nombre = dto.Nombre };
            _context.TiposEndulzante.Add(endulzante);
            await _context.SaveChangesAsync();

            var readDto = new TiposEndulzanteReadDto { Id = endulzante.id, Nombre = endulzante.nombre };
            return CreatedAtAction(nameof(GetById), new { id = endulzante.id }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TiposEndulzanteUpdateDto dto)
        {
            var endulzante = await _context.TiposEndulzante.FindAsync(id);
            if (endulzante == null) return NotFound();

            endulzante.nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var endulzante = await _context.TiposEndulzante.FindAsync(id);
            if (endulzante == null) return NotFound();

            //_context.TiposEndulzante.Remove(endulzante);
            endulzante.estado = 2;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
