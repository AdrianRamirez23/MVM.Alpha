using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVM.WebApp.Models.Utilidades
{
    public class Utils
    {
        internal bool sesionCerrada()
        {
            if (SessionManager.usuario == null)
            {
                HttpContext.Current.Response.Redirect(Configuracion.URL_DEFAULT);
                return true;
            }
            return false;
        }
    }
}