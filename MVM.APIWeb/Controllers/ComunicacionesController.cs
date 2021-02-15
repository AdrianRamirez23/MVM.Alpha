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
    /// Controlador de comunicaciones
    /// </summary>
    [RoutePrefix("Comunicaciones")]
    public class ComunicacionesController : ApiController
    {
        ///GET:api/ListaComunicaciones
        /// <summary>
        /// Lista las comunicaciones guardadas
        /// </summary>
        /// <returns></returns>
        [Route("ListarComunicacion")]
        [HttpGet]
        public List<Comunicacion> ListarComunicacion()
        {
            try
            {
                List<MVM.BackAPIWeb.Maestros.Model.Comunicacion> ComBack = new List<MVM.BackAPIWeb.Maestros.Model.Comunicacion>();
                List<Comunicacion> ListCom = new List<Comunicacion>();
                ComBack = new Fachada().ObtenerComunicaciones();

                foreach (MVM.BackAPIWeb.Maestros.Model.Comunicacion Com in ComBack)
                {
                    Comunicacion Comu = new Comunicacion();
                    Comu.idComunicacion = Com.idComunicacion;
                    Comu.Consecutivo = Com.Consecutivo;
                    Comu.CodTipoComunicacion = Com.CodTipoComunicacion;
                    Comu.UsuarioGestor= Com.UsuarioGestor;
                    Comu.Remitente = Com.Remitente;
                    Comu.Destinatario = Com.Destinatario;
                    Comu.FechaRadc = Com.FechaRadc;
                    ListCom.Add(Comu);
                }
                return ListCom;
            }
            catch (Exception)
            {
                throw;
            }
        }
        ///GET:api/ConsultaComunicaciones{idComunicacion}
        /// <summary>
        /// Consulta una comunicación por id
        /// </summary>
        /// <param name="idComunicacion"></param>
        /// <returns></returns>
        [Route("ConsultarComunicacion")]
        [HttpGet]
        public Comunicacion ConsultarComunicacion(int idComunicacion)
        {
            try
            {
                MVM.BackAPIWeb.Maestros.Model.Comunicacion Com = new MVM.BackAPIWeb.Maestros.Model.Comunicacion();
                Comunicacion Comu = new Comunicacion();
                Com = new Fachada().ConsultarComunicacion(idComunicacion);

                Comu.idComunicacion = Com.idComunicacion;
                Comu.Consecutivo = Com.Consecutivo;
                Comu.CodTipoComunicacion = Com.CodTipoComunicacion;
                Comu.TipoComunicacion = Com.TipoComunicacion;
                Comu.UsuarioGestor = Com.UsuarioGestor;
                Comu.Remitente = Com.Remitente;
                Comu.Destinatario = Com.Destinatario;
                Comu.FechaRadc = Com.FechaRadc;
                return Comu;

            }
            catch (Exception)
            {
                NotFound();
                throw;
            }
        }

        ///POST:api/CreaComunicaciones
        /// <summary>
        /// Crea una nueva comunicación
        /// </summary>
        /// <param name="Com"></param>
        /// <returns></returns>
        [Route("CrearComunicacion")]
        [HttpPost]
        public IHttpActionResult CrearComunicacion(Comunicacion Com)
        {
            try
            {
                if (string.IsNullOrEmpty(Com.CodTipoComunicacion))
                {
                    return NotFound();
                }
                else
                {
                    MVM.BackAPIWeb.Maestros.Model.Comunicacion Comu = new MVM.BackAPIWeb.Maestros.Model.Comunicacion();

                    Comu.idComunicacion = Com.idComunicacion;
                    Comu.Consecutivo = Com.Consecutivo;
                    Comu.CodTipoComunicacion = Com.CodTipoComunicacion;
                    Comu.TipoComunicacion = Com.TipoComunicacion;
                    Comu.UsuarioGestor = Com.UsuarioGestor;
                    Comu.Remitente = Com.Remitente;
                    Comu.Destinatario = Com.Destinatario;
                    Comu.FechaRadc = Com.FechaRadc;

                    new Fachada().CrearComunicacion(Comu);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        ///POST:api/EditarComunicaciones
        /// <summary>
        /// Edita una comunicación
        /// </summary>
        /// <param name="Com"></param>
        /// <returns></returns>
        [Route("EditarComunicacion")]
        [HttpPut]
        public IHttpActionResult EditarComunicacion(Comunicacion Com)
        {
            try
            {
                if (string.IsNullOrEmpty(Com.UsuarioGestor))
                {
                    return NotFound();
                }
                else
                {
                    MVM.BackAPIWeb.Maestros.Model.Comunicacion Comu = new MVM.BackAPIWeb.Maestros.Model.Comunicacion();

                    Comu.idComunicacion = Com.idComunicacion;
                    Comu.Consecutivo = Com.Consecutivo;
                    Comu.CodTipoComunicacion = Com.CodTipoComunicacion;
                    Comu.TipoComunicacion = Com.TipoComunicacion;
                    Comu.UsuarioGestor = Com.UsuarioGestor;
                    Comu.Remitente = Com.Remitente;
                    Comu.Destinatario = Com.Destinatario;
                    Comu.FechaRadc = Com.FechaRadc;

                    new Fachada().EditarComunicacion(Comu);

                    return Ok();
                }
            }
            catch (Exception )
            {

                return NotFound();
            }
        }
        ///PUT:api/EliminarComunicaciones
        /// <summary>
        /// Elimina una comunicación
        /// </summary>
        /// <param name="idCom"></param>
        /// <returns></returns>
        [Route("EliminarComunicacion")]
        [HttpDelete]
        public IHttpActionResult EliminarComunicacion(int idCom)
        {
            try
            {
                MVM.BackAPIWeb.Maestros.Model.Comunicacion Com = new MVM.BackAPIWeb.Maestros.Model.Comunicacion();
                Com = new Fachada().ConsultarComunicacion(idCom);
                if (string.IsNullOrEmpty(Com.Consecutivo))
                {
                    return NotFound();
                }
                else
                {
                    new Fachada().EliminarComunicacion(idCom);
                    return Ok();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///GET:api/ListaComunicacionesRangoFecha
        /// <summary>
        /// Lista comunicaciones por rango de fecha
        /// </summary>
        /// <param name="FechaIn"></param>
        /// <param name="FechaFin"></param>
        /// <returns></returns>
        [Route("RangoFechas")]
        [HttpGet]
        public List<Comunicacion> RangoFechas(string FechaIn, string FechaFin)
        {
            try
            {
                List<MVM.BackAPIWeb.Maestros.Model.Comunicacion> ComBack = new List<MVM.BackAPIWeb.Maestros.Model.Comunicacion>();
                List<Comunicacion> ListCom = new List<Comunicacion>();
                ComBack = new Fachada().RangoFechas(FechaIn,FechaFin);

                foreach (MVM.BackAPIWeb.Maestros.Model.Comunicacion Com in ComBack)
                {
                    Comunicacion Comu = new Comunicacion();
                    Comu.idComunicacion = Com.idComunicacion;
                    Comu.Consecutivo = Com.Consecutivo;
                    Comu.CodTipoComunicacion = Com.CodTipoComunicacion;
                    Comu.UsuarioGestor = Com.UsuarioGestor;
                    Comu.Remitente = Com.Remitente;
                    Comu.Destinatario = Com.Destinatario;
                    Comu.FechaRadc = Com.FechaRadc;
                    ListCom.Add(Comu);
                }
                return ListCom;

            }
            catch (Exception)
            {
                 throw;
            }
        }
    }
}
