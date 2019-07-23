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
    public class AbilityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ability
        public async Task<IActionResult> Index()
        {
            return View(await _context.Abilities.ToListAsync());
        }

        // GET: Ability/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ability = await _context.Abilities
                .FirstOrDefaultAsync(m => m.AbilityID == id);
            if (ability == null)
            {
                return NotFound();
            }

            return View(ability);
        }

        // GET: Ability/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ability/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AbilityID,AbilityName,AbilityText,AbilityType,LastUpdateDate")] Ability ability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ability);
        }

        // GET: Ability/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ability = await _context.Abilities.FindAsync(id);
            if (ability == null)
            {
                return NotFound();
            }
            return View(ability);
        }

        // POST: Ability/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AbilityID,AbilityName,AbilityText,AbilityType,LastUpdateDate")] Ability ability)
        {
            if (id != ability.AbilityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbilityExists(ability.AbilityID))
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
            return View(ability);
        }

        // GET: Ability/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ability = await _context.Abilities
                .FirstOrDefaultAsync(m => m.AbilityID == id);
            if (ability == null)
            {
                return NotFound();
            }

            return View(ability);
        }

        // POST: Ability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ability = await _context.Abilities.FindAsync(id);
            _context.Abilities.Remove(ability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbilityExists(int id)
        {
            return _context.Abilities.Any(e => e.AbilityID == id);
        }
    }
}
