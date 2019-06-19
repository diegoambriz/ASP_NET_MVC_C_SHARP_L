using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MiPrimerApp.Models;
using System.Data.SqlClient;
using System.Configuration;

using System.Web.Mvc;

namespace MiPrimerApp.DAL
{
    public class Mascota: Controller
    {
        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MascotaConn"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AgregarMascota(Models.Mascota mascota)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AgregarMascota", con); 
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", mascota.Nombre);
            cmd.Parameters.AddWithValue("@edad", mascota.Edad);
            cmd.Parameters.AddWithValue("@Descripcion", mascota.Descripcion);
            cmd.Parameters.AddWithValue("@correo", mascota.CorreoContacto);
            cmd.Parameters.AddWithValue("@adoptado", 0);

            con.Open();
                
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
                return false;
        }

        public List<Models.Mascota> ObtenerMascotas()
        {
            connection();
            List<Models.Mascota> mascotas = new List<Models.Mascota>();

            SqlCommand cmd = new SqlCommand("ObtenerMascota", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sda.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                mascotas.Add(
                    new Models.Mascota
                    {
                        Nombre = Convert.ToString(dr["nombre"]),
                        Edad = Convert.ToString(dr["edad"]),
                        Descripcion = Convert.ToString(dr["descripcion"]),
                        CorreoContacto = Convert.ToString(dr["correo"]),
                        Adoptada = Convert.ToBoolean(dr["adoptado"])
                    });
            }
            return mascotas;
        }
    }
}