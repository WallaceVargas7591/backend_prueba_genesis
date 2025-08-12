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
    public class IngredientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredienteReadDto>>> GetAll()
        {
            var list = await _context.Ingredientes
                .Select(i => new IngredienteReadDto
                {
                    Id = i.Id,
                    Nombre = i.Nombre,
                    Categoria = i.Categoria,
                    Unidad = i.Unidad,
                    CantidadStock = i.CantidadStock,
                    UmbralCritico = i.UmbralCritico,
                    CostoPromedio = i.CostoPromedio
                }).ToListAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredienteReadDto>> GetById(Guid id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null) return NotFound();

            return new IngredienteReadDto
            {
                Id = ingrediente.Id,
                Nombre = ingrediente.Nombre,
                Categoria = ingrediente.Categoria,
                Unidad = ingrediente.Unidad,
                CantidadStock = ingrediente.CantidadStock,
                UmbralCritico = ingrediente.UmbralCritico,
                CostoPromedio = ingrediente.CostoPromedio
            };
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Empleado")]
        public async Task<ActionResult<IngredienteReadDto>> Create(IngredienteCreateDto dto)
        {
            var ingrediente = new Ingrediente
            {
                Id = Guid.NewGuid(),
                Nombre = dto.Nombre,
                Categoria = dto.Categoria,
                Unidad = dto.Unidad,
                CantidadStock = dto.CantidadStock,
                UmbralCritico = dto.UmbralCritico,
                CostoPromedio = dto.CostoPromedio
            };

            _context.Ingredientes.Add(ingrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ingrediente.Id }, dto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Empleado")]
        public async Task<IActionResult> Update(Guid id, IngredienteUpdateDto dto)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null) return NotFound();

            ingrediente.Nombre = dto.Nombre;
            ingrediente.Categoria = dto.Categoria;
            ingrediente.Unidad = dto.Unidad;
            ingrediente.CantidadStock = dto.CantidadStock;
            ingrediente.UmbralCritico = dto.UmbralCritico;
            ingrediente.CostoPromedio = dto.CostoPromedio;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null) return NotFound();

            _context.Ingredientes.Remove(ingrediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
