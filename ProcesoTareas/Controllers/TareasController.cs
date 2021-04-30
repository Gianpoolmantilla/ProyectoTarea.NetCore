using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcesoTareas.Models;
using ProcesoTareas.Models.ViewModelEstados;

namespace ProcesoTareas.Controllers
{
    public class TareasController : Controller
    {
        private readonly MyDBContext _context;

        public TareasController(MyDBContext context)
        {
            _context = context;
        }

        #region Crear

        // GET: Tareas/Create
        public IActionResult Create()
        {
         
            var priori = (from p in _context.Prioridades
                          where p.Debaja == "N"
                          select new Prioridad
                          {
                              Id = p.Id,
                              Descripcion = p.Descripcion
                          }).ToList();

            var tipota = (from t in _context.TipoTareas
                          where t.Debaja == "N"
                          select new TipoTarea
                          {
                              Id = t.Id,
                              Descripcion = t.Descripcion
                          }).ToList();

            List<SelectListItem> itemsPrioridad = priori.ConvertAll(p =>
            {
                return new SelectListItem()
                {
                    Text = p.Descripcion.ToString(),
                    Value = p.Id.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> itemsTipoTarea = tipota.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });


            ViewBag.itemsPrioridad = itemsPrioridad;
            ViewBag.itemsTipoT = itemsTipoTarea;
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


        #region Modificacion

        public IActionResult Modificacion()
        {
            List<Prioridad> Dsprioridad = _context.Prioridades.ToList();
            List<TipoTarea> Dstipo = _context.TipoTareas.ToList();


            List<Modificacion> Dstarea = (from Tr in _context.Tarea
                                          join ti in _context.TipoTareas
                                          on Tr.TipoTareaId equals ti.Id
                                          join pr in _context.Prioridades
                                          on Tr.PrioridadId equals pr.Id
                                          where Tr.Debaja == "N"
                                          select new Modificacion
                                          {
                                              Id = Tr.Id,
                                              TipoTarea = ti.Descripcion,
                                              Prioridad = pr.Descripcion,
                                              Nombre = Tr.Nombre,
                                              FechaAlta = Tr.FechaAlta.ToString("yyyy-MM-dd HH:mm"),
                                              FechaVencimiento = Tr.FechaVencimiento.ToString("yyyy-MM-dd"),
                                              Observacion = Tr.Observacion


                                          }).ToList();

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
            /// revisar
            //tarea.Prioridad = _context.Prioridades.ToList();
            //tarea.TipoTarea = _context.TipoTareas.ToList();

            var priori = (from p in _context.Prioridades
                          select new Prioridad
                          {
                              Id = p.Id,
                              Descripcion = p.Descripcion
                          }).ToList();

            var tipota = (from t in _context.TipoTareas
                          select new TipoTarea
                          {
                              Id = t.Id,
                              Descripcion = t.Descripcion
                          }).ToList();

            List<SelectListItem> itemsPrioridad = priori.ConvertAll(p =>
            {
                return new SelectListItem()
                {
                    Text = p.Descripcion.ToString(),
                    Value = p.Id.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> itemsTipoTarea = tipota.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });


            ViewBag.itemsPrioridad = itemsPrioridad;
            ViewBag.itemsTipoT = itemsTipoTarea;



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


        #region Pendientes

        public IActionResult Pendientes()
        {
            List<Prioridad> Dsprioridad = _context.Prioridades.ToList();
            List<TipoTarea> Dstipo = _context.TipoTareas.ToList();


            List<Pendiente> Dstarea = (from Tr in _context.Tarea
                                       join ti in _context.TipoTareas
                                       on Tr.TipoTareaId equals ti.Id
                                       join pr in _context.Prioridades
                                       on Tr.PrioridadId equals pr.Id
                                       join est in _context.Estados
                                       on Tr.EstadoId equals est.Id 
                                       where Tr.Debaja == "N" &&
                                       est.CodEstado >= 0 && est.CodEstado <= 100
                                       select new Pendiente
                                       {
                                           Id = Tr.Id,
                                           TipoTarea = ti.Descripcion,
                                           Prioridad = pr.Descripcion,
                                           Nombre = Tr.Nombre,
                                           FechaAlta = Tr.FechaAlta.ToString("yyyy-MM-dd"),
                                           FechaVencimiento = Tr.FechaVencimiento.ToString("yyyy-MM-dd HH:mm"),
                                           Observacion = Tr.Observacion


                                       }).ToList();

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
