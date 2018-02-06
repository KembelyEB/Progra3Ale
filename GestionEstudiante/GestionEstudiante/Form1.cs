using EstudianteDatos;
using EstudianteNegocio;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionEstudiante
{
    public partial class Form1 : Form
    {
        static NpgsqlConnection conexion;
        static NpgsqlCommand cmd;

        EstudianteDa estudiante;

        public static int tipoOperacion = 0;

        public Form1()
        {
            InitializeComponent();
            estudiante = new EstudianteDa();

        }

       
           
       

        private void button1_Click(object sender, EventArgs e)
        {

            int cedula = Convert.ToInt32(textBox1.Text);
            string nombre = textBox2.Text;
            string nacimiento = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string residencia = textBox3.Text;

            EstudianteDa Estudiantes = new EstudianteDa();
            Estudiantes.InsertarDatos(cedula, nombre, nacimiento, residencia);

            MessageBox.Show("Se ha insertado el registro correctamente.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EstudianteDa estudiante = new EstudianteDa();

            estudiante.Conexion();
            conexion.Open();


            cmd = new NpgsqlCommand("SELECT cedula, nombre, nacimiento, residencia FROM estudiante WHERE nombre ='" + comboBox1.Text + "'", conexion);

            cmd.ExecuteNonQuery();
            NpgsqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    string cedula = dr["cedula"].ToString();
                    textBox4.Text = cedula;

                    string nombre = dr["nombre"].ToString();
                    textBox5.Text = nombre;

                    string nacimiento = dr["nacimiento"].ToString();
                    dateTimePicker2.Text = nacimiento;

                    string residencia= dr["residencia"].ToString();
                    textBox6.Text = residencia;



                }
            }


            conexion.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<EstudianteDa> lista = EstudianteDa.estudiante.gg();

            foreach(EstudianteDa elemento in lista)
            {

                comboBox1.Items.Add(elemento nombre);


            }


            comboBox1.SelectedIndex = 0;




        }
    }
}
