using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcesoTareas.Models;
using ProcesoTareas.Models.ViewModelEstados;
using ProcesoTareas.Services;

namespace ProcesoTareas.Controllers
{
    [Authorize]
    public class TareasController : Controller
    {
        private readonly MyDBContext _context;
        private readonly TareaService _tareaService;

        public TareasController(MyDBContext context)
        {
            _context = context;
            _tareaService = new TareaService();
        }

        #region estado de creacion

        // GET: Tareas/Create
        public IActionResult Create()
        {
            ViewBag.itemsPrioridad = _tareaService.GetFkPrioridad(_context.Prioridades);
            ViewBag.itemsTipoT = _tareaService.GetFkTipoTarea(_context.TipoTareas);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,TipoTareaId,Observacion,PrioridadId,EstadoId,Debaja,FechaAlta,UserId,FechaMod,FechaVencimiento")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                tarea.EstadoId = (int)CambioEstado.pendiente; //deja en estado pendiente
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
        #endregion


        #region estado de Modificacion

        public IActionResult Modificacion()
        {
            ViewBag.itemsPrioridad = _tareaService.GetFkPrioridad(_context.Prioridades);
            ViewBag.itemsTipoT = _tareaService.GetFkTipoTarea(_context.TipoTareas);
            List<Modificacion> Dstarea = _tareaService.GetModificacion(_context,"0","0");

            return View(Dstarea);
        }
        [HttpPost]
        public IActionResult Modificacion(string tipoTarea, string prioridad)
        {

            ViewBag.itemsPrioridad = _tareaService.GetFkPrioridad(_context.Prioridades);
            ViewBag.itemsTipoT = _tareaService.GetFkTipoTarea(_context.TipoTareas);
            List<Modificacion> Dstarea = _tareaService.GetModificacion(_context, tipoTarea, prioridad);

            return View(Dstarea);
        }

        // GET: Tareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tarea.FindAsync(id);
            ViewBag.itemsPrioridad = _tareaService.GetFkPrioridad(_context.Prioridades);
            ViewBag.itemsTipoT = _tareaService.GetFkTipoTarea(_context.TipoTareas);

            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

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
                    tarea.Debaja = "N";
                    tarea.EstadoId = (int)CambioEstado.modificacion; //estado modificacion
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
                return RedirectToAction(nameof(Modificacion));
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
            return RedirectToAction(nameof(Modificacion));
        }

        public async Task<IActionResult> DarBaja(int? id)
        {
            var Tarea = await _context.Tarea.FindAsync(id);
            Tarea.FechaMod = DateTime.Now;
            Tarea.Debaja = "S";
            _context.Tarea.Update(Tarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Modificacion));
        }

        private bool TareaExists(int id)
        {
            return _context.Tarea.Any(e => e.Id == id);
        }

        #endregion


        #region estado Pendiente

        public IActionResult Pendientes()
        {
            List<Pendiente> Dstarea = _tareaService.GetPendiente(_context);

            return View(Dstarea);
        }


        public async Task<IActionResult> Realizado(int? id)
        {
            var tarea = await _context.Tarea.FindAsync(id);
            tarea.FechaMod = DateTime.Now;
            tarea.EstadoId = (int)CambioEstado.realizado; // estado realizado
            _context.Tarea.Update(tarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Pendientes));
        }
        public async Task<IActionResult> Rechazado(int? id)
        {
            var tarea = await _context.Tarea.FindAsync(id);
            tarea.FechaMod = DateTime.Now;
            tarea.EstadoId = (int)CambioEstado.rechazado; // estado Rechazado
            _context.Tarea.Update(tarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Pendientes));
        }


        #endregion




    }
}
