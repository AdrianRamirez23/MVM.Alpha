using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVM.APIWeb.Models
{
    /// <summary>
    /// Obejto modelo con parámetros de radicacion de documentos
    /// </summary>
    public class Comunicacion
    {
        /// <summary>
        /// Identificador de comunicaciones radiacadas
        /// </summary>
        public int idComunicacion { get; set; }
        /// <summary>
        /// Consecutivo segun tipo de comunuicación (Interna o externa)
        /// </summary>
        public string Consecutivo { get; set; }
        /// <summary>
        /// Codigo de tipo de comunicación (CI, CE)
        /// </summary>
        public string CodTipoComunicacion { get; set; }
        /// <summary>
        /// Descripción de de tipo de comunicación 
        /// </summary>
        public string TipoComunicacion { get; set; }
        /// <summary>
        /// Usuario que radica la comunicación
        /// </summary>
        public string UsuarioGestor { get; set; }
        /// <summary>
        /// Información del remitente
        /// </summary>
        public string Remitente { get; set; }
        /// <summary>
        /// Información del destinatario
        /// </summary>
        public string Destinatario { get; set; }
        /// <summary>
        /// Fecha de radicación del comunicado
        /// </summary>
        public DateTime FechaRadc { get; set; }
    }
}