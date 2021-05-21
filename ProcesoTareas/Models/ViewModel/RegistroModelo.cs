using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Models.ViewModel
{
    public class RegistroModelo
    {
        [Required(ErrorMessage = "Email obligatorio")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Formato incorrecto")]
        [EmailAddress]
        [Remote(action: "comprobarEmail", controller: "Cuentas")]
        //[ValidarNombreUsuario(usuario: "joder", ErrorMessage = "Palabra no permitida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Usuario obligatorio")]
        public string User { get; set; }

        //[Required(ErrorMessage = "Password obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
   

        //[DataType(DataType.Password)]
        //[Display(Name = "Repetir Password")]
        //[Compare("Password", ErrorMessage = "La Password y la Password de confirmación no coinciden.")]
        //public string PasswordValidar { get; set; }

        //[Display(Name = "Ayuda Password")]
        //public string ayudaPass { get; set; }

    }
}
