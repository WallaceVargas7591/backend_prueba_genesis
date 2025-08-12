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
    public class OrdenesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdenesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenReadDto>>> GetAll()
        {
            var ordenes = await _context.Ordenes
                .Select(o => new OrdenReadDto
                {
                    Id = o.Id,
                    FechaOrden = o.FechaOrden,
                    MontoTotal = o.MontoTotal,
                    Estado = o.Estado,
                    IdSucursal = o.IdSucursal,
                    IdUsuario = o.IdUsuario,
                    EsOffline = o.EsOffline
                }).ToListAsync();

            return Ok(ordenes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenReadDto>> GetById(Guid id)
        {
            var o = await _context.Ordenes.FindAsync(id);
            if (o == null) return NotFound();

            return new OrdenReadDto
            {
                Id = o.Id,
                FechaOrden = o.FechaOrden,
                MontoTotal = o.MontoTotal,
                Estado = o.Estado,
                IdSucursal = o.IdSucursal,
                IdUsuario = o.IdUsuario,
                EsOffline = o.EsOffline
            };
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Empleado")]
        public async Task<ActionResult<OrdenReadDto>> Create(OrdenCreateDto dto)
        {
            var orden = new Orden
            {
                Id = Guid.NewGuid(),
                FechaOrden = dto.FechaOrden,
                MontoTotal = dto.MontoTotal,
                Estado = dto.Estado,
                IdSucursal = dto.IdSucursal,
                IdUsuario = dto.IdUsuario,
                EsOffline = dto.EsOffline
            };

            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = orden.Id }, dto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Empleado")]
        public async Task<IActionResult> Update(Guid id, OrdenUpdateDto dto)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null) return NotFound();

            orden.FechaOrden = dto.FechaOrden;
            orden.MontoTotal = dto.MontoTotal;
            orden.Estado = dto.Estado;
            orden.IdSucursal = dto.IdSucursal;
            orden.IdUsuario = dto.IdUsuario;
            orden.EsOffline = dto.EsOffline;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null) return NotFound();

            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
