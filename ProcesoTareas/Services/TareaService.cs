using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcesoTareas.Models;
using ProcesoTareas.Models.ViewModelEstados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Services
{
    public class TareaService : ITareaService
    {
        private  MyDBContext _context;
        public List<SelectListItem> GetFkPrioridad(DbSet<Prioridad> Prioridad)
        {

            var priori = (from p in Prioridad
                          where p.Debaja == "N"
                          select new Prioridad
                          {
                              Id = p.Id,
                              Descripcion = p.Descripcion
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

            return itemsPrioridad;
        }

        public List<SelectListItem> GetFkTipoTarea(DbSet<TipoTarea> TipoTarea)
        {
            var tipota = (from t in TipoTarea
                          where t.Debaja == "N"
                          select new TipoTarea
                          {
                              Id = t.Id,
                              Descripcion = t.Descripcion
                          }).ToList();


            List<SelectListItem> itemsTipoTarea = tipota.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });

            return itemsTipoTarea;
        }



        public List<Pendiente> GetPendiente(DbContext context)
        {
            _context = (MyDBContext)context;

            var list = (from Tr in _context.Tarea
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

            return list;
        }


        public List<Modificacion> GetModificacion(DbContext context)
        {
            _context = (MyDBContext)context;

            var list = (from Tr in _context.Tarea
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

            return list;
        }



    }
}
