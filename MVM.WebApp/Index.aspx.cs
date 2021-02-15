using MVM.WebApp.Models;
using MVM.WebApp.Models.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVM.WebApp
{
    public partial class Index : System.Web.UI.Page
    {
        private static string url = "https://localhost:44362/Usuarios/";
        protected void Page_Load(object sender, EventArgs e)
        {
            alerta.Visible = false;
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUser.Text.Trim()) || string.IsNullOrEmpty(txtPass.Text.Trim()))
                {
                    alerta.Visible = true;
                    lblalerta.Text = "Todos los campos son obligatorios";
                    txtPass.Attributes.Add("style", "focus:red;");
                    txtUser.Attributes.Add("style", "focus:red;");

                }
                else
                {
                    string metodo = "ValidarUsuario?idUsuario=" + txtUser.Text.Trim() + "&Contrasena=" + txtPass.Text.Trim();
                    var json = new WebClient().DownloadString(url + metodo);
                    dynamic m = JsonConvert.DeserializeObject(json);
                    Users usser = new Users();
                    foreach (var i in m)
                    {
                        
                        usser.idUsuario = m.idUsuario;
                        usser.Contrasena = m.Contrasena;
                        usser.NombreUsuario = m.NombreUsuario;
                        usser.Rol = m.Rol;
                        usser.Area = m.Area;
                        usser.Estado = m.Estado;
                    }

                    if (string.IsNullOrEmpty(usser.idUsuario))
                    {
                        alerta.Visible = true;
                        lblalerta.Text = "El usuario no tiene permisos para ingresar en la aplicacion";
                    }
                    else
                    {
                        SessionManager.usuario = usser;
                        Response.Redirect("~/Comunicaciones");
                    }

                }
            }
            catch (Exception ex)
            {
                alerta.Visible = true;
                lblalerta.Text = ex.Message;
                throw;
            }
        }
    }
}