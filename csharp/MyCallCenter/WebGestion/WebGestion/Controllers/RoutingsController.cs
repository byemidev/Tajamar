using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebGestion.Models;

namespace WebGestion.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoutingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoutingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Routings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Routing.ToListAsync());
        }

        // GET: Routings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routing = await _context.Routing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routing == null)
            {
                return NotFound();
            }

            return View(routing);
        }

        // GET: Routings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numeracion,Ruta")] Routing routing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routing);
        }

        // GET: Routings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routing = await _context.Routing.FindAsync(id);
            if (routing == null)
            {
                return NotFound();
            }
            return View(routing);
        }

        // POST: Routings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numeracion,Ruta")] Routing routing)
        {
            if (id != routing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoutingExists(routing.Id))
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
            return View(routing);
        }

        // GET: Routings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routing = await _context.Routing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routing == null)
            {
                return NotFound();
            }

            return View(routing);
        }

        // POST: Routings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routing = await _context.Routing.FindAsync(id);
            if (routing != null)
            {
                _context.Routing.Remove(routing);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoutingExists(int id)
        {
            return _context.Routing.Any(e => e.Id == id);
        }
    }
}
