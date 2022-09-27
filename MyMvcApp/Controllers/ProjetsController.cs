using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Data;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    public class ProjetsController : Controller
    {
        private readonly MyMvcAppContext _context;

        public ProjetsController(MyMvcAppContext context)
        {
            _context = context;
        }

        // GET: Projets
        public async Task<IActionResult> Index()
        {
              return View(await _context.Projets.ToListAsync());
        }

        // GET: Projets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projets == null)
            {
                return NotFound();
            }

            var projets = await _context.Projets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projets == null)
            {
                return NotFound();
            }

            return View(projets);
        }

        // GET: Projets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DatePubli")] Projets projets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projets);
        }

        // GET: Projets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projets == null)
            {
                return NotFound();
            }

            var projets = await _context.Projets.FindAsync(id);
            if (projets == null)
            {
                return NotFound();
            }
            return View(projets);
        }

        // POST: Projets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DatePubli")] Projets projets)
        {
            if (id != projets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetsExists(projets.Id))
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
            return View(projets);
        }

        // GET: Projets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projets == null)
            {
                return NotFound();
            }

            var projets = await _context.Projets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projets == null)
            {
                return NotFound();
            }

            return View(projets);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projets == null)
            {
                return Problem("Entity set 'MyMvcAppContext.Projets'  is null.");
            }
            var projets = await _context.Projets.FindAsync(id);
            if (projets != null)
            {
                _context.Projets.Remove(projets);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetsExists(int id)
        {
          return _context.Projets.Any(e => e.Id == id);
        }
    }
}
