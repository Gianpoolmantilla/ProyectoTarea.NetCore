using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcesoTareas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProcesoTareas.Controllers
{
    public class ReportesController : Controller
    {
        private readonly MyDBContext _context;

        public ReportesController(MyDBContext context)
        {
            _context = context;
        }

        public ActionResult TareaPorEstado()
        {
            List<Estado> DsEstados = _context.Estados.ToList();
            var est = (from p in DsEstados
                       select new Estado
                       {
                           Id = p.Id,
                           Descripcion = p.Descripcion
                       }).ToList();

            List<SelectListItem> itemEstado = est.ConvertAll(e =>
            {
                return new SelectListItem()
                {
                    Text = e.Descripcion,
                    Value = e.Id.ToString(),
                    Selected = false

                };
            });

            ViewBag.fkestado = itemEstado.ToList();

            return View(null);
        }


        [HttpPost]
        public ActionResult TareaPorEstado(int? estado = null, string fechaD = null, string fechaH = null)
        {
            List<Prioridad> Dsprioridad = _context.Prioridades.ToList();
            List<Tarea> tarea = _context.Tarea.ToList();
            List<TipoTarea> Dstipo = _context.TipoTareas.ToList();
            List<Estado> DsStado = _context.Estados.ToList();

          
            if (fechaD == null)
            {
                fechaD = "1900-01-01";
            }
            if (fechaH == null)
            {
                fechaH = "2060-01-01";
            }


            if (estado != null && fechaD != null && fechaH != null)
            {
                var reporte = from tr in tarea
                              join ti in Dstipo on tr.TipoTareaId equals ti.Id
                              join pri in Dsprioridad on tr.PrioridadId equals pri.Id
                              join est in DsStado on tr.EstadoId equals est.Id
                              where tr.EstadoId == estado &&
                              (tr.FechaAlta >= DateTime.Parse(fechaD) && tr.FechaAlta <= DateTime.Parse(fechaH))

                              select new Reportes
                              {
                                  TipoTarea = ti,
                                  Tarea = tr,
                                  Prioridad = pri,
                                  Estado = est

                              };

                return View(reporte);               

            }
            else
            {
                var reporte = from tr in tarea
                              join ti in Dstipo on tr.TipoTareaId equals ti.Id
                              join pri in Dsprioridad on tr.PrioridadId equals pri.Id
                              join est in DsStado on tr.EstadoId equals est.Id
                              where (tr.FechaAlta >= DateTime.Parse(fechaD) && tr.FechaAlta <= DateTime.Parse(fechaH))

                              select new Reportes
                              {
                                  TipoTarea = ti,
                                  Tarea = tr,
                                  Prioridad = pri,
                                  Estado = est

                              };

                return View(reporte);
            }


        }

      
    }
}
