using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProcesoTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcesoTareas.Services;
using ProcesoTareas.Models.ViewModel;

namespace ProcesoTareas.Controllers
{
    [Authorize]
    public class AdministracionController : Controller
    {
        private readonly RoleManager<IdentityRole> _gestionRoles;
        private readonly UserManager<IdentityUser> _gestionUsuarios;
        private readonly SignInManager<IdentityUser> _gestionLogin;
        private readonly AdministracionService _administracionService;

        public AdministracionController(RoleManager<IdentityRole> gestionRoles, UserManager<IdentityUser> gestionUsuarios, SignInManager<IdentityUser> gestionLogin)
        {
            _gestionRoles = gestionRoles;
            _gestionUsuarios = gestionUsuarios;
            _gestionLogin = gestionLogin;
            _administracionService = new AdministracionService();
        }

        [HttpGet]
        [Route("Administracion/CrearRol")]

        public IActionResult CrearRol()
        {
            return View();
        }

        [HttpPost]
        [Route("Administracion/CrearRol")]

        public async Task<IActionResult> CrearRol(CrearRolViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.NombreRol
                };
                IdentityResult result = await _gestionRoles.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index","Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        [Route("Administracion/Roles")]
        public IActionResult ListaRoles()
        {
            var roles = _gestionRoles.Roles;
            return View(roles);
        }

        [HttpGet]
        [Route("Administracion/EditarRol")]
        public async Task<IActionResult> EditarRol(string id)
        {
            //Buscamos el rol por el id
            var rol = await _gestionRoles.FindByIdAsync(id);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el Id = {id} no fue encontrado";
                return View("Error");
            }

            var model = new EditarRolViewModel
            {
                Id = rol.Id,
                RolNombre = rol.Name
            };

