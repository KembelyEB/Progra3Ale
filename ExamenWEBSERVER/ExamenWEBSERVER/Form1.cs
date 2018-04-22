using ExamenWEBSERVER.ServiceReference1;
using ExamenWEBSERVER.ServiceReference2;
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


        DataSet d = new DataSet();
    
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
       
        }

        public Efemerides.@string Efemerid(WSMeteorologicoClient ws)
        {
            string resEfe = ws.efemerides(new efemerides());
            Efemerides.@string efe = resEfe.ParseXML<Efemerides.@string>();

            return efe;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            wsIndicadoresEconomicosSoapClient ws = new wsIndicadoresEconomicosSoapClient("wsIndicadoresEconomicosSoap");

            string resp = ws.ObtenerIndicadoresEconomicosXML("318", "22/04/2018", "22/04/2018", "Kembely", "N");
            richTextBox1.Text = resp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WSMeteorologicoClient ws = new WSMeteorologicoClient("WSMeteorologico");

            Efemerides.@string efe = Efemerid(ws);

           label1.Text = efe.EFEMERIDES.EFEMERIDE_LUNA.SALE;
           label2.Text  = efe.EFEMERIDES.EFEMERIDE_LUNA.SEPONE;
           label3.Text = efe.EFEMERIDES.EFEMERIDE_SOL.SALE;
           label4.Text  = efe.EFEMERIDES.EFEMERIDE_SOL.SEPONE;
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WSMeteorologicoClient ws = new WSMeteorologicoClient("WSMeteorologico");

            string resp = ws.fecha("tns:fecha");
            richTextBox3.Text = resp;
            string res= ws.hora("tns:hora");
            richTextBox3.Text = resp + res;
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
