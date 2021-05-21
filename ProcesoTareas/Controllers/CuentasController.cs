using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProcesoTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Security.Claims;
using System.Web;
using ProcesoTareas.Models.ViewModel;

namespace ProcesoTareas.Controllers
{
    //[Authorize]
    public class CuentasController : Controller
    {
        //La clase UserManager nos permite administrar y gestionar usaurio
        private readonly UserManager<IdentityUser> gestionUsuarios;
        //La clase SignInManager contiene los métodos necesarios para que el usuario inicie sesión
        private readonly SignInManager<IdentityUser> gestionLogin;

        //private readonly ILogger<CuentasController> log;


        public CuentasController(UserManager<IdentityUser> gestionUsuarios, SignInManager<IdentityUser> gestionLogin/*,ILogger<CuentasController> log*/)
        {
            this.gestionUsuarios = gestionUsuarios;
            this.gestionLogin = gestionLogin;
            //this.log = log;
        }

        [HttpGet]
        [Route("Cuentas/Registro")]
        //[AllowAnonymous]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("Cuentas/Registro")]
        [AllowAnonymous]
        public async Task<IActionResult> Registro(RegistroModelo model)
        {
            if (ModelState.IsValid)
            {
                // Volcamos los datos de la clase RegistroModelo a la clase IdentityUser
                var usuario = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email//,
                    //ayudaPass = model.ayudaPass

                };

                // Guardamos datos de usuario en la tabla de base de datos AspNetUsers
                var resultado = await gestionUsuarios.CreateAsync(usuario, model.Password);

                // Si el usuario se creo correctamente y logamos correctamente, redirigimos a la 
                //página de inicio salvo que sea administrador
                if (resultado.Succeeded)
                {

                    await gestionLogin.SignInAsync(usuario, isPersistent: false);
                   // return RedirectToAction("Registro", "Cuentas");
                    return RedirectToAction("index", "home");                 
                }

                //Contrlar el error en el caso que se produzca
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }  

        [HttpPost]
        [Route("Cuentas/CerrarSesion")]
        public async Task<IActionResult> CerrarSesion()
        {
            await gestionLogin.SignOutAsync();
            return RedirectToAction("Login", "Cuentas");
        }

        [HttpGet]
        [Route("Account/Login")]
        //[AllowAnonymous]
        public IActionResult Login()
        {      
            return View();
        }

        [HttpPost]
        [Route("Account/Login")]
        //[AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModelo modelo/*, string returnUrl*/)
        {         

            if (ModelState.IsValid)
            {

                var result = await gestionLogin.PasswordSignInAsync(
                    modelo.Usuario, modelo.Password, modelo.Recuerdame, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");   
                }

                ModelState.AddModelError(string.Empty, "Inicio de sesión no válido");
            }
            return View(modelo);
        }


        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        [Route("Cuentas/ComprobarEmail")]
        public async Task<IActionResult> ComprobarEmail(string email)
        {
            var user = await gestionUsuarios.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"El email {email} No está disponible.");
            }
        }
           
    }
}
