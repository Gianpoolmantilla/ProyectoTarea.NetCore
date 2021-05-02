using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcesoTareas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProcesoTareas.Services;

namespace ProcesoTareas.Controllers
{
    public class ReportesController : Controller
    {
        private readonly MyDBContext _context;
        private readonly ReporteService _reporteService;


        public ReportesController(MyDBContext context)
        {
            _context = context;
            _reporteService = new ReporteService();
        }

        [HttpGet]
        public ActionResult TareaPorEstado()
        {
            var itemEstado = new SelectList(_context.Estados, "Id", "Descripcion");//_reporteService.GetFkEstados(_context.Estados);

            ViewBag.fkestado = itemEstado.ToList();

            return View(null);
        }


        [HttpPost]
        public ActionResult TareaPorEstado(string estado = null, string fechaD = null, string fechaH = null)
        {
            //List<Prioridad> Dsprioridad = _context.Prioridades.ToList();
            //List<Tarea> tarea = _context.Tarea.ToList();
            //List<TipoTarea> Dstipo = _context.TipoTareas.ToList();
            //List<Estado> DsStado = _context.Estados.ToList();
            var itemEstado = new SelectList(_context.Estados, "Id", "Descripcion");//_reporteService.GetFkEstados(_context.Estados);

            ViewBag.fkestado = itemEstado.ToList();

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
                var reporte = _reporteService.GetTareaPorEstados(_context, fechaD, fechaH, estado, estado);
                return View(reporte);               

            }
            else
            {   
                var reporte = _reporteService.GetTareaPorEstados(_context, fechaD, fechaH, "0", "6");
                return View(reporte);
            }

        }

      
    }
}
