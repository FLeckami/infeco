using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Infeco.Data;
using Infeco.Models;

namespace Infeco.Controllers
{
    public class FacturesController : Controller
    {
        private readonly InfecoContext _context;

        public FacturesController(InfecoContext context)
        {
            _context = context;
        }

        // GET: Factures
        public async Task<IActionResult> Index()
        {
            var infecoContext = _context.Facture.Include(f => f.Client);
            return View(await infecoContext.ToListAsync());
        }

        // GET: Factures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facture == null)
            {
                return NotFound();
            }

            var facture = await _context.Facture
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facture == null)
            {
                return NotFound();
            }

            return View(facture);
        }

        // GET: Factures/Create
        public IActionResult Create()
        {
            ViewData["IdClient"] = new SelectList(_context.Client, "Id", "Nom");
            return View();
        }

        // POST: Factures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdClient,DatePaiement")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClient"] = new SelectList(_context.Client, "Id", "Nom", facture.IdClient);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facture == null)
            {
                return NotFound();
            }

            var facture = await _context.Facture.FindAsync(id);
            if (facture == null)
            {
                return NotFound();
            }
            ViewData["IdClient"] = new SelectList(_context.Client, "Id", "Nom", facture.IdClient);
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdClient,DatePaiement")] Facture facture)
        {
            if (id != facture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactureExists(facture.Id))
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
            ViewData["IdClient"] = new SelectList(_context.Client, "Id", "Nom", facture.IdClient);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facture == null)
            {
                return NotFound();
            }

            var facture = await _context.Facture
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facture == null)
            {
                return NotFound();
            }

            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facture == null)
            {
                return Problem("Entity set 'InfecoContext.Facture'  is null.");
            }
            var facture = await _context.Facture.FindAsync(id);
            if (facture != null)
            {
                _context.Facture.Remove(facture);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactureExists(int id)
        {
          return (_context.Facture?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
