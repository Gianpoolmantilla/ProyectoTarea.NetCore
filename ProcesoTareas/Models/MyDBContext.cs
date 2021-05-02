using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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
        // public object Tareas { get; internal set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estado>().HasData(
                new Estado {Id =1, CodEstado = 0, Descripcion = "Alta" },
                new Estado {Id =2, CodEstado = 50, Descripcion = "Modificacion"},
                new Estado {Id =3, CodEstado = 100, Descripcion = "Pendiente" }, 
                new Estado {Id =4, CodEstado = 600, Descripcion = "Realizado" },
                new Estado {Id =5, CodEstado = 900, Descripcion = "Rechazado" }
                );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nombre = "Administrador", Email = "soporte@mail.com", NombreuserId = "admin", Password = "123", Debaja = "", FechaAlta = DateTime.Now, UserId = "", FechaMod = DateTime.Now}
                );



            modelBuilder.Entity<Tarea>().HasQueryFilter(x=> x.Debaja =="N");
            modelBuilder.Entity<Prioridad>().HasQueryFilter(x => x.Debaja == "N");
            modelBuilder.Entity<TipoTarea>().HasQueryFilter(x => x.Debaja == "N");
           



        }



    }
}
