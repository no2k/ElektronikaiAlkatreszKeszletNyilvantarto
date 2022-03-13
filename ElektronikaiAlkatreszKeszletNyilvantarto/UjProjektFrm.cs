using EKNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EKNyilvantarto
{
    public partial class UjProjektFrm : Form
    {
        Projekt projekt;

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
            megjegyzesTxb.Text = projekt.Megjegyzes;
            button1.Text = "Módosítás";
            label1.Text = projekt.ProjektNev + " módosítása";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (projekt != null)
                {
                    if (projekt.ProjektNev != megnevezTxb.Text || !ABKezelo.VanIlyenProjekt(megnevezTxb.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(megnevezTxb.Text))
                        {
                            projekt.ProjektNev = megnevezTxb.Text;
                            projekt.Leiras = leirasTxb.Text;
                            projekt.Megjegyzes = megjegyzesTxb.Text;
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            throw new ArgumentNullException("Új projekt megnevezése", "A beviteli mező nem lehet üres!");
                            DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Már van egy ilyen elnevezésű projekt az adatbázisban!");
                    }
                }
                else
                {
                    AdatokTeszteleseEsLetrehozas();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DialogResult = DialogResult.None;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DialogResult = DialogResult.None;
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
                throw new ArgumentNullException("Új projekt megnevezése", "A beviteli mező nem lehet üres!");
                //DialogResult = DialogResult.None;
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
                throw new ArgumentException("Már van egy ilyen elnevezésű projekt az adatbázisban!");
                //DialogResult = DialogResult.None;
            }
        }
    }
}
