using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVM.APIWeb.Models
{
    /// <summary>
    /// Clase Usuario
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Id Usuario para iniciar sesión
        /// </summary>
        public string idUsuario { get; set; }
        /// <summary>
        /// Contraseña de inicio de sesión
        /// </summary>
        public string Contrasena { get; set; }
        /// <summary>
        /// Nombres completos del usuario
        /// </summary>
        public string NombreUsuario { get; set; }
        /// <summary>
        /// Rol del Usuario
        /// </summary>
        public string Rol { get; set; }
        /// <summary>
        /// Area al que pertenece el usuario
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// Estado del usuario
        /// </summary>
        public bool Estado { get; set; }
    }
}