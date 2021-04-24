using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcesoTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace ProcesoTareas.Controllers
{
    public class ReportesController : Controller
    {
        private  MyDBContext _context;

        public ReportesController(MyDBContext context)
        {
            _context = context;
        }
        public ActionResult TareaPorEstado()
        {
            List<Prioridad> Dsprioridad = _context.Prioridades.ToList();
            List<Tarea> tarea = _context.Tarea.ToList();           
            List<TipoTarea> Dstipo = _context.TipoTareas.ToList();
            List<Estado> DsStado = _context.Estados.ToList();

            var reporte = from tr in tarea
                          join ti in Dstipo on tr.TipoTareaId equals ti.Id into table1
                          from ti in table1.DefaultIfEmpty()
                          join pri in Dsprioridad on tr.PrioridadId equals pri.Id into table2
                          from pri in table2.DefaultIfEmpty()
                          join est in DsStado on tr.EstadoId equals est.CodEstado into table3
                          from est in table3.DefaultIfEmpty()
                          select new Reportes { TipoTarea = ti, Tarea = tr, Prioridad = pri , Estado = est};

            return View(reporte);
        }

        //public ActionResult TareaPorEstado(int id)
        //{
        //    List<Prioridad> Dsprioridad = _context.Prioridades.ToList();
        //    List<Tarea> tarea = _context.Tarea.ToList();
        //    List<TipoTarea> Dstipo = _context.TipoTareas.ToList();

        //    if (id == null)
        //    {
        //        var reporte = from tr in tarea
        //                      join ti in Dstipo on tr.TipoTareaId equals ti.Id into table1
        //                      from ti in table1.DefaultIfEmpty()
        //                      join pri in Dsprioridad on tr.PrioridadId equals pri.Id into table2
        //                      from pri in table2.DefaultIfEmpty()
        //                      where tr.Id == id
        //                      select new Reportes
        //                      {
        //                          TipoTarea = ti,
        //                          Tarea = tr,
        //                          Prioridad = pri
        //                      };

        //        return View(reporte.SingleOrDefault());
        //    }
        //    else
        //    {
        //        var reporte = from tr in tarea
        //                      join ti in Dstipo on tr.TipoTareaId equals ti.Id into table1
        //                      from ti in table1.DefaultIfEmpty()
        //                      join pri in Dsprioridad on tr.PrioridadId equals pri.Id into table2
        //                      from pri in table2.DefaultIfEmpty()
        //                      select new Reportes { TipoTarea = ti, Tarea = tr, Prioridad = pri };

        //        return View(reporte);
        //    }
          
        //}
    }
}
