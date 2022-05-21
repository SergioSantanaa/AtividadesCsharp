using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArteNaPraia.Models;

namespace ArteNaPraia.Controllers
{
    public class ArtistaController : Controller
    {
        private readonly ArteNaPraiaContext _context;

        public ArtistaController(ArteNaPraiaContext context)
        {
            _context = context;
        }

        // GET: Artista
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artista.ToListAsync());
        }

        // GET: Artista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = await _context.Artista
                .FirstOrDefaultAsync(m => m.IdArtista == id);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }

        // GET: Artista/Create
        public IActionResult Create()
        {
            ViewBag.ErroChavePix= "";
            return View();
        }

        // POST: Artista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArtista,Nome,ChavePix")] Artista artista)
        {
            ViewBag.ErroChavePix = "";
           var chavePix = _context.Artista.FirstOrDefault(a=>a.ChavePix == artista.ChavePix);
           if (chavePix == null)
           {

         
            if (ModelState.IsValid)
            {
                _context.Add(artista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

           }else
           {
               ViewBag.ErroChavePix = "A chave pix já existe, cadastre outra";
           }
            return View(artista);
         
        }
        // GET: Artista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = await _context.Artista.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }
            return View(artista);
        }

        // POST: Artista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArtista,Nome,ChavePix")] Artista artista)
        {
            if (id != artista.IdArtista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistaExists(artista.IdArtista))
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
            return View(artista);
        }

        // GET: Artista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = await _context.Artista
                .FirstOrDefaultAsync(m => m.IdArtista == id);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }

        // POST: Artista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artista = await _context.Artista.FindAsync(id);
            _context.Artista.Remove(artista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistaExists(int id)
        {
            return _context.Artista.Any(e => e.IdArtista == id);
        }
    }
}
