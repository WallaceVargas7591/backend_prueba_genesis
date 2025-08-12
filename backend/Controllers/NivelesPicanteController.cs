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
    public class NivelesPicanteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NivelesPicanteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelesPicanteReadDto>>> GetAll()
        {
            var list = await _context.NivelesPicante
                .Where(x => x.estado == 1)
                .Select(x => new NivelesPicanteReadDto { Id = x.id, Nombre = x.nombre })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NivelesPicanteReadDto>> GetById(int id)
        {
            var nivel = await _context.NivelesPicante.FindAsync(id);
            if (nivel == null) return NotFound();

            var dto = new NivelesPicanteReadDto { Id = nivel.id, Nombre = nivel.nombre };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<NivelesPicanteReadDto>> Create(NivelesPicanteCreateDto dto)
        {
            var nivel = new NivelPicante { nombre = dto.Nombre };
            _context.NivelesPicante.Add(nivel);
            await _context.SaveChangesAsync();

            var readDto = new NivelesPicanteReadDto { Id = nivel.id, Nombre = nivel.nombre };
            return CreatedAtAction(nameof(GetById), new { id = nivel.id }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NivelesPicanteUpdateDto dto)
        {
            var nivel = await _context.NivelesPicante.FindAsync(id);
            if (nivel == null) return NotFound();

            nivel.nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var nivel = await _context.NivelesPicante.FindAsync(id);
            if (nivel == null) return NotFound();

            //_context.NivelesPicante.Remove(nivel);
            nivel.estado = 2;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
