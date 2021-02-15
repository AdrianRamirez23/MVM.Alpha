using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM.BackAPIWeb.Maestros.Model
{
    public class Comunicacion
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
