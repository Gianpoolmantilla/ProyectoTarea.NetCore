﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace ProcesoTareas.Models
{
    public class LoginViewModelo
    {

        [Required(ErrorMessage = "Email obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password obligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Recuerdame")]
        public bool Recuerdame { get; set; }

        public string UrlRetorno { get; set; }

        public IList<AuthenticationScheme> LoginExternos { get; set; }
    }
}
