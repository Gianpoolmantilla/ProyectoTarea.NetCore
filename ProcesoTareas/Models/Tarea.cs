using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models
{
    public class Tarea : Iauditoria
    {
        [Key]       
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Tipo es obligatorio")] //revision
        public  string Nombre { get; set; }      
        public string Observacion { get; set; }

        //forenkey
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public int TipoTareaId { get; set; }
        public  TipoTarea TipoTarea { get; set; }
           
        //forenkey
        [Required(ErrorMessage = "El campo prioridad es obligatorio")]
        public int PrioridadId { get; set; }
        public Prioridad Prioridad { get; set; }
   
        //forenkey
        public int EstadoId { get; set; }
        public  Estado Estado { get; set; }
        [StringLength(1)]
        public string Debaja { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UserId { get; set ; }
        public DateTime FechaMod { get ; set ; }

        [Required(ErrorMessage = "El campo vencimiento es obligatorio")]
        public DateTime FechaVencimiento { get; set; }

           
    }
}
