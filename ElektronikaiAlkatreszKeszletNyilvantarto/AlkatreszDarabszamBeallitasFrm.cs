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
        Keszlet keresett;
        List<Keszlet> alkatreszek = new List<Keszlet>();
        int maxDarabszam;
        Point scrollPointPanel = new Point(0, 0);
        internal List<Keszlet> Alkatreszek
        {
            get => alkatreszek;
            set
            {
                alkatreszek = value;
            }
        }

        public AlkatreszDarabszamBeallitasFrm()
        {
            
            InitializeComponent();
            this.panel1.MouseWheel += Panel_MouseWheel;
            this.panel2.MouseWheel += Panel_MouseWheel;
        }

        private void Panel_MouseWheel(object sender, MouseEventArgs e)
        {
            Point nullPont = new Point(0, 0);
            panel1.AutoScrollPosition = nullPont;
            panel2.AutoScrollPosition = nullPont;
            //az egérgörgő scrollozás miatt, ne csináljon semmit
        }

        public AlkatreszDarabszamBeallitasFrm(List<Keszlet> alkatreszek) : this()
        {
            this.alkatreszek = alkatreszek;
            Listazas();
        }

        public AlkatreszDarabszamBeallitasFrm(List<Keszlet> alkatreszek,int maxDarabszam) : this()
        {
            this.alkatreszek = alkatreszek;
            this.maxDarabszam = maxDarabszam;
            Listazas();
        }


        private void Listazas()
        {
            NumericUpDown nud;
            Label lbl;
            int left = 3;
            int top = 5;
            int nudWidth = panel1.Width - 35;
            foreach (Keszlet alkatresz in alkatreszek)
            {
                keresett = ABKezelo.KeszletKeres(alkatresz.Alkatresz);
                string alkatreszString = $"[{alkatresz.Alkatresz.Kategoria.KategoriaMegnevezes}]  {alkatresz.Alkatresz.Megnevezes}: {alkatresz.Alkatresz.ToString().Replace("\r", " ")}";
                nud = new NumericUpDown()
                {
                    Parent = panel1,
                    Left = left,
                    Top = top,
                    Width = nudWidth,
                    Name = alkatresz.KeszletId.ToString(),
                    DecimalPlaces = 2,
                    
                };
                if (maxDarabszam >0)
                {
                    nud.Maximum = (decimal)maxDarabszam;
                }
                else
                {
                    nud.Maximum = ((decimal)keresett.DarabSzam == 0) ? 2000 : (decimal)keresett.DarabSzam;
                }
                nud.Value = (decimal)(float)alkatresz.DarabSzam;
                lbl = new Label()
                {
                    Parent = panel2,
                    Left = left,
                    Top = top + 2,
                    Text = alkatreszString,
                    Width = 340
                };
                top = nud.Bottom + 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control vezerlo in panel1.Controls)
            {
                if (vezerlo is NumericUpDown nud)
                {
                    for (int i = 0; i < alkatreszek.Count; i++)
                    {
                        if (int.Parse(nud.Name) == alkatreszek[i].KeszletId)
                        {
                            alkatreszek[i].DarabSzam = (float)nud.Value;

                        }
                    }
                }
            }
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            panel2.Scroll -= panel2_Scroll;
            scrollPointPanel = panel1.AutoScrollPosition;
            Point beallitottPozicio = new Point(scrollPointPanel.X, -scrollPointPanel.Y);
            panel2.AutoScrollPosition = beallitottPozicio;
            panel2.Scroll += panel2_Scroll;
        }

        private void panel2_Scroll(object sender, ScrollEventArgs e)
        {
            panel1.Scroll -= panel1_Scroll;
            scrollPointPanel = panel2.AutoScrollPosition;
            Point beallitottPozicio = new Point(scrollPointPanel.X, -scrollPointPanel.Y);
            panel1.AutoScrollPosition = beallitottPozicio;
            panel1.Scroll += panel1_Scroll;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alkatreszek.Clear();
        }
    }
}
