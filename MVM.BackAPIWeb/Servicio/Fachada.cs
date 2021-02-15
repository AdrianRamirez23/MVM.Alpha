using MVM.BackAPIWeb.Maestros.Model;
using MVM.BackAPIWeb.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM.BackAPIWeb.Servicio
{
     public class Fachada
    {
        public List<Users> ObtenerUsuarios()
        {
            return new UsersBL().ObtenerUsuarios();
        }
        public Users ConsultarUsuario(string idUsuario)
        {
            return new UsersBL().ConsultarUsuario(idUsuario);
        }
        public void CrearUsuario(Users user)
        {
            new UsersBL().CrearUsuario(user);
        }
        public void EditarUsuario(Users user)
        {
            new UsersBL().EditarUsuario(user);
        }
        public void EliminarUsuario(string idUsuario)
        {
            new UsersBL().EliminarUsuario(idUsuario);
        }
        public Users ValidarUsuario(string idUsuario, string Contrasena)
        {
            return new UsersBL().ValidarUsuario(idUsuario, Contrasena);
        }

        public List<Comunicacion> ObtenerComunicaciones()
        {
            return new ComunicacionesBL().ObtenerComunicaciones();
        }
        public Comunicacion ConsultarComunicacion(int idCom)
        {
            return new ComunicacionesBL().ConsultarComunicacion(idCom);
        }
        public void CrearComunicacion(Comunicacion Com)
        {
            new ComunicacionesBL().CrearComunicacion(Com);
        }
        public void EditarComunicacion(Comunicacion Com)
        {
            new ComunicacionesBL().EditarComunicacion(Com);
        }
        public void EliminarComunicacion(int idCom)
        {
            new ComunicacionesBL().EliminarComunicacion(idCom);
        }
        public List<Comunicacion> RangoFechas(string FechaIn, string FechaFin)
        {
            return new ComunicacionesBL().RangoFechas(FechaIn, FechaFin);
        }
    }
}
