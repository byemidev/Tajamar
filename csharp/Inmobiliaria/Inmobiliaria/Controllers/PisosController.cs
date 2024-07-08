using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{
    public class PisosController : Controller
    {
        private readonly Contexto _context;

        public PisosController(Contexto context)
        {
            _context = context;
        }

        // GET: Pisos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Piso.ToListAsync());
        }

        // GET: Pisos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piso = await _context.Piso
                .FirstOrDefaultAsync(m => m.id == id);
            if (piso == null)
            {
                return NotFound();
            }

            return View(piso);
        }

        // GET: Pisos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pisos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("planta,id,direccion,metros,es_nuevo,precio_base,fecha_construccion")] Piso piso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(piso);
        }

        // GET: Pisos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piso = await _context.Piso.FindAsync(id);
            if (piso == null)
            {
                return NotFound();
            }
            return View(piso);
        }

        // POST: Pisos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("planta,id,direccion,metros,es_nuevo,precio_base,fecha_construccion")] Piso piso)
        {
            if (id != piso.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PisoExists(piso.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(piso);
        }

        // GET: Pisos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piso = await _context.Piso
                .FirstOrDefaultAsync(m => m.id == id);
            if (piso == null)
            {
                return NotFound();
            }

            return View(piso);
        }

        // POST: Pisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var piso = await _context.Piso.FindAsync(id);
            if (piso != null)
            {
                _context.Piso.Remove(piso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PisoExists(int? id)
        {
            return _context.Piso.Any(e => e.id == id);
        }
    }
}
