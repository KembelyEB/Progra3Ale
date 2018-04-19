using ExamenWEBSERVER.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenWEBSERVER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      //  WSMeteorologicoService

        public void button1_Click (object sender, EventArgs e)
        {
            wsIndicadoresEconomicosSoapClient ws = new wsIndicadoresEconomicosSoapClient("wsIndicadoresEconomicosSoap");

            string resp = ws.ObtenerIndicadoresEconomicosXML("318", "19/04/2018", "19/04/2018", "Kembely", "N");
            richTextBox1.Text = resp;
        }
    }
}
