using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EKNyilvantarto
{
    public partial class UjKategoriaFrm : Form
    {
        bool parameterez = false;
        Kategoria ujKategoria;
        List<Kategoria> lista = new List<Kategoria>();
        public bool Parameterez { get => parameterez; }
        public Kategoria UjKategoria { get => ujKategoria; }

        public UjKategoriaFrm()
        {
            InitializeComponent();
            try
            {
                lista = ABKezelo.AktivKategoriaLekerdezes();
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show("Nem tudom létrehozni a kategória listát! \r\n " + ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* public UjKategoriaFrm(Kategoria kategoria):base()
         {

         }*/

        private void button3_Click(object sender, EventArgs e) //Hozzaad es bezar
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Kategoria kat = new Kategoria(null, textBox1.Text);
                if (!lista.Contains(kat))
                {
                    ujKategoria = kat;
                }
                else
                {
                    MessageBox.Show("Már szerepel ez a kategória az adatbázisban!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                parameterez = false;
                MessageBox.Show("A kategória mező nem lehet üres!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }

        private void button2_Click(object sender, EventArgs e) //Hozzaad es parameterez
        {
            parameterez = true;
            button3_Click(sender, e);
        }
    }
}