            // Obtenemos todos los usuarios
            foreach (var usuario in _gestionUsuarios.Users)
            {
                if (await _gestionUsuarios.IsInRoleAsync(usuario, rol.Name))
                {
                    model.Usuarios.Add(usuario.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        [Route("Administracion/EditarRol")]
        //[Authorize(Policy = "EditarRolPolicy")]
        public async Task<IActionResult> EditarRol(EditarRolViewModel model)
        {
            var rol = await _gestionRoles.FindByIdAsync(model.Id);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el Id = {model.Id} no fue encontrado";
                return View("Error");
            }
            else
            {
                rol.Name = model.RolNombre;

                var resultado = await _gestionRoles.UpdateAsync(rol);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Roles", "Administracion");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
        [HttpGet]
        [Route("Administracion/EditarUsuarioRol")]
        public async Task<IActionResult> EditarUsuarioRol(string rolId)
        {
            ViewBag.roleId = rolId;

            var role = await _gestionRoles.FindByIdAsync(rolId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Rol con el Id = {rolId} no fue encontrado";
                return View("Error");
            }

            var model = new List<UsuarioRolModelo>();

            foreach (var user in _gestionUsuarios.Users)
            {
                var usuarioRolModelo = new UsuarioRolModelo
                {
                    UsuarioId = user.Id,
                    UsuarioNombre = user.UserName
                };

                if (await _gestionUsuarios.IsInRoleAsync(user, role.Name))
                {
                    usuarioRolModelo.EstaSeleccionado = true;
                }
                else
                {
                    usuarioRolModelo.EstaSeleccionado = false;
                }

                model.Add(usuarioRolModelo);
            }

            return View(model);
        }

        [HttpPost]
        [Route("Administracion/EditarUsuarioRol")]
        public async Task<IActionResult> EditarUsuarioRol(List<UsuarioRolModelo> model,
                                        string rolId)
        {
            var rol = await _gestionRoles.FindByIdAsync(rolId);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el Id = {rolId} no fue encontrado";
                return View("Error");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await _gestionUsuarios.FindByIdAsync(model[i].UsuarioId);

                IdentityResult result = null;

                if (model[i].EstaSeleccionado && !(await _gestionUsuarios.IsInRoleAsync(user, rol.Name)))
                {
                    result = await _gestionUsuarios.AddToRoleAsync(user, rol.Name);
                }
                else if (!model[i].EstaSeleccionado && await _gestionUsuarios.IsInRoleAsync(user, rol.Name))
                {
                    result = await _gestionUsuarios.RemoveFromRoleAsync(user, rol.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditarRol", new { Id = rolId });
                }
            }

            return RedirectToAction("EditarRol", new { Id = rolId });
        }

        [HttpGet]
        [Route("Administracion/Usuarios")]
        public IActionResult Usuarios()
        {

            return View(_gestionUsuarios.Users);
        }

        [HttpPost]
        [Route("Administracion/Usuarios")]
        public IActionResult Usuarios(string usuario)
        {
            if (usuario != null)
            {
                var result = _administracionService.GeUsuariosFiltrados(_gestionUsuarios, usuario);

                return View(result.ToList());
            }
            else
            {
                return View(_gestionUsuarios.Users);
            }
              
       }


        [HttpGet]
        [Route("Administracion/EditarUsuario")]
        public async Task<IActionResult> EditarUsuario(string id)
        {
            var usuario = await _gestionUsuarios.FindByIdAsync(id);

            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"Usuario con Id = {id} no fue encontrado";
                return View("Error");
            }

            // Una lista de las notificaciones
            var usuarioClaims = await _gestionUsuarios.GetClaimsAsync(usuario);
            // GetRolesAsync returns the list of user Roles
            var usuarioRoles = await _gestionUsuarios.GetRolesAsync(usuario);

            

            var model = new EditarUsuarioModelo
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.UserName,
                Password = usuario.PasswordHash,
                Notificaciones = usuarioClaims.Select(c => c.Type + " : " + c.Value).ToList(),
                Roles = usuarioRoles
             
            };

            return View(model);
        }

        [HttpPost]
        [Route("Administracion/EditarUsuario")]
        public async Task<IActionResult> EditarUsuario(EditarUsuarioModelo model)
        {
            var usuario = await _gestionUsuarios.FindByIdAsync(model.Id);
           
           
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"Usuario con Id = {model.Id} no fue encontrado";
                return View("Error");
            }
            else
            {
                usuario.Email = model.Email;
                usuario.UserName = model.NombreUsuario;               
                usuario.PasswordHash = _gestionUsuarios.PasswordHasher.HashPassword(usuario, model.Password.ToString());               
                var resultado = await _gestionUsuarios.UpdateAsync(usuario);
              ;

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Usuarios", "Administracion");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpPost]
        [Route("Administracion/BorrarUsuario")]
        public async Task<IActionResult> BorrarUsuario(string id)
        {
            var user = await _gestionUsuarios.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuario con Id = {id} no fue encontrado";
                return View("Error");
            }
            else
            {
                var resultado = await _gestionUsuarios.DeleteAsync(user);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Usuarios", "Administracion");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();

            }
        }

        [HttpGet]
        [Route("Administracion/NuevoUsuario")]
        //[AllowAnonymous]
        public IActionResult NuevoUsuario()
        {
            return View();
        }

        [HttpPost]
        [Route("Administracion/NuevoUsuario")]
        public async Task<IActionResult> NuevoUsuario(RegistroModelo model)
        {
            if (ModelState.IsValid)
            {
                // Volcamos los datos de la clase RegistroModelo a la clase IdentityUser
                var usuario = new IdentityUser
                {
                    UserName = model.User,
                    Email = model.Email
                };
                // Guardamos datos de usuario en la tabla de base de datos AspNetUsers
                var resultado = await _gestionUsuarios.CreateAsync(usuario, model.Password);

                // Si el usuario se creo correctamente y logamos correctamente, redirigimos a la 
                //página de inicio salvo que sea administrador
                if (resultado.Succeeded)
                {
                    await _gestionLogin.SignInAsync(usuario, isPersistent: false);
                    return RedirectToAction("Usuarios", "Administracion"); 
                }
                //Contrlar el error en el caso que se produzca
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

    }
}
