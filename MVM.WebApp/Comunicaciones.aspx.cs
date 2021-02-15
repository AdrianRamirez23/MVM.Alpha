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
    public partial class Comunicaciones : System.Web.UI.Page
    {
        private static string url = "https://localhost:44362/Comunicaciones/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (new Utils().sesionCerrada()) return;
            alerta.Visible = false;
            txtRemitente.Visible = false;
            ddlRem.Visible = false;
            llenarListaComunicacion();
            if (SessionManager.usuario.Rol == "Gestor")
            {
                lbtnCrear.Visible = true;
                grdComunicaciones.Enabled = true;
            }
            else
            {
                lbtnCrear.Visible = false;
                grdComunicaciones.Enabled = false;
            }
        }
        protected void llenarListaComunicacion()
        {
            try
            {
                List<Comunications> lisCom = new List<Comunications>();

                string metodo = "ListarComunicacion";
                var json = new WebClient().DownloadString(url + metodo);
                dynamic m = JsonConvert.DeserializeObject(json);

                foreach(var i in m)
                {
                    Comunications com = new Comunications();
                    com.idComunicacion = i.idComunicacion;
                    com.Consecutivo = i.Consecutivo;
                    com.CodTipoComunicacion = i.CodTipoComunicacion;
                    com.UsuarioGestor = i.UsuarioGestor;
                    com.Remitente = i.Remitente;
                    com.Destinatario = i.Destinatario;
                    com.FechaRadc = i.FechaRadc;
                    lisCom.Add(com);
                }
                grdComunicaciones.DataSource = lisCom;
                grdComunicaciones.DataBind();

            }
            catch (Exception ex)
            {
                alerta.Visible = true;
                lblAlerta.Text = ex.Message;
                throw;
            }
        }

        protected void ddlTipoCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoCom.SelectedValue == "CE")
            {
                txtRemitente.Visible = true;
                ddlRem.Visible = false;
            }
            else
            {
                ddlRem.Visible = true;
                txtRemitente.Visible = false;
            }
        }

        protected void lblGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Result = null;
                if (ddlTipoCom.SelectedValue == "0")
                {
                    alerta.Visible = true;
                    lblAlerta.Text = "Por favor seleccione un tipo de correspondencia";
                }else if(ddlTipoCom.SelectedValue == "CI" && ddlRem.SelectedValue == "0")
                {
                    alerta.Visible = true;
                    lblAlerta.Text = "Por favor seleccione un remitente interno válido";
                }else if (ddlTipoCom.SelectedValue == "CE" && string.IsNullOrEmpty(txtRemitente.Text))
                {
                    alerta.Visible = true;
                    lblAlerta.Text = "Por favor ingrese remitente externo válido";
                }
                else if (ddlDestin.SelectedValue=="0")
                {
                    alerta.Visible = true;
                    lblAlerta.Text = "Por favor seleccione un destinatario válido";
                }
                else
                {
                    Comunications com = new Comunications();
                    com.CodTipoComunicacion = ddlTipoCom.SelectedValue;
                    com.TipoComunicacion = ddlTipoCom.SelectedItem.Text.Trim();
                    com.UsuarioGestor = SessionManager.usuario.idUsuario;
                    if (ddlTipoCom.SelectedValue == "CI")
                    {
                        com.Remitente = ddlRem.SelectedValue;
                    }
                    else
                    {
                        com.Remitente = txtRemitente.Text.Trim();
                    }
                    com.Destinatario = ddlDestin.SelectedValue;

                    string metodo = "CrearComunicacion";

                    var objson = JsonConvert.SerializeObject(com);

                    WebRequest request = WebRequest.Create(url + metodo);
                    request.Method = "post";
                    request.ContentType = "application/json;charset=UTF-8";

                    using (var oSW= new StreamWriter(request.GetRequestStream()))
                    {
                        oSW.Write(objson);
                        oSW.Flush();
                        oSW.Close();
                    }
                    WebResponse respon = request.GetResponse();

                    using (var oSR= new StreamReader(respon.GetResponseStream()))
                    {
                        Result = oSR.ReadToEnd();
                    }
                    if (string.IsNullOrEmpty(Result))
                    {
                        alerta.Visible = true;
                        lblAlerta.Text = "Error al radicar la nueva comunicación";
                    }
                    else
                    {
                        alerta.Attributes.Add("class", "alert alert-success alert-dismissible");
                        alerta.Visible = true;
                        lblAlerta.Text = "La radicación de la comunicación fue exitosa";
                    }
                    llenarListaComunicacion();
                }
            }
            catch (Exception ex)
            {
                alerta.Visible = true;
                lblAlerta.Text = ex.Message;
                throw;
            }
        }

        protected void lblEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string Result = null;
                using (GridViewRow fila = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    ////se cargan los datos para actualizar en la base de datos
                    int idCom = Convert.ToInt32((fila.FindControl("lblcom") as Label).Text.Trim());  
                    string Remite = (fila.FindControl("txtRem") as TextBox).Text.Trim();
                    string Destinatario = (fila.FindControl("txtDes") as TextBox).Text.Trim();

                    Comunications com = new Comunications();

                    com.idComunicacion = idCom;
                    com.UsuarioGestor = SessionManager.usuario.idUsuario;
                    com.Remitente = Remite;
                    com.Destinatario = Destinatario;

                    string metodo = "EditarComunicacion";

                    var objson = JsonConvert.SerializeObject(com);

                    WebRequest request = WebRequest.Create(url + metodo);
                    request.Method = "put";
                    request.ContentType = "application/json;charset=UTF-8";

                    using (var oSW = new StreamWriter(request.GetRequestStream()))
                    {
                        oSW.Write(objson);
                        oSW.Flush();
                        oSW.Close();
                    }
                    WebResponse respon = request.GetResponse();

                    using (var oSR = new StreamReader(respon.GetResponseStream()))
                    {
                        Result = oSR.ReadToEnd();
                    }
                    if (string.IsNullOrEmpty(Result))
                    {
                        alerta.Attributes.Add("class", "alert alert-success alert-dismissible");
                        alerta.Visible = true;
                        lblAlerta.Text = "La edición de la comunicación fue exitosa";
                    }
                    else
                    {
                        alerta.Visible = true;
                        lblAlerta.Text = "Error al editar la comunicación";
                       
                    }
                    llenarListaComunicacion();
                }
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
                    int idCom = Convert.ToInt32((fila.FindControl("lblcom") as Label).Text.Trim());

                    string metodo = "EliminarComunicacion?idCom="+idCom;

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
                        lblAlerta.Text = "La eliminar de la comunicación fue exitosa";
                       
                    }
                    else
                    {
                        alerta.Visible = true;
                        lblAlerta.Text = "Error al eliminar la comunicación";
                    }
                    llenarListaComunicacion();

                }
            }
            catch (Exception ex)
            {
                alerta.Visible = true;
                lblAlerta.Text = ex.Message;
                throw;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                grdComunicaciones.DataSource = null;
                if(string.IsNullOrEmpty(txtFechIni.Text)|| string.IsNullOrEmpty(txtFechFin.Text))
                {
                    alerta.Visible = true;
                    lblAlerta.Text ="Por favor ingrese una fecha válida";
                }else if(Convert.ToDateTime(txtFechIni.Text)> Convert.ToDateTime(txtFechFin.Text))
                {
                    alerta.Visible = true;
                    lblAlerta.Text = "La fecha inicial no puede ser mayor a la final";
                }
                else
                {
                    string fechaini = txtFechIni.Text;
                    string fechafin = txtFechFin.Text;

                    string metodo = "RangoFechas?FechaIn=" + fechaini+"&FechaFin="+fechafin;

                    List<Comunications> lisCom = new List<Comunications>();
                    var json = new WebClient().DownloadString(url + metodo);
                    dynamic m = JsonConvert.DeserializeObject(json);

                    foreach (var i in m)
                    {
                        Comunications com = new Comunications();
                        com.idComunicacion = i.idComunicacion;
                        com.Consecutivo = i.Consecutivo;
                        com.CodTipoComunicacion = i.CodTipoComunicacion;
                        com.UsuarioGestor = i.UsuarioGestor;
                        com.Remitente = i.Remitente;
                        com.Destinatario = i.Destinatario;
                        com.FechaRadc = i.FechaRadc;
                        lisCom.Add(com);
                    }
                    grdComunicaciones.DataSource = lisCom;
                    grdComunicaciones.DataBind();

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