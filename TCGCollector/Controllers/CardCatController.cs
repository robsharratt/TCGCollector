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
    public class CardCatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardCatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CardCat
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardCats.ToListAsync());
        }

        // GET: CardCat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardCat = await _context.CardCats
                .FirstOrDefaultAsync(m => m.CardCatID == id);
            if (cardCat == null)
            {
                return NotFound();
            }

            return View(cardCat);
        }

        // GET: CardCat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardCat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardCatID,CardCatName,LastUpdateDate")] CardCat cardCat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardCat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardCat);
        }

        // GET: CardCat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardCat = await _context.CardCats.FindAsync(id);
            if (cardCat == null)
            {
                return NotFound();
            }
            return View(cardCat);
        }

        // POST: CardCat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardCatID,CardCatName,LastUpdateDate")] CardCat cardCat)
        {
            if (id != cardCat.CardCatID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardCatExists(cardCat.CardCatID))
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
            return View(cardCat);
        }

        // GET: CardCat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardCat = await _context.CardCats
                .FirstOrDefaultAsync(m => m.CardCatID == id);
            if (cardCat == null)
            {
                return NotFound();
            }

            return View(cardCat);
        }

        // POST: CardCat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardCat = await _context.CardCats.FindAsync(id);
            _context.CardCats.Remove(cardCat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardCatExists(int id)
        {
            return _context.CardCats.Any(e => e.CardCatID == id);
        }
    }
}
