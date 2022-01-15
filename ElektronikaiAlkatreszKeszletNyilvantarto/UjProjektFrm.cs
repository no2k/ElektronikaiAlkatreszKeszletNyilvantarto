using EKNyilvantarto.AlkatreszOsztalyok;
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
            Text = projekt.ProjektNev + " módosítása";
            megnevezTxb.Enabled = true;
            megnevezTxb.Text = projekt.ProjektNev;
            leirasTxb.Text = projekt.Leiras;
            button1.Text = "Módosítás";
            label1.Text = projekt.ProjektNev + " módosítása";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (projekt != null)
            {
                projekt.Leiras = leirasTxb.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                AdatokTeszteleseEsLetrehozas();

            }

        }

        private void AdatokTeszteleseEsLetrehozas()
        {
            if (!string.IsNullOrWhiteSpace(megnevezTxb.Text))
            {
                UjProjektLetrehoz();
            }
            else
            {
                MessageBox.Show("A projekt neve nem lehet üres!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DialogResult = DialogResult.None;
            }
        }

        private void UjProjektLetrehoz()
        {
            if (!ABKezelo.VanIlyenProjekt(megnevezTxb.Text))
            {
                projekt = new Projekt(megnevezTxb.Text, leirasTxb.Text, null, new List<Keszlet>(), megjegyzesTxb.Text, false);
            }
            else
            {
                MessageBox.Show("Már van egy ilyen elnevezésű projekt az adatbázisban!","Figyelem",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                DialogResult = DialogResult.None;
            }
        }
    }
}
