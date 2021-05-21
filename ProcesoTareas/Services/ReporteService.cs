using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcesoTareas.Models;
using ProcesoTareas.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Services
{
    public class ReporteService : IReporteService
    {
        private MyDBContext _context;
        public List<SelectListItem> GetFkEstados(DbSet<Estado> Estado)
        {
         
            var est = (from p in Estado
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


            return itemEstado;
        }

        public IQueryable<Reportes> GetTareaPorEstados(DbContext context, string fechaD, string fechaH, string estadoD, string estadoH)
        {
            _context = (MyDBContext)context;

            var reporte = from tr in _context.Tarea
                          join ti in _context.TipoTareas on tr.TipoTareaId equals ti.Id
                          join pri in _context.Prioridades on tr.PrioridadId equals pri.Id
                          join est in _context.Estados on tr.EstadoId equals est.Id
                          where tr.Debaja == "N" 
                          && (tr.EstadoId >= int.Parse(estadoD) && tr.EstadoId <= int.Parse(estadoH))
                          && (tr.FechaAlta >= DateTime.Parse(fechaD) && tr.FechaAlta <= DateTime.Parse(fechaH))

                          select new Reportes
                          {
                              TipoTarea = ti,
                              Tarea = tr,
                              Prioridad = pri,
                              Estado = est

                          };

            return reporte;


        }
    }
}
