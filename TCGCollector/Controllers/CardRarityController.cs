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
    public class CardRarityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardRarityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CardRarity
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardRarities.ToListAsync());
        }

        // GET: CardRarity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardRarity = await _context.CardRarities
                .FirstOrDefaultAsync(m => m.CardRarityID == id);
            if (cardRarity == null)
            {
                return NotFound();
            }

            return View(cardRarity);
        }

        // GET: CardRarity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardRarity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardRarityID,CardRarityName,LastUpdateDate")] CardRarity cardRarity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardRarity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardRarity);
        }

        // GET: CardRarity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardRarity = await _context.CardRarities.FindAsync(id);
            if (cardRarity == null)
            {
                return NotFound();
            }
            return View(cardRarity);
        }

        // POST: CardRarity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardRarityID,CardRarityName,LastUpdateDate")] CardRarity cardRarity)
        {
            if (id != cardRarity.CardRarityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardRarity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardRarityExists(cardRarity.CardRarityID))
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
            return View(cardRarity);
        }

        // GET: CardRarity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardRarity = await _context.CardRarities
                .FirstOrDefaultAsync(m => m.CardRarityID == id);
            if (cardRarity == null)
            {
                return NotFound();
            }

            return View(cardRarity);
        }

        // POST: CardRarity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardRarity = await _context.CardRarities.FindAsync(id);
            _context.CardRarities.Remove(cardRarity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardRarityExists(int id)
        {
            return _context.CardRarities.Any(e => e.CardRarityID == id);
        }
    }
}
