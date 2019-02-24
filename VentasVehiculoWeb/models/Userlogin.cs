using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VentaVehiculoModelDB.Models;

namespace VentasVehiculoWeb.models
{
    public class UserLogin
    {
        [EmailAddress]
        [Required(ErrorMessage = "El Email es Requerido")]
        [Display(Name = "Crreo Eletronico")]
        public string nombreUser { get; set; }

        [StringLength(100, ErrorMessage = "El Nuemro de {0} debe de ser al menos {2}", MinimumLength = 3)]
        [Required(ErrorMessage = "El Password es Requerido")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public string UserName { get; set; }
        public int UserId { get; set; }

        private VentasVehiculoDBEntities user = new VentasVehiculoDBEntities();


        public bool Login()
        {
            var query = from u in user.Usuarios
                        where u.NombreUsuario == nombreUser && u.PasswordUsuario == Password
                        select u;
            if (query.Count() > 0)
            {
                var datos = query.ToList();
                foreach (var Data in datos)
                {
                    UserName = Data.NombreUsuario;
                    UserId = Data.ID;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}