using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcesoTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Services
{
    public interface IReporteService
    {
        public List<SelectListItem> GetFkEstados(DbSet<Estado> Estado);

        public IQueryable<Reportes> GetTareaPorEstados(DbContext context, string fechaD, string fechaH, string estadoD, string estadoH);
    }
}
