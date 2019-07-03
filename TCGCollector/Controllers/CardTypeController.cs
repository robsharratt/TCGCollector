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
    public class CardTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CardType
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardTypes.ToListAsync());
        }

        // GET: CardType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardType = await _context.CardTypes
                .FirstOrDefaultAsync(m => m.CardTypeID == id);
            if (cardType == null)
            {
                return NotFound();
            }

            return View(cardType);
        }

        // GET: CardType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardTypeID,CardTypeName,LastUpdateDate")] CardType cardType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardType);
        }

        // GET: CardType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardType = await _context.CardTypes.FindAsync(id);
            if (cardType == null)
            {
                return NotFound();
            }
            return View(cardType);
        }

        // POST: CardType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardTypeID,CardTypeName,LastUpdateDate")] CardType cardType)
        {
            if (id != cardType.CardTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardTypeExists(cardType.CardTypeID))
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
            return View(cardType);
        }

        // GET: CardType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardType = await _context.CardTypes
                .FirstOrDefaultAsync(m => m.CardTypeID == id);
            if (cardType == null)
            {
                return NotFound();
            }

            return View(cardType);
        }

        // POST: CardType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardType = await _context.CardTypes.FindAsync(id);
            _context.CardTypes.Remove(cardType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardTypeExists(int id)
        {
            return _context.CardTypes.Any(e => e.CardTypeID == id);
        }
    }
}
