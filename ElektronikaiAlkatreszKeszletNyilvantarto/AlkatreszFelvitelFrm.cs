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
        List<string> alKategoria;
        List<string> foKategoria;
        public AlkatreszFelvitelFrm()
        {
            InitializeComponent();
            alKategoria=Fajlkezelo.StringFajlbolBeolvasas("alkategoria.txt");
            foKategoria=Fajlkezelo.StringFajlbolBeolvasas("fokategoria.txt");
            comboBox3.DataSource = alKategoria;
            comboBox1.DataSource = foKategoria;
        }
        void CBFrissít() 
        {
            comboBox1.DataSource = null;
            comboBox3.DataSource = null;
            comboBox1.DataSource = alKategoria;
            comboBox3.DataSource = foKategoria;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HozzaadKategoriaFrm frm = new HozzaadKategoriaFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        groupBox2.Visible = false;
                        groupBox1.BringToFront();
                        groupBox1.Visible = true;
                    }
                    break;
                case 1:
                    {
                        groupBox1.Visible = false;
                        groupBox2.BringToFront();
                        groupBox2.Visible = true;
                    }
                    break;
            } 
        }
    }
}
