using MVM.BackAPIWeb.Maestros.DAO;
using MVM.BackAPIWeb.Maestros.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM.BackAPIWeb.Negocio
{
    class UsersBL
    {
        internal List<Users> ObtenerUsuarios()
        {
            return new UsersDAO().ObtenerUsuarios();
        }
        internal Users ConsultarUsuario(string idUsuario)
        {
            return new UsersDAO().ConsultarUsuario(idUsuario);
        }
        internal void CrearUsuario(Users user)
        {
            new UsersDAO().CrearUsuario(user);
        }
        internal void EditarUsuario(Users user)
        {
            new UsersDAO().EditarUsuario(user);
        }
        internal void EliminarUsuario(string idUsuario)
        {
            new UsersDAO().EliminaUsuario(idUsuario);
        }
        internal Users ValidarUsuario(string idUsuario, string Contrasena)
        {
            return new UsersDAO().ValidarUsuario(idUsuario, Contrasena);
        }
    }
}
