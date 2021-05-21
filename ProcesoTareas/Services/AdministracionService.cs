using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProcesoTareas.Services
{
    public class AdministracionService
    {
        private UserManager<IdentityUser> _gestionUsuarios;

        public IQueryable<IdentityUser> GeUsuariosFiltrados(UserManager<IdentityUser> gestionUsuarios, string usuario)
        {
            _gestionUsuarios = gestionUsuarios;

            var result = from us in _gestionUsuarios.Users
                         where us.UserName.Contains(usuario)
                         select new IdentityUser
                         {
                             Id = us.Id,
                             UserName = us.UserName,
                             Email = us.Email
                         };

            return result;

        }



    }
}
