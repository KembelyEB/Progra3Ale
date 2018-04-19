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

namespace ProyectoDataSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static NpgsqlConnection conexion;
        static NpgsqlCommand cmd;

        public static void Conexion()
        {
            string servidor = "localhost";
            int puerto = 5432;
            string usuario = "postgres";
            String clave = "lanegra15";
            string baseDatos = "DataSet";

            string cadenaConexion = "Server=" + servidor + ";" + "Port=" + puerto + ";" + "User Id=" + usuario + ";" + "Password=" + clave + ";" + "Database=" + baseDatos;
            conexion = new NpgsqlConnection(cadenaConexion);
        }

        public void CargarGrit()
        {
            Conexion();
            conexion.Open();
            DataSet dataset = new DataSet();

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT cedula, nombre, edad, comentario, fecha FROM estudiante", conexion);
            adapter.Fill(dataset, "estudiante");
            dataGridView1.DataSource = dataset.Tables[0];
            dataGridView1.Columns[0].HeaderCell.Value = "CEDULA";
            dataGridView1.Columns[1].HeaderCell.Value = "NOMBRE";
            dataGridView1.Columns[2].HeaderCell.Value = "EDAD";
            dataGridView1.Columns[3].HeaderCell.Value = "COMENTARIO";
            dataGridView1.Columns[4].HeaderCell.Value = "FECHA NACIMIENTO";
            conexion.Close();
        }

        public void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        public void Eliminar()
        {
            foreach (DataGridViewRow c in dataGridView1.Rows)

            {



                if ((bool)c.Cells[1].Value == true)

                {

                    dataGridView1.Rows.Remove(c);

                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Conexion();
            conexion.Open();
            cmd = new NpgsqlCommand("INSERT INTO estudiante(cedula, nombre, edad, comentario, fecha) VALUES ('" + textBox1.Text + "' ,'"
                + textBox2.Text + "', '" + textBox3.Text + "' ,'" + textBox4.Text + "'," + "'" + dateTimePicker1.Text + "')", conexion);
            cmd.ExecuteNonQuery();
            CargarGrit();
            Limpiar();
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion();
            conexion.Open();
            cmd = new NpgsqlCommand("UPDATE estudiante SET nombre ='" + textBox2.Text + "'," + "edad ='" + textBox3.Text + "',comentario = '" + textBox4.Text + "'fecha = '" + dateTimePicker1.Text + "' WHERE cedula = '" + textBox1.Text + "'", conexion);
            cmd.ExecuteNonQuery();
            CargarGrit();
            Limpiar();
            conexion.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Conexion();
            //conexion.Open();
            //cmd = new NpgsqlCommand("DELETE FROM estudiante WHERE cedula = '" + textBox1.Text + "'", conexion);
            // cmd.ExecuteNonQuery();
            //CargarGrit();
            // Limpiar();
            //conexion.Close();


            if (dataGridView1.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

            using (NpgsqlConnection cnn = new NpgsqlConnection("connection string"))
            {

                string query = "DELETE FROM estudiante WHERE cedula = '@param'";

                NpgsqlCommand cmd = new NpgsqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@param", id);

                cmd.ExecuteNonQuery();

            }

            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }
    

      

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = dateTimePicker1.Text.ToString();
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                //Initialized a new DateTimePicker Control  
                dateTimePicker1 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(dateTimePicker1);

                // Setting the format (i.e. 2014-10-10)  
                dateTimePicker1.Format = DateTimePickerFormat.Short;

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                dateTimePicker1.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                dateTimePicker1.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                dateTimePicker1.CloseUp += new EventHandler(dateTimePicker1_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                dateTimePicker1.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                dateTimePicker1.Visible = true;
            }
        }
    }
}
