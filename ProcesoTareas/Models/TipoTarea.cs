using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models
{
    public class TipoTarea :Iauditoria
    {
        [Key]       
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [StringLength(1)]
        public string Debaja { get ; set ; }
        public DateTime FechaAlta { get ; set; }
        public string UserId { get ; set; }
        public DateTime FechaMod { get ; set; }
        public ICollection<Tarea> Tarea { get; set; }

    }
}
