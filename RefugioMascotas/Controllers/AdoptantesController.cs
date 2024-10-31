using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RefugioMascotas.Models;
using RefugioMascotas.dbContext;
using Microsoft.AspNetCore.Authorization;

namespace RefugioMascotas.Controllers
{
    [Authorize]
    public class AdoptantesController : Controller
    {
        private readonly dbRefugioContext _context;

        public AdoptantesController(dbRefugioContext context)
        {
            _context = context;
        }

        // GET: Adoptantes
        public async Task<IActionResult> Index()
        {
            var dbRefugioContext = _context.adoptantes.Include(a => a.SexoNavigation);
            return View(await dbRefugioContext.ToListAsync());
        }

        // GET: Adoptantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptante = await _context.adoptantes
                .Include(a => a.SexoNavigation)
                .FirstOrDefaultAsync(m => m.IdAdoptante == id);
            if (adoptante == null)
            {
                return NotFound();
            }

            return View(adoptante);
        }

        // GET: Adoptantes/Create
        public  IActionResult Create()
        {
            ViewData["listaSexo"] = new SelectList(_context.sexo, "IdSexo", "TipoSexo");
            return View();
        }

        // POST: Adoptantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdoptante,Nombre,Apellido,IdSexo,Direccion,Telefono")] Adoptante adoptante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSexo"] = new SelectList(_context.sexo, "IdSexo", "IdSexo", adoptante.IdSexo);
            return View(adoptante);
        }

        // GET: Adoptantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptante = await _context.adoptantes.FindAsync(id);
            if (adoptante == null)
            {
                return NotFound();
            }
            ViewData["IdSexo"] = new SelectList(_context.sexo, "IdSexo", "IdSexo", adoptante.IdSexo);
            return View(adoptante);
        }

        // POST: Adoptantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdoptante,Nombre,Apellido,IdSexo,Direccion,Telefono")] Adoptante adoptante)
        {
            if (id != adoptante.IdAdoptante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptanteExists(adoptante.IdAdoptante))
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
            ViewData["IdSexo"] = new SelectList(_context.sexo, "IdSexo", "IdSexo", adoptante.IdSexo);
            return View(adoptante);
        }

        // GET: Adoptantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptante = await _context.adoptantes
                .Include(a => a.SexoNavigation)
                .FirstOrDefaultAsync(m => m.IdAdoptante == id);
            if (adoptante == null)
            {
                return NotFound();
            }

            return View(adoptante);
        }

        // POST: Adoptantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptante = await _context.adoptantes.FindAsync(id);
            if (adoptante != null)
            {
                _context.adoptantes.Remove(adoptante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptanteExists(int id)
        {
            return _context.adoptantes.Any(e => e.IdAdoptante == id);
        }
    }
}
