using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVM.WebApp.Models.Utilidades
{
    public class SessionManager
    {
        public static Users usuario
        {
            get { return (Users)(HttpContext.Current.Session["Usuario"] ?? null); }
            set { HttpContext.Current.Session["Usuario"] = value; }
        }

        public static string url
        {
            get { return (HttpContext.Current.Session["url"] ?? "").ToString(); }
            set { HttpContext.Current.Session["url"] = value; }
        }

        public static string ValueCanal
        {
            get { return (HttpContext.Current.Session["ValueCanal"] ?? "").ToString(); }
            set { HttpContext.Current.Session["ValueCanal"] = value; }
        }
    }
}