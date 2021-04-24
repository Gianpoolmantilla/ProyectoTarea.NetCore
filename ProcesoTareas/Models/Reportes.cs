using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models
{
    public class Reportes
    {

        public Prioridad Prioridad { get; set; }
        public Tarea Tarea { get; set; }
        public TipoTarea TipoTarea { get; set; }
        public Estado Estado { get; set; }
    }
}
