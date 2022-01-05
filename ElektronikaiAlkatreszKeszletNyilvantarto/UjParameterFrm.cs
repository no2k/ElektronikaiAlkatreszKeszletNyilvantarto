﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    public partial class UjParameterFrm : Form
    {

        #region Fieldek
        private int tipus;
        Kategoria kategoria;
        private Parameter kivalasztottParameter;
        private List<Parameter> lista = new List<Parameter>();
        private ParameterLista parameterLista, betoltottLista;

        #endregion

        #region Propertyk
        public ParameterLista ParameterLista
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
            button3.Enabled = false;
        }
        public UjParameterFrm(Kategoria kategoria)
        {
            InitializeComponent();
            button3.Enabled = false;
            if (kategoria != null)
            {
                this.kategoria = kategoria;
                this.Text = $"Új {kategoria.KategoriaMegnevezes} paraméterek Hozzáadása";
                label1.Text = kategoria.KategoriaMegnevezes + " paraméterek";
                betoltottLista = ABKezelo.ParameterekLekerdez(kategoria);
                if (betoltottLista.Parameterek.Capacity != 0)
                {
                    lista = new List<Parameter>(betoltottLista.Parameterek);
                }

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
            if (listBox1.SelectedItem is Parameter param)
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
                    case 9:
                        {
                            felsorolChbx.Enabled = true;
                            if (felsorolChbx.Checked == false)
                            {
                                MertekEgysegTxb.Clear();
                                MertekEgysegTxb.Enabled = false;
                                MertekEgysegTxb.Text = "-";
                            }
                            tipus = 0;
                        }
                        break;
                    case 10:
                        {
                            felsorolChbx.Enabled = false;
                            MertekEgysegTxb.Enabled = true;
                            // MertekEgysegTxb.Clear();
                            tipus = 1;
                        }
                        break;
                    case 11:
                        {
                            felsorolChbx.Enabled = false;
                            MertekEgysegTxb.Enabled = true;
                            // MertekEgysegTxb.Clear();
                            tipus = 2;
                        }
                        break;
                    case 12:
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
            Parameter ujParameter;
            if (!string.IsNullOrWhiteSpace(MegnevezesTbx.Text))
            {
                if (lista.Count > 0)
                {
                    if (kivalasztottParameter != null) //parameter modositasa
                    {
                        ujParameter = new Parameter(kivalasztottParameter.ParameterSorszam, MegnevezesTbx.Text, MertekEgysegTxb.Text.Split('\n'), tipus);
                    }
                    else //parameter felvitel
                    {
                        int index = lista.Count;
                        ujParameter = new Parameter(++index, MegnevezesTbx.Text, MertekEgysegTxb.Text.Split('\n'), tipus);
                    }
                }
                else
                {
                    ujParameter = new Parameter(MegnevezesTbx.Text, MertekEgysegTxb.Text.Split('\n'), tipus);
                }
                if (!lista.Contains(ujParameter))
                {
                    if (kivalasztottParameter != null && ujParameter.ParameterSorszam == kivalasztottParameter.ParameterSorszam)
                    {
                        lista.Remove(kivalasztottParameter);
                    }
                    lista.Add(ujParameter);
                    MegnevezesTbx.Clear();
                    MertekEgysegTxb.Clear();
                    LbFrissit();
                }
                else
                {
                    MessageBox.Show("A megadott paraméterekkel megeggyező elem már van a listában!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                ParameterekTorles(kategoria, betoltottLista.Parameterek);
                ParameterHozzaAd(kategoria, ParameterekListaFrissit(lista));
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
        private void ParameterekTorles(Kategoria kategoria, List<Parameter> parameterek) 
        {
            foreach (Parameter item in parameterek)
            {
                ABKezelo.ParameterTores(kategoria, item);
            }
        }
        private List<Parameter> ParameterekListaFrissit(List<Parameter> regiLista) 
        {
            List<Parameter> ujLista = new List<Parameter>();
            int i = 1;
            foreach (Parameter item in lista)
            {
                ujLista.Add(new Parameter(i, item.ParameterMegnevezes, item.ParameterMertekEgyseg, item.ParameterTipus));
                i++;
            }
            return ujLista;
        }
        private void ParameterHozzaAd(Kategoria kategoria, List<Parameter> parameterek)
        {
            foreach (Parameter item in parameterek)
            {
                ABKezelo.UjParameter(kategoria, item);
            }
        }
        private void button3_Click(object sender, EventArgs e)  //parameter torles
        {
            if (listBox1.SelectedItem != null && MessageBox.Show("Biztosan törölni akarod a kiválasztott paramétert?\n\r A törlés, az adatbázisból való törlést is jelenti!!!", "Paraméter törlése", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lista.RemoveAt(listBox1.SelectedIndex);
                LbFrissit();
            }
        }
        private void felsorolChbx_CheckedChanged(object sender, EventArgs e)
        {
            if (felsorolChbx.Checked)
            {
                MertekEgysegTxb.Enabled = true;
                MertekEgysegTxb.Clear();
            }
            else
            {
                MertekEgysegTxb.Enabled = false;
                MertekEgysegTxb.Text = "-";
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
