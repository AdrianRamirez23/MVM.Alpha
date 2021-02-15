using MVM.BackAPIWeb.Maestros.DAO;
using MVM.BackAPIWeb.Maestros.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM.BackAPIWeb.Negocio
{
    class ComunicacionesBL
    {
        internal List<Comunicacion> ObtenerComunicaciones()
        {
            return new ComunicacionesDAO().ObtenerComunicaciones();
        }
        internal Comunicacion ConsultarComunicacion(int idCom)
        {
            return new ComunicacionesDAO().ConsultarComunicacion(idCom);
        }
        internal void CrearComunicacion(Comunicacion Com)
        {
             new ComunicacionesDAO().CrearComunicacion(Com);
        }
        internal void EditarComunicacion(Comunicacion Com)
        {
            new ComunicacionesDAO().EditarComunicacion(Com);
        }
        internal void EliminarComunicacion(int idCom)
        {
             new ComunicacionesDAO().EliminarComunicacion(idCom);
        }
        internal List<Comunicacion> RangoFechas(string FechaIn, string FechaFin)
        {
            return new ComunicacionesDAO().RangoFechas(FechaIn, FechaFin);
        }

    }
}
