using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVM.WebApp.Models
{
    public class Comunications
    {
        public int idComunicacion { get; set; }
        public string Consecutivo { get; set; }
        public string CodTipoComunicacion { get; set; }
        public string TipoComunicacion { get; set; }
        public string UsuarioGestor { get; set; }
        public string Remitente { get; set; }
        public string Destinatario { get; set; }
        public DateTime FechaRadc { get; set; }
    }
}