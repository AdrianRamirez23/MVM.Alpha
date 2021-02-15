using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM.BackAPIWeb.Maestros.Model
{
    public class Users
    {
        public string idUsuario { get; set; }
        public string Contrasena { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        public string Area { get; set; }
        public bool Estado { get; set; }
    }
}
