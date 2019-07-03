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
    public class CardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Card
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cards.Include(c => c.CardCat).Include(c => c.CardRarity).Include(c => c.CardType).Include(c => c.Set);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Card/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .Include(c => c.CardCat)
                .Include(c => c.CardRarity)
                .Include(c => c.CardType)
                .Include(c => c.Set)
                .FirstOrDefaultAsync(m => m.CardID == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Card/Create
        public IActionResult Create()
        {
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID");
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID");
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID");
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID");
            return View();
        }

        // POST: Card/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardID,CardName,CardImageURL,CardImageHiURL,CardCatID,CardTypeID,SetID,CardNum,Artist,CardRarityID,LastUpdateDate")] Card card)
        {
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID", card.CardCatID);
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID", card.CardRarityID);
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID", card.CardTypeID);
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID", card.SetID);
            return View(card);
        }

        // GET: Card/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID", card.CardCatID);
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID", card.CardRarityID);
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID", card.CardTypeID);
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID", card.SetID);
            return View(card);
        }

        // POST: Card/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardID,CardName,CardImageURL,CardImageHiURL,CardCatID,CardTypeID,SetID,CardNum,Artist,CardRarityID,LastUpdateDate")] Card card)
        {
            if (id != card.CardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.CardID))
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
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID", card.CardCatID);
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID", card.CardRarityID);
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID", card.CardTypeID);
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID", card.SetID);
            return View(card);
        }

        // GET: Card/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .Include(c => c.CardCat)
                .Include(c => c.CardRarity)
                .Include(c => c.CardType)
                .Include(c => c.Set)
                .FirstOrDefaultAsync(m => m.CardID == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Card/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.CardID == id);
        }
    }
}
