using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiblioAPI.Models;

namespace BiblioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecasAPIController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public BibliotecasAPIController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/BibliotecasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biblioteca>>> Getbibliotecas()
        {
            return await _context.bibliotecas.ToListAsync();
        }

        // GET: api/BibliotecasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Biblioteca>> GetBiblioteca(int id)
        {
            var biblioteca = await _context.bibliotecas.FindAsync(id);

            if (biblioteca == null)
            {
                return NotFound();
            }

            return biblioteca;
        }

        // PUT: api/BibliotecasAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBiblioteca(int id, Biblioteca biblioteca)
        {
            if (id != biblioteca.Id)
            {
                return BadRequest();
            }

            _context.Entry(biblioteca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibliotecaExists(id))
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

        // POST: api/BibliotecasAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Biblioteca>> PostBiblioteca(Biblioteca biblioteca)
        {
            _context.bibliotecas.Add(biblioteca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBiblioteca", new { id = biblioteca.Id }, biblioteca);
        }

        // DELETE: api/BibliotecasAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiblioteca(int id)
        {
            var biblioteca = await _context.bibliotecas.FindAsync(id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            _context.bibliotecas.Remove(biblioteca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BibliotecaExists(int id)
        {
            return _context.bibliotecas.Any(e => e.Id == id);
        }
    }
}
