using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models.ViewModel
{
    public class Reportes
    {

        public Prioridad Prioridad { get; set; }
        public Tarea Tarea { get; set; }
        public TipoTarea TipoTarea { get; set; }
        public Estado Estado { get; set; }


        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }     
        public string FechaAlta { get; set; }
        public string FechaVencimiento { get; set; }

        public string Estados { get; set; }

    }
}
