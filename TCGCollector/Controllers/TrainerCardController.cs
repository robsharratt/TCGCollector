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
    public class TrainerCardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainerCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrainerCard
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TrainerCards.Include(t => t.CardCat).Include(t => t.CardRarity).Include(t => t.CardType).Include(t => t.Set);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TrainerCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainerCard = await _context.TrainerCards
                .Include(t => t.CardCat)
                .Include(t => t.CardRarity)
                .Include(t => t.CardType)
                .Include(t => t.Set)
                .FirstOrDefaultAsync(m => m.CardID == id);
            if (trainerCard == null)
            {
                return NotFound();
            }

            return View(trainerCard);
        }

        // GET: TrainerCard/Create
        public IActionResult Create()
        {
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID");
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID");
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID");
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID");
            return View();
        }

        // POST: TrainerCard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardID,CardName,CardImageURL,CardImageHiURL,CardCatID,CardTypeID,SetID,CardNum,Artist,CardRarityID,LastUpdateDate")] TrainerCard trainerCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainerCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID", trainerCard.CardCatID);
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID", trainerCard.CardRarityID);
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID", trainerCard.CardTypeID);
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID", trainerCard.SetID);
            return View(trainerCard);
        }

        // GET: TrainerCard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainerCard = await _context.TrainerCards.FindAsync(id);
            if (trainerCard == null)
            {
                return NotFound();
            }
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID", trainerCard.CardCatID);
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID", trainerCard.CardRarityID);
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID", trainerCard.CardTypeID);
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID", trainerCard.SetID);
            return View(trainerCard);
        }

        // POST: TrainerCard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardID,CardName,CardImageURL,CardImageHiURL,CardCatID,CardTypeID,SetID,CardNum,Artist,CardRarityID,LastUpdateDate")] TrainerCard trainerCard)
        {
            if (id != trainerCard.CardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainerCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainerCardExists(trainerCard.CardID))
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
            ViewData["CardCatID"] = new SelectList(_context.CardCats, "CardCatID", "CardCatID", trainerCard.CardCatID);
            ViewData["CardRarityID"] = new SelectList(_context.CardRarities, "CardRarityID", "CardRarityID", trainerCard.CardRarityID);
            ViewData["CardTypeID"] = new SelectList(_context.CardTypes, "CardTypeID", "CardTypeID", trainerCard.CardTypeID);
            ViewData["SetID"] = new SelectList(_context.Sets, "SetID", "SetID", trainerCard.SetID);
            return View(trainerCard);
        }

        // GET: TrainerCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainerCard = await _context.TrainerCards
                .Include(t => t.CardCat)
                .Include(t => t.CardRarity)
                .Include(t => t.CardType)
                .Include(t => t.Set)
                .FirstOrDefaultAsync(m => m.CardID == id);
            if (trainerCard == null)
            {
                return NotFound();
            }

            return View(trainerCard);
        }

        // POST: TrainerCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainerCard = await _context.TrainerCards.FindAsync(id);
            _context.TrainerCards.Remove(trainerCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerCardExists(int id)
        {
            return _context.TrainerCards.Any(e => e.CardID == id);
        }
    }
}
