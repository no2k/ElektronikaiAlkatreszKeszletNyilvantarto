using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    public partial class AlkatreszFelvitelFrm : Form
    {
        public AlkatreszFelvitelFrm()
        {
            InitializeComponent();
            comboBox3.DataSource = Fajlkezelo.StringFajlbolBeolvasas("alkategoria.txt");
            comboBox1.DataSource = Fajlkezelo.StringFajlbolBeolvasas("fokategoria.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HozzaadKategoriaFrm frm = new HozzaadKategoriaFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }


    }
}
