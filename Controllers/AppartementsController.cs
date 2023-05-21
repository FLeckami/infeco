using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Infeco.Data;
using Infeco.Models;

namespace infeco.Controllers
{
    public class AppartementsController : Controller
    {
        private readonly InfecoContext _context;

        public AppartementsController(InfecoContext context)
        {
            _context = context;
        }

        // GET: Appartements
        public async Task<IActionResult> Index()
        {
              return _context.Appartement != null ? 
                          View(await _context.Appartement.ToListAsync()) :
                          Problem("Entity set 'InfecoContext.Appartement'  is null.");
        }

        // GET: Appartements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appartement == null)
            {
                return NotFound();
            }

            var appartement = await _context.Appartement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appartement == null)
            {
                return NotFound();
            }

            return View(appartement);
        }

        // GET: Appartements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appartements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adresse")] Appartement appartement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appartement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appartement);
        }

        // GET: Appartements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appartement == null)
            {
                return NotFound();
            }

            var appartement = await _context.Appartement.FindAsync(id);
            if (appartement == null)
            {
                return NotFound();
            }
            return View(appartement);
        }

        // POST: Appartements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adresse")] Appartement appartement)
        {
            if (id != appartement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appartement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppartementExists(appartement.Id))
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
            return View(appartement);
        }

        // GET: Appartements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appartement == null)
            {
                return NotFound();
            }

            var appartement = await _context.Appartement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appartement == null)
            {
                return NotFound();
            }

            return View(appartement);
        }

        // POST: Appartements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appartement == null)
            {
                return Problem("Entity set 'InfecoContext.Appartement'  is null.");
            }
            var appartement = await _context.Appartement.FindAsync(id);
            if (appartement != null)
            {
                _context.Appartement.Remove(appartement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppartementExists(int id)
        {
          return (_context.Appartement?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
