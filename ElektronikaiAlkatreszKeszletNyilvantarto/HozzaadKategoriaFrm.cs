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
    public partial class HozzaadKategoriaFrm : Form
    {
        private string kategoria;
        public string Kategoria { get => kategoria; /*private set => kategoria = value;*/ }
        public HozzaadKategoriaFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                kategoria = textBox1.Text;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }
    }
}
