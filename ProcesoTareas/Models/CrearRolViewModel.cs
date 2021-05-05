using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models
{
    public class CrearRolViewModel
    {
        [Required(ErrorMessage ="Este campo es Obligatorio")]
        [Display(Name ="Rol")]
        public string NombreRol { get; set; }
    }
}
