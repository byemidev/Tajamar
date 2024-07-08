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
    public class LocalesController : Controller
    {
        private readonly Contexto _context;

        public LocalesController(Contexto context)
        {
            _context = context;
        }

        // GET: Locales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Local.ToListAsync());
        }

        // GET: Locales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .FirstOrDefaultAsync(m => m.id == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // GET: Locales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nro_ventanas,id,direccion,metros,es_nuevo,precio_base,fecha_construccion")] Local local)
        {
            if (ModelState.IsValid)
            {
                _context.Add(local);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(local);
        }

        // GET: Locales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }
            return View(local);
        }

        // POST: Locales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("nro_ventanas,id,direccion,metros,es_nuevo,precio_base,fecha_construccion")] Local local)
        {
            if (id != local.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(local);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalExists(local.id))
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
            return View(local);
        }

        // GET: Locales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .FirstOrDefaultAsync(m => m.id == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // POST: Locales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var local = await _context.Local.FindAsync(id);
            if (local != null)
            {
                _context.Local.Remove(local);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalExists(int? id)
        {
            return _context.Local.Any(e => e.id == id);
        }
    }
}
