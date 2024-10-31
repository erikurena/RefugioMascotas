using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RefugioMascotas.Models;
using RefugioMascotas.dbContext;
using System.Transactions;
using System.IO;
using NuGet.Packaging.Signing;
using Microsoft.AspNetCore.Authorization;

namespace RefugioMascotas.Controllers
{
    [Authorize]
    public class MascotasController : Controller
    {
        private readonly dbRefugioContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MascotasController(dbRefugioContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnvironment = webHostEnviroment;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mascotas
                                  .Include(x => x.SexoNavigation)
                                  .Include(x => x.TipoMascotaNavigation)
                                  .Include(x => x.EstadoAdopcionNavigation)
                                    .ToListAsync());
        }

        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(x => x.SexoNavigation)
                .Include(x => x.EstadoAdopcionNavigation)
                .FirstOrDefaultAsync(m => m.IdMascota == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            ViewData["listaSexo"] = new SelectList(_context.sexo,"IdSexo","TipoSexo");
            ViewData["listaEstadoAdpciones"] = new SelectList(_context.EstadoAdopcions, "IdEstadoAdopcion", "EstadodeAdopcion");
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMascota,Nombre,Edad,SexoMascota,TipoMascotaNavigation,IdEstadoAdopcion,FotoFileMascota")] Mascota mascota)
        {
            try
            {
                _context.TipoMascotas.Add(mascota.TipoMascotaNavigation!);
                await _context.SaveChangesAsync();

                if (mascota.FotoFileMascota != null)
                {
                    await getFotoMascota(mascota);
                }

                mascota.FechaIngreso = DateOnly.FromDateTime(DateTime.Now);
               
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewData["listaSexo"] = new SelectList(_context.sexo, "IdSexo", "TipoSexo");
                ViewData["listaEstadoAdpciones"] = new SelectList(_context.EstadoAdopcions, "IdEstadoAdopcion", "EstadodeAdopcion");
                return View(mascota);
            }
        }

        private async Task getFotoMascota(Mascota mascota)
        {
            try
            {
                //formar el archivo
                string wwRootPath = _webHostEnvironment.WebRootPath;
                string extension = Path.GetExtension(mascota.FotoFileMascota!.FileName);
                string nombreFoto = $"{mascota.Nombre}{extension}";

                mascota.FotoMascota = nombreFoto;

                //copiar la foto en el proyeecto actual
                string filePath = Path.Combine($"{wwRootPath}/fotoMascotas/", nombreFoto);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await mascota.FotoFileMascota.CopyToAsync(fileStream);
                }                   
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la foto de la mascota.", ex);
            }
            
        }

        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["listaSexo"] = new SelectList(_context.sexo, "IdSexo", "TipoSexo");
            ViewData["listaEstadoAdpciones"] = new SelectList(_context.EstadoAdopcions, "IdEstadoAdopcion", "EstadodeAdopcion");

            var mascota = await _context.Mascotas.Include(x => x.TipoMascotaNavigation).FirstOrDefaultAsync(x => x.IdMascota == id);
            if (mascota == null)
            {
                return NotFound();
            }
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMascota,Nombre,Edad,SexoMascota,TipoMascotaNavigation,IdEstadoAdopcion,FotoFileMascota,FotoMascota")] Mascota mascota)
        {
            var mascotaUpdate = await _context.Mascotas.FindAsync(id);
            if(mascotaUpdate == null)
            {
                return NotFound();
            }

            if (mascota.FotoFileMascota != null)
            {
                await getFotoMascota(mascota);
                mascotaUpdate.FotoMascota = mascota.FotoMascota;
            }

            var tipoMascotaUpdate  = await _context.TipoMascotas.FirstOrDefaultAsync(x => x.IdTipoMascota == mascotaUpdate.IdMascota);
            tipoMascotaUpdate!.Especie = mascota.TipoMascotaNavigation!.Especie;
            tipoMascotaUpdate.Raza = mascota.TipoMascotaNavigation.Raza;

            _context.TipoMascotas.Update(tipoMascotaUpdate);
            await _context.SaveChangesAsync();

            mascotaUpdate.Nombre = mascota.Nombre;
            mascotaUpdate.SexoMascota = mascota.SexoMascota;
            mascotaUpdate.Edad = mascota.Edad;
            mascotaUpdate.IdEstadoAdopcion = mascota.IdEstadoAdopcion;

            try
            {
                _context.Update(mascotaUpdate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotaExists(mascota.IdMascota))
                {
                    return NotFound();
                }
                else
                {
                return View(mascota);
                }
            }
        }

       

        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(x => x.SexoNavigation)
                .Include(x => x.EstadoAdopcionNavigation)
                .FirstOrDefaultAsync(m => m.IdMascota == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);

            if ( mascota == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (mascota.FotoMascota != null)
            {
                string wwRootPath = _webHostEnvironment.WebRootPath;
                string filePath = Path.Combine($"{wwRootPath}/fotoMascotas/", mascota.FotoMascota);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();

            var eliminarTIpomascota = await _context.TipoMascotas.Include(x => x.Mascotas).FirstOrDefaultAsync(m => m.IdTipoMascota == mascota.IdTipoMascota);

            if (eliminarTIpomascota != null)
            {
                _context.TipoMascotas.Remove(eliminarTIpomascota);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        private bool MascotaExists(int id)
        {
            return _context.Mascotas.Any(e => e.IdMascota == id);
        }
    }
}
