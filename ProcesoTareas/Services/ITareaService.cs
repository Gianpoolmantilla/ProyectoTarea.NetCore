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
    public interface ITareaService
    {

        public List<SelectListItem> GetFkPrioridad(DbSet<Prioridad> Prioridad);
        public List<SelectListItem> GetFkTipoTarea(DbSet<TipoTarea> TipoTarea);    
        public List<Pendiente> GetPendiente(DbContext context);
        public List<Modificacion> GetModificacion(DbContext context);

    }
}
