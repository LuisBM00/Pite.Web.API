using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pite.Web.API.Models;

namespace Pite.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ProductosController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> Getproductos()
        {
          if (_context.productos == null)
          {
              return NotFound();
          }
            return await _context.productos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductos(int id)
        {
          if (_context.productos == null)
          {
              return NotFound();
          }
            var productos = await _context.productos.FindAsync(id);

            if (productos == null)
            {
                return NotFound("No se encuentra el elemento");
            }

            return productos;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(int id, Productos productos)
        {
            if (id != productos.Id)
            {
                return BadRequest("El id es diferente al elemento");
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
          if (_context.productos == null)
          {
              return Problem("Entity set 'productos'  is null.");
          }
            _context.productos.Add(productos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductos", new { id = productos.Id }, productos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            if (_context.productos == null)
            {
                return NotFound("No se encuentra");
            }
            var productos = await _context.productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.productos.Remove(productos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductosExists(int id)
        {
            return (_context.productos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
