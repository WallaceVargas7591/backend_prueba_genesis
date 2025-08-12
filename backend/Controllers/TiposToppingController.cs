using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposToppingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiposToppingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposToppingReadDto>>> GetAll()
        {
            var list = await _context.TiposTopping
                .Where(x => x.estado == 1)
                .Select(x => new TiposToppingReadDto { Id = x.id, Nombre = x.nombre })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TiposToppingReadDto>> GetById(int id)
        {
            var topping = await _context.TiposTopping.FindAsync(id);
            if (topping == null) return NotFound();

            var dto = new TiposToppingReadDto { Id = topping.id, Nombre = topping.nombre };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TiposToppingReadDto>> Create(TiposToppingCreateDto dto)
        {
            var topping = new TipoTopping { nombre = dto.Nombre };
            _context.TiposTopping.Add(topping);
            await _context.SaveChangesAsync();

            var readDto = new TiposToppingReadDto { Id = topping.id, Nombre = topping.nombre };
            return CreatedAtAction(nameof(GetById), new { id = topping.id }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TiposToppingUpdateDto dto)
        {
            var topping = await _context.TiposTopping.FindAsync(id);
            if (topping == null) return NotFound();

            topping.nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var topping = await _context.TiposTopping.FindAsync(id);
            if (topping == null) return NotFound();

            //_context.TiposTopping.Remove(topping);
            topping.estado = 2;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
