using MVM.WebApp.Models;
using MVM.WebApp.Models.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVM.WebApp
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private static string url = "https://localhost:44362/Usuarios/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (new Utils().sesionCerrada()) return;
            alerta.Visible = false;
            LLenarListaUsuario();
            if (SessionManager.usuario.Rol != "admin")
            {
                Response.Redirect("~/Comunicaciones");
            }
        }
        protected void LLenarListaUsuario()
        {
            try
            {
                List<Users> lisCom = new List<Users>();

                string metodo = "ListarUsuarios";
                var json = new WebClient().DownloadString(url + metodo);
                dynamic m = JsonConvert.DeserializeObject(json);

                foreach (var i in m)
                {
                    Users com = new Users();
                    com.idUsuario = i.idUsuario;
                    com.Contrasena = i.Contrasena;
                    com.NombreUsuario = i.NombreUsuario;
                    com.Rol = i.Rol;
                    com.Area = i.Area;
                    com.Estado = i.Estado;
                  
                    lisCom.Add(com);
                }
                grdUsers.DataSource = lisCom;
                grdUsers.DataBind();

            }
            catch (Exception ex)
            {
                alerta.Visible = true;
                lblAlerta.Text = ex.Message;
                throw;
            }
        }

        protected void lblEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string Result = null;
                using (GridViewRow fila = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    ////se cargan los datos para actualizar en la base de datos
                    string idUsuario = (fila.FindControl("lblcom") as Label).Text.Trim();

                    string metodo = "EliminarUsuario?idUsuario=" + idUsuario;

                    WebRequest request = WebRequest.Create(url + metodo);
                    request.Method = "Delete";
                    request.ContentType = "application/json;charset=UTF-8";

                    WebResponse respon = request.GetResponse();

                    using (var oSR = new StreamReader(respon.GetResponseStream()))
                    {
                        Result = oSR.ReadToEnd();
                    }
                    if (string.IsNullOrEmpty(Result))
                    {
                        alerta.Attributes.Add("class", "alert alert-success alert-dismissible");
                        alerta.Visible = true;
                        lblAlerta.Text = "La eliminacion del usuario fue exitosa";

                    }
                    else
                    {
                        alerta.Visible = true;
                        lblAlerta.Text = "Error al eliminar el usuario";
                    }
                    LLenarListaUsuario();

                }
            }
            catch (Exception ex)
            {
                alerta.Visible = true;
                lblAlerta.Text = ex.Message;
                throw;
            }
        }
    }
}