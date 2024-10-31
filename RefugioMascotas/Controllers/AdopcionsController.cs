using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RefugioMascotas.Models;
using RefugioMascotas.dbContext;
using System.Security.Claims;
using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Authorization;

namespace RefugioMascotas.Controllers
{
    [Authorize]
    public class AdopcionsController : Controller
    {
        private readonly dbRefugioContext _context;

        public AdopcionsController(dbRefugioContext context)
        {
            _context = context;
        }

        // GET: Adopcions
        public async Task<IActionResult> Index()
        {
            return View(await _context.adopcions
                                                .Include(x => x.MascotaNavigation)
                                                .Include(x => x.AdoptanteNavigation)
                                                .ToListAsync());
        }

        // GET: Adopcions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.adopcions
                .FirstOrDefaultAsync(m => m.IdAdopcion == id);
            if (adopcion == null)
            {
                return NotFound();
            }

            return View(adopcion);
        }

        // GET: Adopcions/Create
        public IActionResult Create()
        {
            ViewData["listaSexo"] = new SelectList(_context.sexo, "IdSexo", "TipoSexo");
            ViewData["listaMascotas"] = new SelectList(_context.Mascotas.Where(x => x.IdEstadoAdopcion != 2), "IdMascota", "Nombre");
            return View();
        }

        // POST: Adopcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdopcion,FechaAdopcion,IdMascota")] Adopcion adopcion,  Adoptante adoptante)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.adoptantes.Add(adoptante);
                await _context.SaveChangesAsync();

                adopcion.IdAdoptante = adoptante.IdAdoptante;
                adopcion.IdEmpleado = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

                _context.adopcions.Add(adopcion);
                await _context.SaveChangesAsync();

                var idmascota = adopcion.IdMascota;
                var UpdateEstateMascota = _context.Mascotas.Find(idmascota);

                UpdateEstateMascota!.IdEstadoAdopcion = 2;

                _context.Mascotas.Update(UpdateEstateMascota);
                await  _context.SaveChangesAsync();

                transaction.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                transaction.Rollback();
                ViewData["listaSexo"] = new SelectList(_context.sexo, "IdSexo", "TipoSexo");
                ViewData["listaMascotas"] = new SelectList(_context.Mascotas.Where(x => x.IdEstadoAdopcion != 2), "IdMascota", "Nombre");
                return View(adopcion);
            }
        }

        // GET: Adopcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.adopcions.FindAsync(id);
            if (adopcion == null)
            {
                return NotFound();
            }
            return View(adopcion);
        }

        // POST: Adopcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdopcion,FechaAdopcion")] Adopcion adopcion)
        {
            if (id != adopcion.IdAdopcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adopcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdopcionExists(adopcion.IdAdopcion))
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
            return View(adopcion);
        }

        // GET: Adopcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.adopcions
                .FirstOrDefaultAsync(m => m.IdAdopcion == id);
            if (adopcion == null)
            {
                return NotFound();
            }

            return View(adopcion);
        }

        // POST: Adopcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adopcion = await _context.adopcions.FindAsync(id);
            if (adopcion != null)
            {
                _context.adopcions.Remove(adopcion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdopcionExists(int id)
        {
            return _context.adopcions.Any(e => e.IdAdopcion == id);
        }
    }
}
