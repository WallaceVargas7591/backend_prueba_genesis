using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposBebidaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiposBebidaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposBebidaReadDto>>> GetAll()
        {
            var list = await _context.TiposBebida
                .Select(x => new TiposBebidaReadDto { Id = x.id, Nombre = x.nombre })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TiposBebidaReadDto>> GetById(int id)
        {
            var bebida = await _context.TiposBebida.FindAsync(id);
            if (bebida == null) return NotFound();

            var dto = new TiposBebidaReadDto { Id = bebida.id, Nombre = bebida.nombre };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TiposBebidaReadDto>> Create(TiposBebidaCreateDto dto)
        {
            var bebida = new TipoBebida { nombre = dto.Nombre };
            _context.TiposBebida.Add(bebida);
            await _context.SaveChangesAsync();

            var readDto = new TiposBebidaReadDto { Id = bebida.id, Nombre = bebida.nombre };
            return CreatedAtAction(nameof(GetById), new { id = bebida.id }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TiposBebidaUpdateDto dto)
        {
            var bebida = await _context.TiposBebida.FindAsync(id);
            if (bebida == null) return NotFound();

            bebida.nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bebida = await _context.TiposBebida.FindAsync(id);
            if (bebida == null) return NotFound();

            //_context.TiposBebida.Remove(bebida);
            bebida.estado = 2;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
