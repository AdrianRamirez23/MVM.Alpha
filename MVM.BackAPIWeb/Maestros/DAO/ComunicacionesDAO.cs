using MVM.BackAPIWeb.Maestros.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM.BackAPIWeb.Maestros.DAO
{
    class ComunicacionesDAO
    {
        private string Conexion = ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString;

        internal void CrearComunicacion(Comunicacion com)
        {
            Users Uss = new Users();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Comunicaciones_CRUD 1,'','','"+com.CodTipoComunicacion+"','"+com.TipoComunicacion+"','"+com.UsuarioGestor+"','"+com.Remitente+"','"+com.Destinatario+"','','' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        internal List<Comunicacion> ObtenerComunicaciones()
        {
            List<Comunicacion> ListaCom = new List<Comunicacion>();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Comunicaciones_CRUD 2,'','','','','','','','','' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Comunicacion Com = new Comunicacion();
                    Com.idComunicacion = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                    Com.Consecutivo = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                    Com.CodTipoComunicacion = rdr[2] == DBNull.Value ? "" : rdr.GetString(2).Trim();
                    Com.UsuarioGestor = rdr[3] == DBNull.Value ? "" : rdr.GetString(3).Trim();
                    Com.Remitente = rdr[4] == DBNull.Value ? "" : rdr.GetString(4).Trim();
                    Com.Destinatario = rdr[5] == DBNull.Value ? "" : rdr.GetString(5);
                    Com.FechaRadc = rdr[6] == DBNull.Value ? Convert.ToDateTime("yyyy-mm-dd") : rdr.GetDateTime(6);
                    ListaCom.Add(Com);
                }
                return ListaCom;
            }
        }

        internal Comunicacion ConsultarComunicacion(int idCom)
        {
            Comunicacion Com = new Comunicacion();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Comunicaciones_CRUD 3,'"+idCom+"','','','','','','','','' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                   
                    Com.idComunicacion = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                    Com.Consecutivo = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                    Com.CodTipoComunicacion = rdr[2] == DBNull.Value ? "" : rdr.GetString(2).Trim();
                    Com.UsuarioGestor = rdr[3] == DBNull.Value ? "" : rdr.GetString(3).Trim();
                    Com.Remitente = rdr[4] == DBNull.Value ? "" : rdr.GetString(4).Trim();
                    Com.Destinatario = rdr[5] == DBNull.Value ? "" : rdr.GetString(5);
                    Com.FechaRadc = rdr[6] == DBNull.Value ? Convert.ToDateTime("yyyy-mm-dd") : rdr.GetDateTime(6);
                    
                }
                return Com;
            }
        }
        internal void EditarComunicacion(Comunicacion com)
        {
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Comunicaciones_CRUD 4,'"+com.idComunicacion+"','','','','" + com.UsuarioGestor + "','" + com.Remitente + "','" + com.Destinatario + "','','' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        internal void EliminarComunicacion(int idcom)
        {
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Comunicaciones_CRUD 5,'" + idcom + "','','','','','','','','' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        internal List<Comunicacion> RangoFechas(string FechaIn, string FechaFin)
        {
            List<Comunicacion> ListaCom = new List<Comunicacion>();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Comunicaciones_CRUD 6,'','','','','','','','"+FechaIn+"','"+FechaFin+"' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Comunicacion Com = new Comunicacion();
                    Com.idComunicacion = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                    Com.Consecutivo = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                    Com.CodTipoComunicacion = rdr[2] == DBNull.Value ? "" : rdr.GetString(2).Trim();
                    Com.UsuarioGestor = rdr[3] == DBNull.Value ? "" : rdr.GetString(3).Trim();
                    Com.Remitente = rdr[4] == DBNull.Value ? "" : rdr.GetString(4).Trim();
                    Com.Destinatario = rdr[5] == DBNull.Value ? "" : rdr.GetString(5);
                    Com.FechaRadc = rdr[6] == DBNull.Value ? Convert.ToDateTime("yyyy-mm-dd") : rdr.GetDateTime(6);
                    ListaCom.Add(Com);
                }
                return ListaCom;
            }
        }
    }
}
