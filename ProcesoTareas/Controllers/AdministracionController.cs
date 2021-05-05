﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProcesoTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcesoTareas.Controllers
{
    [Authorize]
    public class AdministracionController : Controller
    {
        private readonly RoleManager<IdentityRole> _gestionRoles;
        private readonly UserManager<IdentityUser> _gestionUsuarios;

        public AdministracionController(RoleManager<IdentityRole> gestionRoles, UserManager<IdentityUser> gestionUsuarios)
        {
            _gestionRoles = gestionRoles;
            _gestionUsuarios = gestionUsuarios;
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


        ////////////////////////////////


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


    }
}
