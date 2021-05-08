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

                    //var token = await gestionUsuarios.GenerateEmailConfirmationTokenAsync(usuario);

                    //var linkConfirmacion = "https://localhost:44338/Cuentas/ConfirmarEmail?usuarioId=" + usuario.Id + "&token=" + WebUtility.UrlEncode(token);

                    //log.Log(LogLevel.Error, linkConfirmacion);

                    //if (gestionLogin.IsSignedIn(User) && User.IsInRole("Administrador"))
                    //{
                    //    return RedirectToAction("ListaUsuarios", "Administracion");
                    //}

                    //ViewBag.ErrorTitle = "Registro correcto";
                    //ViewBag.ErrorMessage = "Antes de iniciar sesión confirma el registro clicando en el link del email recibido";
                    //return View("Error");
                }

                //Contrlar el error en el caso que se produzca
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        //[AllowAnonymous]
        //[Route("Cuentas/ConfirmarEmail")]
        //public async Task<IActionResult> ConfirmarEmail(string usuarioId, string token)
        //{
        //    if (usuarioId == null || token == null)
        //    {
        //        return RedirectToAction("index", "home");
        //    }

        //    var usuario = await gestionUsuarios.FindByIdAsync(usuarioId);
        //    if (usuario == null)
        //    {
        //        ViewBag.ErrorMessage = $"El usuario con id {usuarioId} es invalido";
        //        return View("ErrorGenerico");
        //    }
        //    var result = await gestionUsuarios.ConfirmEmailAsync(usuario, token);
        //    if (result.Succeeded)
        //    {
        //        return View();
        //    }

        //    ViewBag.ErrorTitle = "El email no pudo ser confirmado";
        //    return View("ErrorGenerico");
        //}




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
            //LoginViewModelo modelo = new LoginViewModelo
            //{
            //    UrlRetorno = urlRetorno,
            //    LoginExternos = (await gestionLogin.GetExternalAuthenticationSchemesAsync()).ToList()
            //};

            //return View(modelo);
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
                    modelo.Email, modelo.Password, modelo.Recuerdame, false);

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


        //[AllowAnonymous]
        //[HttpPost]
        //[Route("Cuentas/LoginExterno")]
        //public IActionResult LoginExterno(string proveedor, string UrlRetorno)
        //{
        //    var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
        //                        new { ReturnUrl = UrlRetorno });
        //    var properties = gestionLogin
        //        .ConfigureExternalAuthenticationProperties(proveedor, redirectUrl);
        //    return new ChallengeResult(proveedor, properties);
        //}

        //[AllowAnonymous]
        //[Route("Cuentas/LoginExterno")]
        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        //{
        //    returnUrl = returnUrl ?? Url.Content("~/");

        //    LoginViewModelo loginViewModel = new LoginViewModelo
        //    {
        //        UrlRetorno = returnUrl,
        //        LoginExternos = (await gestionLogin.GetExternalAuthenticationSchemesAsync()).ToList()
        //    };

        //    if (remoteError != null)
        //    {
        //        ModelState
        //            .AddModelError(string.Empty, $"Error en el proveedor externo: {remoteError}");

        //        return View("Login", loginViewModel);
        //    }

        //    // Obtenemos la información de incicio de sesión del proveedor externo
        //    var info = await gestionLogin.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {
        //        ModelState
        //            .AddModelError(string.Empty, "Error cargando la informacion");

        //        return View("Login", loginViewModel);
        //    }


        //    //Obtenga el claim por correo electrónico del proveedor de inicio de sesión externo(Google, Facebook, etc.)
        //    var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        //    UsuarioAplicacion usuario = null;

        //    if (email != null)
        //    {
        //        //Buscamos el usuario
        //        usuario = await gestionUsuarios.FindByEmailAsync(email);

        //        // Si el email no esta confirmado mostramos el error
        //        if (usuario != null && !usuario.EmailConfirmed)
        //        {
        //            ModelState.AddModelError(string.Empty, "Email sin confirmar");
        //            return View("Login", loginViewModel);
        //        }
        //    }


        //    // Si el usuario ya tiene un inicio de sesión (es decir, si hay un registro en AspNetUserLogins
        //    // tabla) inicia sesión con el usuario de este proveedor externo
        //    var loginResultado = await gestionLogin.ExternalLoginSignInAsync(info.LoginProvider,
        //        info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

        //    if (loginResultado.Succeeded)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    // Si no hay registro en la tabla AspNetUserLogins, el usuario puede no tener
        //    // una cuenta local
        //    else
        //    {

        //        if (email != null)
        //        {
        //            if (usuario == null)
        //            {
        //                usuario = new UsuarioAplicacion
        //                {
        //                    UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
        //                    Email = info.Principal.FindFirstValue(ClaimTypes.Email)
        //                };

        //                await gestionUsuarios.CreateAsync(usuario);

        //                var token = await gestionUsuarios.GenerateEmailConfirmationTokenAsync(usuario);

        //                var linkConfirmacion = "https://localhost:44338/Cuentas/ConfirmarEmail?usuarioId=" + usuario.Id + "&token=" + WebUtility.UrlEncode(token);

        //                log.Log(LogLevel.Error, linkConfirmacion);

        //                ViewBag.ErrorTitle = "Registro correcto";
        //                ViewBag.ErrorMessage = "Antes de iniciar sesión confirma el registro clicando en el link del email recibido";
        //                return View("Error");
        //            }

        //            // Agrego un inicio de sesión (es decir, inserte una fila para el usuario en la tabla AspNetUserLogins)
        //            await gestionUsuarios.AddLoginAsync(usuario, info);
        //            await gestionLogin.SignInAsync(usuario, isPersistent: false);

        //            return LocalRedirect(returnUrl);
        //        }

        //        // Si no podemos encontrar el correo electrónico del usuario, no podemos continuar
        //        ViewBag.ErrorTitle = $"Email claim no fue recibido de: {info.LoginProvider}";
        //        ViewBag.ErrorMessage = "Contacta con japsoftware@gmail.com";

        //        return View("Error");
        //    }
        //}






        //[HttpGet]
        //[AllowAnonymous]
        //[Route("Cuentas/AccesoDenegado")]
        //public IActionResult AccesoDenegado()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[AllowAnonymous]
        //[Route("Cuentas/OlvidoPassword")]
        //public IActionResult OlvidoPassword()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[AllowAnonymous]
        //[Route("Cuentas/OlvidoPassword")]
        //public async Task<IActionResult> OlvidoPassword(OlvidoPasswordViewModel modelo)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        // Buscamos el usaurio por el email
        //        var usuario = await gestionUsuarios.FindByEmailAsync(modelo.Email);
        //        // Si el usuario existe y el email esta confirmado
        //        if (usuario != null && await gestionUsuarios.IsEmailConfirmedAsync(usuario))
        //        {
        //            // Generamos el token de restablecimiento de contraseña
        //            var token = await gestionUsuarios.GeneratePasswordResetTokenAsync(usuario);

        //            var linkReseteaPass = "https://localhost:44338/Cuentas/ReseteaPassword?Email=" + modelo.Email + "&token=" + WebUtility.UrlEncode(token);

        //            // Log the password reset link
        //            log.Log(LogLevel.Warning, linkReseteaPass);

        //            // Enviar al usuario a la vista de confirmación de contraseña olvidada
        //            return View("OlvidoPasswordConfirmacion");
        //        }

        //        return View("OlvidoPasswordConfirmacion");
        //    }

        //    return View(modelo);
        //}


        //[HttpGet]
        //[AllowAnonymous]
        //[Route("Cuentas/ReseteaPassword")]
        //public IActionResult ReseteaPassword(string token, string email)
        //{

        //    if (token == null || email == null)
        //    {
        //        ModelState.AddModelError("", "Token para resetear password incorrecto");
        //    }
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[Route("Cuentas/ReseteaPassword")]
        //public async Task<IActionResult> ReseteaPassword(ResetPassViewModel modelo)
        //{
        //    if (ModelState.IsValid)
        //    {


        //        var usuario = await gestionUsuarios.FindByEmailAsync(modelo.Email);

        //        if (usuario != null)
        //        {

        //            var resultado = await gestionUsuarios.ResetPasswordAsync(usuario, modelo.Token, modelo.Password);
        //            if (resultado.Succeeded)
        //            {
        //                return View("ResetearPasswordConfirmacion");
        //            }

        //            foreach (var error in resultado.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //            return View(modelo);
        //        }


        //        return View("ResetearPasswordConfirmacion");
        //    }

        //    return View(modelo);
        //}

     


    }
}
