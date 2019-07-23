using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCGCollector.Models;

namespace TCGCollector.Controllers
{
    public class ResistanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResistanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resistance
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Resistances.Include(r => r.EnergyType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Resistance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resistance = await _context.Resistances
                .Include(r => r.EnergyType)
                .FirstOrDefaultAsync(m => m.ResistanceID == id);
            if (resistance == null)
            {
                return NotFound();
            }

            return View(resistance);
        }

        // GET: Resistance/Create
        public IActionResult Create()
        {
            ViewData["EnergyTypeID"] = new SelectList(_context.EnergyTypes, "EnergyTypeID", "EnergyTypeID");
            return View();
        }

        // POST: Resistance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResistanceID,EnergyTypeID,ResistanceValue,LastUpdateDate")] Resistance resistance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resistance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnergyTypeID"] = new SelectList(_context.EnergyTypes, "EnergyTypeID", "EnergyTypeID", resistance.EnergyTypeID);
            return View(resistance);
        }

        // GET: Resistance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resistance = await _context.Resistances.FindAsync(id);
            if (resistance == null)
            {
                return NotFound();
            }
            ViewData["EnergyTypeID"] = new SelectList(_context.EnergyTypes, "EnergyTypeID", "EnergyTypeID", resistance.EnergyTypeID);
            return View(resistance);
        }

        // POST: Resistance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResistanceID,EnergyTypeID,ResistanceValue,LastUpdateDate")] Resistance resistance)
        {
            if (id != resistance.ResistanceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resistance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResistanceExists(resistance.ResistanceID))
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
            ViewData["EnergyTypeID"] = new SelectList(_context.EnergyTypes, "EnergyTypeID", "EnergyTypeID", resistance.EnergyTypeID);
            return View(resistance);
        }

        // GET: Resistance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resistance = await _context.Resistances
                .Include(r => r.EnergyType)
                .FirstOrDefaultAsync(m => m.ResistanceID == id);
            if (resistance == null)
            {
                return NotFound();
            }

            return View(resistance);
        }

        // POST: Resistance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resistance = await _context.Resistances.FindAsync(id);
            _context.Resistances.Remove(resistance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResistanceExists(int id)
        {
            return _context.Resistances.Any(e => e.ResistanceID == id);
        }
    }
}
