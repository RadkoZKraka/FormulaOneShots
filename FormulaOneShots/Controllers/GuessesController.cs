using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormulaOneShots.Data;
using FormulaOneShots.Models;

namespace FormulaOneShots.Controllers
{
    public class GuessesController : Controller
    {
        private readonly GuessesContext _context;

        public GuessesController(GuessesContext context)
        {
            _context = context;
        }

        // GET: Guesses
        public async Task<IActionResult> Index()
        {
              return _context.Shots != null ? 
                          View(await _context.Shots.ToListAsync()) :
                          Problem("Entity set 'GuessesContext.Shots'  is null.");
        }

        // GET: Guesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shots == null)
            {
                return NotFound();
            }

            var shots = await _context.Shots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shots == null)
            {
                return NotFound();
            }

            return View(shots);
        }

        // GET: Guesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User,PolePosition,RandomGuess,LastChange")] Shots shots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shots);
        }

        // GET: Guesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shots == null)
            {
                return NotFound();
            }

            var shots = await _context.Shots.FindAsync(id);
            if (shots == null)
            {
                return NotFound();
            }
            return View(shots);
        }

        // POST: Guesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User,PolePosition,RandomGuess,LastChange")] Shots shots)
        {
            if (id != shots.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShotsExists(shots.Id))
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
            return View(shots);
        }

        // GET: Guesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shots == null)
            {
                return NotFound();
            }

            var shots = await _context.Shots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shots == null)
            {
                return NotFound();
            }

            return View(shots);
        }

        // POST: Guesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shots == null)
            {
                return Problem("Entity set 'GuessesContext.Shots'  is null.");
            }
            var shots = await _context.Shots.FindAsync(id);
            if (shots != null)
            {
                _context.Shots.Remove(shots);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShotsExists(int id)
        {
          return (_context.Shots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
