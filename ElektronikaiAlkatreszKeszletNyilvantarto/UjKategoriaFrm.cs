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
    public partial class UjKategoriaFrm : Form
    {
        bool parameterez = false;
        string kategoria;
        public bool Parameterez { get => parameterez; /*set => parameterez = value;*/ }
        public string Kategoria
        {
            get => kategoria;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    kategoria = value;
                }
                else
                {
                    throw new ArgumentNullException("A kategória nem lehet üres!");
                }
            }
        }

        public UjKategoriaFrm()
        {
            InitializeComponent();
        }

        public UjKategoriaFrm(string kategoria):base()
        {
            textBox1.Text = kategoria;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                kategoria = textBox1.Text;
            }
            else
            {
                parameterez = false;
                MessageBox.Show("A kategória mező nem lehet üres!","Figyelem!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parameterez = true;
            button3_Click(sender, e);
        }
    }
}
