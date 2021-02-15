using MVM.APIWeb.Models;
using MVM.BackAPIWeb.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVM.APIWeb.Controllers
{
    /// <summary>
    /// Controlador para el objeto de administración de usuarios
    /// </summary>
    [RoutePrefix("Usuarios")]
    public class UsuariosController : ApiController
    {
        ///GET:api/ListaUsuarios
        /// <summary>
        /// Retorna la lista de usuarios
        /// </summary>
        /// <returns></returns>
        [Route("ListarUsuarios")]
        [HttpGet]
        public List<Users> ListarUsuarios()
        {
            try
            {
                List<MVM.BackAPIWeb.Maestros.Model.Users> UsersBack = new List<MVM.BackAPIWeb.Maestros.Model.Users>();
                List<Users> ListUser = new List<Users>();
                UsersBack = new Fachada().ObtenerUsuarios();

                foreach (MVM.BackAPIWeb.Maestros.Model.Users User in UsersBack)
                {
                    Users Uss = new Users();
                    Uss.idUsuario = User.idUsuario;
                    Uss.Contrasena = User.Contrasena;
                    Uss.NombreUsuario = User.NombreUsuario;
                    Uss.Rol = User.Rol;
                    Uss.Area = User.Area;
                    ListUser.Add(Uss);
                }
                return ListUser;
            }
            catch (Exception)
            {
                throw;
            }
        }
        ///GET:api/ConsultaUsuarios{idUsuario}
        /// <summary>
        /// Consulta un usuario por idUsuario(String)
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [Route("ConsultarUsuario")]
        [HttpGet]
        public Users ConsultarUsuario(string idUsuario)
        {
            try
            {
                MVM.BackAPIWeb.Maestros.Model.Users User = new MVM.BackAPIWeb.Maestros.Model.Users();
                Users Uss = new Users();
                User = new Fachada().ConsultarUsuario(idUsuario);

                Uss.idUsuario = User.idUsuario;
                Uss.Contrasena = User.Contrasena;
                Uss.NombreUsuario = User.NombreUsuario;
                Uss.Rol = User.Rol;
                Uss.Area = User.Area;
                Uss.Estado = User.Estado;
                return Uss;

            }
            catch (Exception)
            {
                NotFound();
                throw;
            }
        }

        ///POST:api/CrearUsuarios
        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="uss"></param>
        /// <returns></returns>
        [Route("CrearUsuario")]
        [HttpPost]
        public IHttpActionResult CrearUsuario(Users uss)
        {
            try
            {
                if (string.IsNullOrEmpty(uss.idUsuario))
                {
                    return NotFound();
                }
                else
                {
                    MVM.BackAPIWeb.Maestros.Model.Users User = new MVM.BackAPIWeb.Maestros.Model.Users();

                    User.idUsuario = uss.idUsuario;
                    User.Contrasena = uss.Contrasena;
                    User.NombreUsuario = uss.NombreUsuario;
                    User.Rol = uss.Rol;
                    User.Area = uss.Area;
                    User.Estado = uss.Estado;

                    new Fachada().CrearUsuario(User);

                    return Ok();
                }
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        ///POST:api/EditaUsuarios
        /// <summary>
        /// Edita un usuario
        /// </summary>
        /// <param name="uss"></param>
        /// <returns></returns>
        [Route("EditarUsuario")]
        [HttpPut]
        public IHttpActionResult EditarUsuario(Users uss)
        {
            try
            {
                if (string.IsNullOrEmpty(uss.idUsuario))
                {
                    return NotFound();
                }
                else
                {
                    MVM.BackAPIWeb.Maestros.Model.Users User = new MVM.BackAPIWeb.Maestros.Model.Users();

                    User.idUsuario = uss.idUsuario;
                    User.Contrasena = uss.Contrasena;
                    User.NombreUsuario = uss.NombreUsuario;
                    User.Rol = uss.Rol;
                    User.Area = uss.Area;
                    User.Estado = uss.Estado;

                    new Fachada().EditarUsuario(User);

                    return Ok();
                }
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        ///DELETE:api/EliminaUsuarios
        /// <summary>
        /// Elimina usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [Route("EliminarUsuario")]
        [HttpDelete]
        public IHttpActionResult EliminarUsuario(string idUsuario)
        {
            try
            {
                MVM.BackAPIWeb.Maestros.Model.Users User = new MVM.BackAPIWeb.Maestros.Model.Users();
                User = new Fachada().ConsultarUsuario(idUsuario);
                if (string.IsNullOrEmpty(User.idUsuario))
                {
                    return NotFound();
                }
                else
                {
                    new Fachada().EliminarUsuario(idUsuario);
                    return Ok();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //GET:api/ValidaUsuarios
        /// <summary>
        /// Valida usuario con permisos para acceder (Loggin)
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="Contrasena"></param>
        /// <returns></returns>
        [Route("ValidarUsuario")]
        [HttpGet]
        public Users ValidarUsuario(string idUsuario, string Contrasena)
        {
            try
            {

           
                MVM.BackAPIWeb.Maestros.Model.Users User = new MVM.BackAPIWeb.Maestros.Model.Users();
                User = new Fachada().ValidarUsuario(idUsuario, Contrasena);
                Users Uss = new Users();
                

                Uss.idUsuario = User.idUsuario;
                Uss.Contrasena = User.Contrasena;
                Uss.NombreUsuario = User.NombreUsuario;
                Uss.Rol = User.Rol;
                Uss.Area = User.Area;
                Uss.Estado = User.Estado;

                if (string.IsNullOrEmpty(Uss.idUsuario))
                {
                     NotFound();
                }

                return Uss;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
