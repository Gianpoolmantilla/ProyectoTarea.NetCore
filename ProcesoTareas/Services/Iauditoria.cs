using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models
{
    interface Iauditoria
    {

        public string Debaja { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UserId { get; set; }
        public DateTime FechaMod { get; set; } 


    }
}
