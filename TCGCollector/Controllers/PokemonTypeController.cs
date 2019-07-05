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
    public class PokemonTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PokemonTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PokemonType
        public async Task<IActionResult> Index()
        {
            return View(await _context.PokemonTypes.ToListAsync());
        }

        // GET: PokemonType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonType = await _context.PokemonTypes
                .FirstOrDefaultAsync(m => m.PokemonTypeID == id);
            if (pokemonType == null)
            {
                return NotFound();
            }

            return View(pokemonType);
        }

        // GET: PokemonType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PokemonType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PokemonTypeID,PokemonTypeName,LastUpdateDate")] PokemonType pokemonType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemonType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokemonType);
        }

        // GET: PokemonType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonType = await _context.PokemonTypes.FindAsync(id);
            if (pokemonType == null)
            {
                return NotFound();
            }
            return View(pokemonType);
        }

        // POST: PokemonType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PokemonTypeID,PokemonTypeName,LastUpdateDate")] PokemonType pokemonType)
        {
            if (id != pokemonType.PokemonTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemonType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonTypeExists(pokemonType.PokemonTypeID))
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
            return View(pokemonType);
        }

        // GET: PokemonType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonType = await _context.PokemonTypes
                .FirstOrDefaultAsync(m => m.PokemonTypeID == id);
            if (pokemonType == null)
            {
                return NotFound();
            }

            return View(pokemonType);
        }

        // POST: PokemonType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemonType = await _context.PokemonTypes.FindAsync(id);
            _context.PokemonTypes.Remove(pokemonType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonTypeExists(int id)
        {
            return _context.PokemonTypes.Any(e => e.PokemonTypeID == id);
        }
    }
}
