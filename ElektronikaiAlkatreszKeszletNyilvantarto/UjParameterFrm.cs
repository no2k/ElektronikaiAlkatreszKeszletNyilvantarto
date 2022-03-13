using EKNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EKNyilvantarto
{
    public partial class UjParameterFrm : Form
    {

        #region Fieldek
        private int tipus;
        Kategoria kategoria;
        private ParameterDef kivalasztottParameter;
        private List<ParameterDef> lista = new List<ParameterDef>();
        private ParameterDefLista parameterLista, betoltottLista;

        #endregion

        #region Propertyk
        public ParameterDefLista ParameterLista
        {
            get => parameterLista;
            private set
            {
                if (value != null)
                {
                    parameterLista = value;
                }
                else
                {
                    throw new ArgumentNullException("Az átadott paraméter lista üres!");
                }
            }
        }
        #endregion

        #region Konstruktorok
        public UjParameterFrm()
        {
            InitializeComponent();
            // button3.Enabled = false;
        }
        public UjParameterFrm(Kategoria kategoria) : this()
        {
            // InitializeComponent();
            button3.Enabled = false;
            if (kategoria != null)
            {
                if (ABKezelo.VanMarIlyenKategoriavalAlkatresz(kategoria))
                {
                    MessageBox.Show("Ezekkel a paraméterekkel már van alkatrész felvéve az adatbázisba! A további helyes működés érdekében, a paraméterek módosítására nincs lehetőség!", "Figyelem!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    listBox1.Enabled = false;
                    button5.Enabled = false;
                    button3.Enabled = false;
                    button2.Enabled = false;
                    button1.Enabled = false;
                    panel1.Enabled = false;
                }
                this.kategoria = kategoria;
                this.Text = $"Új {kategoria.KategoriaMegnevezes} paraméterek Hozzáadása";
                label1.Text = kategoria.KategoriaMegnevezes + " paraméterek";
                betoltottLista = ABKezelo.ParameterDefLekerdez(kategoria);
                if (betoltottLista.Parameterek.Capacity != 0)
                {
                    lista = new List<ParameterDef>(betoltottLista.Parameterek);
                }
                button3.Enabled = false;
                LbFrissit();
            }
        }
        #endregion

        #region Metódusok
        private void LbFrissit()
        {
            listBox1.SelectedIndexChanged -= listBox1_SelectedIndexChanged;
            listBox1.DataSource = null;
            listBox1.DataSource = lista;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is ParameterDef param)
            {
                MegnevezesTbx.Text = param.ParameterMegnevezes;
                MertekEgysegTxb.Text = string.Join(Environment.NewLine, param.ParameterMertekEgyseg);
                switch (param.ParameterTipus)
                {
                    case 0: { radioButton1.Checked = true; } break;
                    case 1: { radioButton2.Checked = true; } break;
                    case 2: { radioButton3.Checked = true; } break;
                    case 3: { radioButton4.Checked = true; } break;
                }
                button3.Enabled = true;
                kivalasztottParameter = param;
                button1.Text = "Paraméter módosítás";
            }
        }
        private void AllRadioButton_Checked(object sender, EventArgs e)
        {
            if (sender is RadioButton radio)
            {
                switch (radio.TabIndex)
                {
                    case 9:     //Szöveg
                        {
                            felsorolChbx.Enabled = true;
                            if (felsorolChbx.Checked == false)
                            {
                                MertekEgysegTxb.Clear();
                                MertekEgysegTxb.Text = "-";
                                tipus = 0;
                            }
                            else
                            {
                                tipus = 4;
                            }
                        }
                        break;
                    case 10:        //Egész szám
                        {
                            felsorolChbx.Enabled = false;
                            MertekEgysegTxb.Enabled = true;
                            tipus = 1;
                        }
                        break;
                    case 11:        //Tört Szám
                        {
                            felsorolChbx.Enabled = false;
                            MertekEgysegTxb.Enabled = true;
                            tipus = 2;
                        }
                        break;
                    case 12:        //Logikai
                        {
                            felsorolChbx.Enabled = false;
                            MertekEgysegTxb.Clear();
                            MertekEgysegTxb.Enabled = false;
                            MertekEgysegTxb.Text = "-";
                            tipus = 3;
                        }
                        break;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            ParameterDef ujParameter;
            if (!string.IsNullOrWhiteSpace(MegnevezesTbx.Text))
            {
                if (lista.Count > 0)
                {
                    if (kivalasztottParameter != null) //parameter modositasa
                    {
                        ujParameter = new ParameterDef(kivalasztottParameter.ParameterSorszam, MegnevezesTbx.Text, MertekEgysegTxb.Text.Split('\n'), tipus);
                    }
                    else //parameter felvitel
                    {
                        int index = lista.Count;
                        ujParameter = new ParameterDef(++index, MegnevezesTbx.Text, MertekEgysegTxb.Text.Split('\n'), tipus);
                    }
                }
                else
                {
                    ujParameter = new ParameterDef(MegnevezesTbx.Text, MertekEgysegTxb.Text.Split('\n'), tipus);
                }
                if (!lista.Contains(ujParameter))
                {
                    if (kivalasztottParameter != null && ujParameter.ParameterSorszam == kivalasztottParameter.ParameterSorszam)
                    {
                        int index2 = lista.IndexOf(kivalasztottParameter);
                        lista[index2] = ujParameter;
                    }
                    else
                    {
                        lista.Add(ujParameter);
                    }
                    LbFrissit();
                }
                else
                {
                    MessageBox.Show("A megadott paraméterekkel megeggyező elem már van a listában!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                button5_Click(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Minden mező kitöltése kötelező!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//Parameter hozzaadas
        private void button2_Click(object sender, EventArgs e) //Rogzit es bezar
        {
            if (lista.Count > 0)
            {
                if (betoltottLista != null)
                {
                    ParameterModositas();
                }
                else
                {
                    foreach (ParameterDef item in lista)
                    {
                        ABKezelo.UjParameterDef(kategoria, item);
                    }
                }
            }
            else
            {
                if (MessageBox.Show("A paraméter lista üres!", "Figyelem", MessageBoxButtons.OKCancel
                     , MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    DialogResult = DialogResult.None;
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
        private void ParameterModositas()
        {
            if (betoltottLista.Parameterek.Count < lista.Count)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    if (i < betoltottLista.Parameterek.Count)
                    {
                        foreach (ParameterDef betoltott in betoltottLista)
                        {
                            if (lista[i].ParameterSorszam == betoltott.ParameterSorszam &&
                                (lista[i].ParameterMegnevezes != betoltott.ParameterMegnevezes ||
                                lista[i].ParameterMertekEgyseg != betoltott.ParameterMertekEgyseg ||
                                lista[i].ParameterTipus != betoltott.ParameterTipus))
                            {
                                ABKezelo.ParameterDefModositas(kategoria, lista[i]);
                            }
                        }
                    }
                    else
                    {
                        ABKezelo.UjParameterDef(kategoria, lista[i]);
                    }
                }
            }
            else
            {
                foreach (ParameterDef regi in betoltottLista)
                {
                    ABKezelo.ParameterDefTores(kategoria, regi);
                }
                int UjSorszam = 1;
                foreach (ParameterDef item in lista)
                {
                    item.ParameterSorszam = UjSorszam;
                    ABKezelo.UjParameterDef(kategoria, item);
                    UjSorszam++;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)  //parameter torles
        {
            if (listBox1.SelectedItem != null && MessageBox.Show("Biztosan törölni akarod a kiválasztott paramétert?", "Paraméter törlése", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lista.RemoveAt(listBox1.SelectedIndex);
                LbFrissit();
            }
        }
        private void felsorolChbx_CheckedChanged(object sender, EventArgs e)
        {
            if (felsorolChbx.Checked)
            {
                MertekEgysegTxb.Clear();
                tipus = 4;
            }
            else
            {
                tipus = 0;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            kivalasztottParameter = null;
            MegnevezesTbx.Clear();
            MertekEgysegTxb.Clear();
            radioButton1.Checked = true;
            button1.Text = "Hozzáadás";
            button3.Enabled = false;
        }  // bevitel reset
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }  //mégsem
        #endregion
    }
}
