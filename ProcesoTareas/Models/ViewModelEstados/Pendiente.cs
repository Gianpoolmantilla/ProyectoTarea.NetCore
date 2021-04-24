using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models.ViewModelEstados
{
    public class Pendiente
    {
        //public Prioridad Prioridad { get; set; }
        //public Pendiente Tarea { get; set; }
        //public TipoTarea TipoTarea { get; set; }
        //public Estado Estado { get; set; }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public string TipoTarea { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaVencimiento { get; set; }

    }
}
