using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcesoTareas.Models;

namespace ProcesoTareas.Controllers
{
    public class PrioridadsController : Controller
    {
        private readonly MyDBContext _context;

        public PrioridadsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Prioridads
        public async Task<IActionResult> Index()
        {
            var recuperoActivos = from tt in _context.Prioridades
                                  where tt.Debaja == "N"
                                  select new Prioridad
                                  {
                                      Id = tt.Id,
                                      Descripcion = tt.Descripcion
                                  };

            return View(recuperoActivos);
        }

        // GET: Prioridads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridad = await _context.Prioridades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prioridad == null)
            {
                return NotFound();
            }

            return View(prioridad);
        }

        // GET: Prioridads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prioridads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Debaja,FechaAlta,UserId,FechaMod")] Prioridad prioridad)
        {
            if (ModelState.IsValid)
            {
                prioridad.FechaAlta = DateTime.Now;
                prioridad.FechaMod = DateTime.Now;
                prioridad.Debaja = "N";
                prioridad.UserId = "";
                _context.Add(prioridad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prioridad);
        }

        // GET: Prioridads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridad = await _context.Prioridades.FindAsync(id);
            if (prioridad == null)
            {
                return NotFound();
            }
            return View(prioridad);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Debaja,FechaAlta,UserId,FechaMod")] Prioridad prioridad)
        {
            if (id != prioridad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    prioridad.FechaMod = DateTime.Now;
                    _context.Update(prioridad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrioridadExists(prioridad.Id))
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
            return View(prioridad);
        }

        // GET: Prioridads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridad = await _context.Prioridades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prioridad == null)
            {
                return NotFound();
            }

            return View(prioridad);
        }

        // POST: Prioridads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prioridad = await _context.Prioridades.FindAsync(id);
            _context.Prioridades.Remove(prioridad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DarBaja(int? id)
        {
            var tipoTarea = await _context.Prioridades.FindAsync(id);
            tipoTarea.FechaMod = DateTime.Now;
            tipoTarea.Debaja = "S";
            _context.Prioridades.Update(tipoTarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool PrioridadExists(int id)
        {
            return _context.Prioridades.Any(e => e.Id == id);
        }
    }
}
