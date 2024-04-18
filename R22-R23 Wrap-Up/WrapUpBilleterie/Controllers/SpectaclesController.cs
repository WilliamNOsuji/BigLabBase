using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WrapUpBilleterie.Data;
using WrapUpBilleterie.Models;

namespace WrapUpBilleterie.Controllers
{
    public class SpectaclesController : Controller
    {
        private readonly R22_BilleterieContext _context;

        public SpectaclesController(R22_BilleterieContext context)
        {
            _context = context;
        }

        // GET: Spectacles
        public async Task<IActionResult> IndexAncien()
        {
              return _context.Spectacles != null ? 
                          View(await _context.Spectacles.ToListAsync()) :
                          Problem("Entity set 'R22_BilleterieContext.Spectacles'  is null.");
        }

        public async Task<IActionResult> Index()
        {
            return _context.VwSpectaclesRepresentationSpectateurs != null ?
                        View(await _context.VwSpectaclesRepresentationSpectateurs.ToListAsync()) :
                        Problem("Entity set 'R22_BilleterieContext.Spectacles'  is null.");
        }

        // GET: Spectacles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Spectacles == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacles
                .FirstOrDefaultAsync(m => m.SpectacleId == id);
            if (spectacle == null)
            {
                return NotFound();
            }

            return View(spectacle);
        }

        // GET: Spectacles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spectacles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpectacleId,Nom,Debut,Fin,Prix")] Spectacle spectacle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spectacle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spectacle);
        }

        // GET: Spectacles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Spectacles == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacles.FindAsync(id);
            if (spectacle == null)
            {
                return NotFound();
            }
            return View(spectacle);
        }

        // POST: Spectacles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpectacleId,Nom,Debut,Fin,Prix")] Spectacle spectacle)
        {
            if (id != spectacle.SpectacleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spectacle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpectacleExists(spectacle.SpectacleId))
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
            return View(spectacle);
        }

        // GET: Spectacles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Spectacles == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacles
                .FirstOrDefaultAsync(m => m.SpectacleId == id);
            if (spectacle == null)
            {
                return NotFound();
            }

            return View(spectacle);
        }

        // POST: Spectacles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Spectacles == null)
            {
                return Problem("Entity set 'R22_BilleterieContext.Spectacles'  is null.");
            }
            var spectacle = await _context.Spectacles.FindAsync(id);
            if (spectacle != null)
            {
                _context.Spectacles.Remove(spectacle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpectacleExists(int id)
        {
          return (_context.Spectacles?.Any(e => e.SpectacleId == id)).GetValueOrDefault();
        }
    }
}
