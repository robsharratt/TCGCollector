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
    public class SetSeriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SetSeriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SetSeries
        public async Task<IActionResult> Index()
        {
            return View(await _context.SetSeries.ToListAsync());
        }

        // GET: SetSeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setSeries = await _context.SetSeries
                .FirstOrDefaultAsync(m => m.SetSeriesID == id);
            if (setSeries == null)
            {
                return NotFound();
            }

            return View(setSeries);
        }

        // GET: SetSeries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SetSeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SetSeriesID,SetSeriesName,LastUpdateDate")] SetSeries setSeries)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setSeries);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(setSeries);
        }

        // GET: SetSeries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setSeries = await _context.SetSeries.FindAsync(id);
            if (setSeries == null)
            {
                return NotFound();
            }
            return View(setSeries);
        }

        // POST: SetSeries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SetSeriesID,SetSeriesName,LastUpdateDate")] SetSeries setSeries)
        {
            if (id != setSeries.SetSeriesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setSeries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetSeriesExists(setSeries.SetSeriesID))
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
            return View(setSeries);
        }

        // GET: SetSeries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setSeries = await _context.SetSeries
                .FirstOrDefaultAsync(m => m.SetSeriesID == id);
            if (setSeries == null)
            {
                return NotFound();
            }

            return View(setSeries);
        }

        // POST: SetSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var setSeries = await _context.SetSeries.FindAsync(id);
            _context.SetSeries.Remove(setSeries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetSeriesExists(int id)
        {
            return _context.SetSeries.Any(e => e.SetSeriesID == id);
        }
    }
}
