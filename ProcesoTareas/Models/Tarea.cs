using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models
{
    public class Tarea : Iauditoria
    {
        public int Id { get; set; }
        public  string Nombre { get; set; }
      
        public string Observacion { get; set; }

        //forenkey
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public Nullable<int> TipoTareaId { get; set; }
        public List<TipoTarea> TipoTarea { get; set; }
       
    
        //forenkey
        [Required(ErrorMessage = "El campo prioridad es obligatorio")]
        public Nullable<int> PrioridadId { get; set; }
        public List<Prioridad> Prioridad { get; set; }
   

        //forenkey
        public Nullable<int> EstadoId { get; set; }
        public List<Estado> Estado { get; set; }

        public string Debaja { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UserId { get; set ; }
        public DateTime FechaMod { get ; set ; }

        [Required(ErrorMessage = "El campo prioridad es obligatorio")]
        public DateTime FechaVencimiento { get; set; }



        //public  Tarea dsTarea { get; set; }
        //public  TipoTarea dsTipoTarea { get; set; }
        //public  Prioridad dsPrioridad { get; set; }
    }
}
