using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using korean.Data;
using korean.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace korean.Controllers
{
    [Authorize]
    public class KoreanController : Controller
    {

        private readonly ApplicationDbContext _context;

        public KoreanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.words.ToListAsync());
        }

        // GET: Categories/Details/5
        [AllowAnonymous]
        public IActionResult kelimea()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult kelimeb()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult test()
        {
            return View();
        }
        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }
   

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,kelime,anlam")] korece korece)
        {
            if (ModelState.IsValid)
            {
                _context.Add(korece);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(korece);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.words.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,kelime,anlam")] korece korece)
        {
            if (id != korece.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(korece);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(korece.Id))
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
            return View(korece);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.words
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.words.FindAsync(id);
            _context.words.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.words.Any(e => e.Id == id);
        }
    }
}

