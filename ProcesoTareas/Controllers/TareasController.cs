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
    public class TareasController : Controller
    {
        private readonly MyDBContext _context;

        public TareasController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Tareas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tarea.ToListAsync());
        }      

        // GET: Tareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tarea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // GET: Tareas/Create
        public IActionResult Create()
        {
            Tarea Coleccion = new Tarea();            
            //Coleccion.FechaVencimiento = DateTime.Now.AddDays(+1);
            Coleccion.Prioridad = _context.Prioridades.ToList();
            Coleccion.TipoTarea= _context.TipoTareas.ToList();
            return View(Coleccion);
        }

        // POST: Tareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,TipoTareaId,Observacion,PrioridadId,EstadoId,Debaja,FechaAlta,UserId,FechaMod,FechaVencimiento")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                tarea.EstadoId = 0;
                tarea.FechaAlta = DateTime.Now;
                tarea.FechaMod = DateTime.Now;
                tarea.Debaja = "N";
                tarea.UserId = "";
                _context.Add(tarea);
                await _context.SaveChangesAsync();
            

                if (ModelState.ErrorCount == 0)
                {
                    return RedirectToAction(nameof(Create));
                }

            }
            return View(tarea);
        }

        // GET: Tareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tarea.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        // POST: Tareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,TipoTareaId,Observacion,PrioridadId,EstadoId,Debaja,FechaAlta,UserId,FechaMod")] Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareaExists(tarea.Id))
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
            return View(tarea);
        }

        // GET: Tareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tarea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarea = await _context.Tarea.FindAsync(id);
            _context.Tarea.Remove(tarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TareaExists(int id)
        {
            return _context.Tarea.Any(e => e.Id == id);
        }
    }
}
