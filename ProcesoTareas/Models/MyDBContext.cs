using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models
{
    public class MyDBContext : DbContext 
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }

        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
        public DbSet<TipoTarea> TipoTareas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public object Tareas { get; internal set; }
    }
}
