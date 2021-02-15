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
    class UsersDAO
    {
        private string Conexion = ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString;
        internal void CrearUsuario(Users user)
        {
            Users Uss = new Users();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Usuario_CRUD 1,'" + user.idUsuario + "','"+user.Contrasena+"','"+user.NombreUsuario+"','"+user.Rol+"','"+user.Area+"','"+user.Estado+"' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();    
            }
        }

        internal List<Users> ObtenerUsuarios()
        {
            List<Users> ListaUss = new List<Users>();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Usuario_CRUD 2,'','','','','','' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Users Uss = new Users();
                    Uss.idUsuario = rdr[0] == DBNull.Value ? "" : rdr.GetString(0);
                    Uss.Contrasena = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                    Uss.NombreUsuario = rdr[2] == DBNull.Value ? "" : rdr.GetString(2).Trim();
                    Uss.Rol = rdr[3] == DBNull.Value ? "" : rdr.GetString(3).Trim();
                    Uss.Area = rdr[4] == DBNull.Value ? "" : rdr.GetString(4).Trim();
                    Uss.Estado = rdr[5] == DBNull.Value ? false : rdr.GetBoolean(5);
                    ListaUss.Add(Uss);
                }
                return ListaUss;
            }
        }
        internal Users ConsultarUsuario(string idUsuario)
        {
            Users Uss = new Users();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Usuario_CRUD 3,'"+idUsuario+"','','','','','' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Uss.idUsuario = rdr[0] == DBNull.Value ? "" : rdr.GetString(0);
                    Uss.Contrasena = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                    Uss.NombreUsuario = rdr[2] == DBNull.Value ? "" : rdr.GetString(2).Trim();
                    Uss.Rol = rdr[3] == DBNull.Value ? "" : rdr.GetString(3).Trim();
                    Uss.Area = rdr[4] == DBNull.Value ? "" : rdr.GetString(4).Trim();
                    Uss.Estado = rdr[5] == DBNull.Value ? false : rdr.GetBoolean(5);
                }
                return Uss;
            }
        }
        internal void EditarUsuario(Users user)
        {

            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Usuario_CRUD 4,'" + user.idUsuario + "','" + user.Contrasena + "','" + user.NombreUsuario + "','" + user.Rol + "','" + user.Area + "','" + user.Estado + "' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        internal void EliminaUsuario(string idUsuario)
        {

            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Usuario_CRUD 5,'" + idUsuario + "','','','','','' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal Users ValidarUsuario(string idUsuario, string Contraseña)
        {
            Users Uss = new Users();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                string sentencia = "exec Usuario_CRUD 6,'" + idUsuario + "','"+Contraseña+"','','','','' ";
                SqlCommand cmd = new SqlCommand(sentencia, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Uss.idUsuario = rdr[0] == DBNull.Value ? "" : rdr.GetString(0);
                    Uss.Contrasena = rdr[1] == DBNull.Value ? "" : rdr.GetString(1).Trim();
                    Uss.NombreUsuario = rdr[2] == DBNull.Value ? "" : rdr.GetString(2).Trim();
                    Uss.Rol = rdr[3] == DBNull.Value ? "" : rdr.GetString(3).Trim();
                    Uss.Area = rdr[4] == DBNull.Value ? "" : rdr.GetString(4).Trim();
                    Uss.Estado = rdr[5] == DBNull.Value ? false : rdr.GetBoolean(5);
                }
                return Uss;
            }
        }

    }
}
