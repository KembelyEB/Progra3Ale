using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudianteDatos
{
   public  class EstudianteDa
    {

        static NpgsqlConnection conexion;
        static NpgsqlCommand cmd;

        public  void Conexion()
        {
            string servidor = "localhost";
            int puerto = 5432;
            string usuario = "postgres";
            string clave = "lanegra15";
            string baseDatos = "GestionEstudiante";

            string cadenaConexion = "Server=" + servidor + ";" + "Port=" + puerto + ";" + "User Id=" + usuario + ";" + "Password=" + clave + ";" + "Database=" + baseDatos;
            conexion = new NpgsqlConnection(cadenaConexion);
        }

        public void InsertarDatos(int cedula, string nombre, string nacimiento, string residencia)
        {
            Conexion();
            conexion.Open();
            cmd = new NpgsqlCommand("INSERT INTO estudiante (cedula, nombre, nacimiento,residencia) VALUES ('" + cedula + "', '" + nombre + "', '" + nacimiento + "', '" + residencia + "')", conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void ModificarDatos(int cedula, string nombre, string nacimiento, string residencia)
        {
            Conexion();
            conexion.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE estudiante SET nombre = '" + nombre + "', nacimiento = '" + nacimiento + "', residencia = '" + residencia + "' WHERE cedula = '" + cedula + "'", conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarDatos(int cedula)
        {
            Conexion();
            conexion.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM estudiante WHERE cedula = '" + cedula + "'", conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void gg()
        {
            Conexion();
            conexion.Open();
            List <string> lista = new List<string>();
            cmd = new NpgsqlCommand("Select nombre from estudiante", conexion);
            cmd.ExecuteNonQuery();
            NpgsqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                    lista.Add(dr.GetString(1));
                    lista.Add(dr.GetString(2));
                    lista.Add(dr.GetString(3));
                }
            }

            conexion.Close();
        }
    }
}
