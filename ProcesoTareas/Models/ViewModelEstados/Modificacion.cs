using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models.ViewModelEstados
{
    public class Modificacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public string TipoTarea { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public string FechaAlta { get; set; }
        public string FechaVencimiento { get; set; }



        public string IdPrioridad { get; set; }
        public string IdTipoTarea { get; set; }
    }
}
