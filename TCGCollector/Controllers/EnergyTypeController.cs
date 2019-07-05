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
    public class EnergyTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnergyTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnergyType
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnergyTypes.ToListAsync());
        }

        // GET: EnergyType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var energyType = await _context.EnergyTypes
                .FirstOrDefaultAsync(m => m.EnergyTypeID == id);
            if (energyType == null)
            {
                return NotFound();
            }

            return View(energyType);
        }

        // GET: EnergyType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnergyType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnergyTypeID,EnergyTypeName,LastUpdateDate")] EnergyType energyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(energyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(energyType);
        }

        // GET: EnergyType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var energyType = await _context.EnergyTypes.FindAsync(id);
            if (energyType == null)
            {
                return NotFound();
            }
            return View(energyType);
        }

        // POST: EnergyType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnergyTypeID,EnergyTypeName,LastUpdateDate")] EnergyType energyType)
        {
            if (id != energyType.EnergyTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(energyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnergyTypeExists(energyType.EnergyTypeID))
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
            return View(energyType);
        }

        // GET: EnergyType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var energyType = await _context.EnergyTypes
                .FirstOrDefaultAsync(m => m.EnergyTypeID == id);
            if (energyType == null)
            {
                return NotFound();
            }

            return View(energyType);
        }

        // POST: EnergyType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var energyType = await _context.EnergyTypes.FindAsync(id);
            _context.EnergyTypes.Remove(energyType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnergyTypeExists(int id)
        {
            return _context.EnergyTypes.Any(e => e.EnergyTypeID == id);
        }
    }
}
