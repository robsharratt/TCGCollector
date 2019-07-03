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
    public class SpecialCardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpecialCard
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SpecialCards.Include(s => s.CardCat).Include(s => s.CardRarity).Include(s => s.CardType).Include(s => s.Set);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SpecialCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialCard = await _context.SpecialCards
                .Include(s => s.CardCat)
                .Include(s => s.CardRarity)
                .Include(s => s.CardType)
                .Include(s => s.Set)
                .FirstOrDefaultAsync(m => m.CardID == id);
            if (specialCard == null)
            {
                return NotFound();
            }

            return View(specialCard);
        }

        // GET: SpecialCard/Create
        public IActionResult Create()
        {
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID");
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID");
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID");
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID");
            return View();
        }

        // POST: SpecialCard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardID,CardName,CardImageURL,CardImageHiURL,CardCatID,CardTypeID,SetID,CardNum,Artist,CardRarityID,LastUpdateDate")] SpecialCard specialCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID", specialCard.CardCatID);
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID", specialCard.CardRarityID);
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID", specialCard.CardTypeID);
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID", specialCard.SetID);
            return View(specialCard);
        }

        // GET: SpecialCard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialCard = await _context.SpecialCards.FindAsync(id);
            if (specialCard == null)
            {
                return NotFound();
            }
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID", specialCard.CardCatID);
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID", specialCard.CardRarityID);
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID", specialCard.CardTypeID);
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID", specialCard.SetID);
            return View(specialCard);
        }

        // POST: SpecialCard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardID,CardName,CardImageURL,CardImageHiURL,CardCatID,CardTypeID,SetID,CardNum,Artist,CardRarityID,LastUpdateDate")] SpecialCard specialCard)
        {
            if (id != specialCard.CardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialCardExists(specialCard.CardID))
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
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID", specialCard.CardCatID);
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID", specialCard.CardRarityID);
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID", specialCard.CardTypeID);
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID", specialCard.SetID);
            return View(specialCard);
        }

        // GET: SpecialCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialCard = await _context.SpecialCards
                .Include(s => s.CardCat)
                .Include(s => s.CardRarity)
                .Include(s => s.CardType)
                .Include(s => s.Set)
                .FirstOrDefaultAsync(m => m.CardID == id);
            if (specialCard == null)
            {
                return NotFound();
            }

            return View(specialCard);
        }

        // POST: SpecialCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialCard = await _context.SpecialCards.FindAsync(id);
            _context.SpecialCards.Remove(specialCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialCardExists(int id)
        {
            return _context.SpecialCards.Any(e => e.CardID == id);
        }
    }
}
