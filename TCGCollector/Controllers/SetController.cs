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
    public class SetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Set
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sets.Include(s => s.SetSeries);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Set/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @set = await _context.Sets
                .Include(s => s.SetSeries)
                .FirstOrDefaultAsync(m => m.SetID == id);
            if (@set == null)
            {
                return NotFound();
            }

            return View(@set);
        }

        // GET: Set/Create
        public IActionResult Create()
        {
            ViewData["SetSeriesID"] = new SelectList(_context.SetSeries, "SetSeriesID", "SetSeriesID");
            return View();
        }

        // POST: Set/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SetID,SetName,SetCode,SetPTCGOCode,SetSeriesID,SetTotalCards,SetStandard,SetExpanded,SetSymbolURL,SetLogoURL,SetReleaseDate,LastUpdateDate")] Set @set)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@set);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SetSeriesID"] = new SelectList(_context.SetSeries, "SetSeriesID", "SetSeriesID", @set.SetSeriesID);
            return View(@set);
        }

        // GET: Set/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @set = await _context.Sets.FindAsync(id);
            if (@set == null)
            {
                return NotFound();
            }
            ViewData["SetSeriesID"] = new SelectList(_context.SetSeries, "SetSeriesID", "SetSeriesID", @set.SetSeriesID);
            return View(@set);
        }

        // POST: Set/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SetID,SetName,SetCode,SetPTCGOCode,SetSeriesID,SetTotalCards,SetStandard,SetExpanded,SetSymbolURL,SetLogoURL,SetReleaseDate,LastUpdateDate")] Set @set)
        {
            if (id != @set.SetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@set);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetExists(@set.SetID))
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
            ViewData["SetSeriesID"] = new SelectList(_context.SetSeries, "SetSeriesID", "SetSeriesID", @set.SetSeriesID);
            return View(@set);
        }

        // GET: Set/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @set = await _context.Sets
                .Include(s => s.SetSeries)
                .FirstOrDefaultAsync(m => m.SetID == id);
            if (@set == null)
            {
                return NotFound();
            }

            return View(@set);
        }

        // POST: Set/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @set = await _context.Sets.FindAsync(id);
            _context.Sets.Remove(@set);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetExists(int id)
        {
            return _context.Sets.Any(e => e.SetID == id);
        }
    }
}
