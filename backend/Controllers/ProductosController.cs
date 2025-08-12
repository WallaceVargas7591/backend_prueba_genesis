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
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoReadDto>>> GetAll()
        {
            var productos = await _context.Productos
                .Select(p => new ProductoReadDto
                {
                    Id = p.Id,
                    Tipo = p.Tipo,
                    Tamano = p.Tamano,
                    PrecioBase = p.PrecioBase
                }).ToListAsync();

            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoReadDto>> GetById(Guid id)
        {
            var p = await _context.Productos.FindAsync(id);
            if (p == null) return NotFound();

            return new ProductoReadDto
            {
                Id = p.Id,
                Tipo = p.Tipo,
                Tamano = p.Tamano,
                PrecioBase = p.PrecioBase
            };
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Empleado")]
        public async Task<ActionResult<ProductoReadDto>> Create(ProductoCreateDto dto)
        {
            var producto = new Producto
            {
                Id = Guid.NewGuid(),
                Tipo = dto.Tipo,
                Tamano = dto.Tamano,
                PrecioBase = dto.PrecioBase
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, dto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Empleado")]
        public async Task<IActionResult> Update(Guid id, ProductoUpdateDto dto)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            producto.Tipo = dto.Tipo;
            producto.Tamano = dto.Tamano;
            producto.PrecioBase = dto.PrecioBase;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
