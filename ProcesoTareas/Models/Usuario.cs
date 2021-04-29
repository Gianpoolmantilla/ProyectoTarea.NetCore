using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models
{
    public class Usuario : Iauditoria
    {
        [Key]
        
        public int Id { get; set; }
        [Required(ErrorMessage = "este campo Nombre es requerido")]
        public string Nombre { get; set; }
        public string Email { get; set; }      

        [DisplayName("UserId")]
        [Required(ErrorMessage = "este campo UserId es requerido")]
        public string NombreuserId { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "este campo es requerido")]
        public string Password { get; set; }

        public string Debaja { get; set ; }
        public DateTime FechaAlta { get; set; }
        public string UserId { get; set; }
        public DateTime FechaMod { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
