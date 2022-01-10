using ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EKNyilvantarto
{
    public partial class UjProjektFrm : Form
    {
        Projekt projekt;
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
                    MessageBox.Show("A Projekt neve nem lehet üres!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public string ProjektLeiras { get => projektLeiras; private set => projektLeiras = value; }
        internal Projekt Projekt
        {
            get => projekt;
            set => projekt = value;
        }


        public UjProjektFrm()
        {
            InitializeComponent();
        }

        internal UjProjektFrm(Projekt projekt) : this()
        {
            //InitializeComponent();
            this.projekt = projekt;
            Text = projekt.PrjNev + " módosítása";
            megnevezTxb.Enabled = true;
            megnevezTxb.Text = projekt.PrjNev;
            leirasTxb.Text = projekt.Leiras;
            button1.Text = "Módosítás";
            label1.Text = projekt.PrjNev + " módosítása";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (projekt != null)
            {
                projekt.Leiras = leirasTxb.Text;
            }
            else if (!string.IsNullOrWhiteSpace(megnevezTxb.Text))
            {
                projekt = new Projekt(megnevezTxb.Text, leirasTxb.Text, ABKezelo.UtolsoProjektAzonosito(), new List<AlkatreszOsztalyok.Keszlet>());
            }
            else
            {
                MessageBox.Show("A projekt neve nem lehet üres!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DialogResult = DialogResult.None;
            }
        }
    }
}
