using EKNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKNyilvantarto
{
    partial class AlkatreszDarabszamBeallitasFrm : Form
    {
        List<Keszlet> alkatreszek = new List<Keszlet>();

        internal List<Keszlet> Alkatreszek
        {
            get => alkatreszek;
            set
            {
                alkatreszek = value;
           //     Listazas();

                    }
        }

        public AlkatreszDarabszamBeallitasFrm()
        {
            InitializeComponent();
            
               
           
        }

        public AlkatreszDarabszamBeallitasFrm(List<Keszlet> alkatreszek):this()
        {
            this.alkatreszek = alkatreszek; 
            Listazas();
        }

        private void Listazas()
        {
            NumericUpDown nud;
            Label lbl;
            int left = 3;
            int top = 15;
            int nudWidth = darabSzamGbx.Width - 6;
            foreach (Keszlet alkatresz in alkatreszek)
            {
                string alkatreszString = $"[{alkatresz.Alkatresz.Kategoria.KategoriaMegnevezes}]  {alkatresz.Alkatresz.Megnevezes}: {alkatresz.Alkatresz}";
                nud = new NumericUpDown()
                {
                    Parent = darabSzamGbx,
                    Left = left,
                    Top = top,
                    Width = nudWidth,
                    Name =alkatresz.KeszletId.ToString(),
                    DecimalPlaces = 2,
                    Value = (decimal)(float)alkatresz.DarabSzam,
                };

                lbl = new Label()
                {
                    Parent = alkatreszekGbx,
                    Left = left,
                    Top = top + 2,
                    Text = alkatreszString
                };
                top = nud.Bottom + 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control vezerlo in darabSzamGbx.Controls)
            {
                if ((vezerlo is NumericUpDown nud))
                {
                    foreach (Keszlet alkatresz in alkatreszek)
                    {
                        if (int.Parse(nud.Name) == alkatresz.KeszletId)
                        {
                            alkatresz.DarabSzam = (float)nud.Value;
                        }
                    }
                }
            }
        }
    }
}
