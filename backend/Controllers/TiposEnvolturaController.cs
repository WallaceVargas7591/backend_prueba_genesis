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
    public class TiposEnvolturaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiposEnvolturaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposEnvolturaReadDto>>> GetAll()
        {
            var list = await _context.TiposEnvoltura
                .Where(x => x.estado == 1)
                .Select(x => new TiposEnvolturaReadDto { Id = x.id, Nombre = x.nombre })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TiposEnvolturaReadDto>> GetById(int id)
        {
            var envoltura = await _context.TiposEnvoltura.FindAsync(id);
            if (envoltura == null) return NotFound();

            var dto = new TiposEnvolturaReadDto { Id = envoltura.id, Nombre = envoltura.nombre };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TiposEnvolturaReadDto>> Create(TiposEnvolturaCreateDto dto)
        {
            var envoltura = new TipoEnvoltura { nombre = dto.Nombre };
            _context.TiposEnvoltura.Add(envoltura);
            await _context.SaveChangesAsync();

            var readDto = new TiposEnvolturaReadDto { Id = envoltura.id, Nombre = envoltura.nombre };
            return CreatedAtAction(nameof(GetById), new { id = envoltura.id }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TiposEnvolturaUpdateDto dto)
        {
            var envoltura = await _context.TiposEnvoltura.FindAsync(id);
            if (envoltura == null) return NotFound();

            envoltura.nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var envoltura = await _context.TiposEnvoltura.FindAsync(id);
            if (envoltura == null) return NotFound();

            //_context.TiposEnvoltura.Remove(envoltura);
            envoltura.estado = 2;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
