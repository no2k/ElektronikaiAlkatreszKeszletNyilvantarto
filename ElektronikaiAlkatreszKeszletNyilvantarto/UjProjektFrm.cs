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
    public partial class UjProjektFrm : Form
    {
        string projektNev;
        string projektLeiras;
        public string ProjektNev
        {
            get => projektNev;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    projektNev = value;
                }
                else
                {
                    MessageBox.Show("A Projekt neve nem lehet üres!","Figyelem",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            } 
        }
        public string ProjektLeiras { get => projektLeiras; private set => projektLeiras = value; }


        public UjProjektFrm()
        {
            InitializeComponent();
        }
        public UjProjektFrm(string projektNev, string projektLeiras) : this()
        {
            ProjektNev = projektNev;
            ProjektLeiras = projektLeiras;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
