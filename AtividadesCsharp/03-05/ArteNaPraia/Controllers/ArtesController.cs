using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArteNaPraia.obj.Debug;

namespace ArteNaPraia.Controllers
{
    public class ArtesController : Controller
    {
        private readonly ArteNaPraiaContext _context;

        public ArtesController(ArteNaPraiaContext context)
        {
            _context = context;
        }

        // GET: Artes
        public async Task<IActionResult> Index()
        {
            var arteNaPraiaContext = _context.Arte.Include(a => a.Artista);
            return View(await arteNaPraiaContext.ToListAsync());
        }

        // GET: Artes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arte = await _context.Arte
                .Include(a => a.Artista)
                .FirstOrDefaultAsync(m => m.IdArte == id);
            if (arte == null)
            {
                return NotFound();
            }

            return View(arte);
        }

        // GET: Artes/Create
        public IActionResult Create()
        {
            ViewData["IdArtista"] = new SelectList(_context.Set<Artista>(), "IdArtista", "IdArtista");
            return View();
        }

        // POST: Artes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArte,Nome,Preco,Descricao,IdArtista")] Arte arte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArtista"] = new SelectList(_context.Set<Artista>(), "IdArtista", "IdArtista", arte.IdArtista);
            return View(arte);
        }

        // GET: Artes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arte = await _context.Arte.FindAsync(id);
            if (arte == null)
            {
                return NotFound();
            }
            ViewData["IdArtista"] = new SelectList(_context.Set<Artista>(), "IdArtista", "IdArtista", arte.IdArtista);
            return View(arte);
        }

        // POST: Artes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArte,Nome,Preco,Descricao,IdArtista")] Arte arte)
        {
            if (id != arte.IdArte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArteExists(arte.IdArte))
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
            ViewData["IdArtista"] = new SelectList(_context.Set<Artista>(), "IdArtista", "IdArtista", arte.IdArtista);
            return View(arte);
        }

        // GET: Artes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arte = await _context.Arte
                .Include(a => a.Artista)
                .FirstOrDefaultAsync(m => m.IdArte == id);
            if (arte == null)
            {
                return NotFound();
            }

            return View(arte);
        }

        // POST: Artes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arte = await _context.Arte.FindAsync(id);
            _context.Arte.Remove(arte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArteExists(int id)
        {
            return _context.Arte.Any(e => e.IdArte == id);
        }
    }
}
