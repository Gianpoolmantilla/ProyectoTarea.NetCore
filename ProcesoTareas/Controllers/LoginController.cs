using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcesoTareas.Models;

namespace ProcesoTareas.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyDBContext _context;

        public LoginController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Autherize(string nombreusuario, string Clave)
        {
            var userDetails = _context.Usuarios.Where(x => x.NombreuserId == nombreusuario && x.Password == Clave);
            if (userDetails.Any())
            {
                if (userDetails.Where(s => s.NombreuserId == nombreusuario && s.Password == Clave).Any())
                {
                    return Json(new { status = true, message = "bienvenido" });
                    

                }
                else
                {
                    return Json(new { status = false, message = "clave incorrecto" });
                }
            }
            else
            {
                return Json(new { status = false, message = "usuario incorrecto" });
            }                      
        }

        [HttpPost]
        public async Task <ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");

        }


    }
}
