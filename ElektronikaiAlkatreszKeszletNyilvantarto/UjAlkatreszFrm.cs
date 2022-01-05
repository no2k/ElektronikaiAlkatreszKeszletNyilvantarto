﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok;



namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    public partial class UjAlkatreszFrm : Form
    {
        #region Fieldek
        // ParameterLista lista;
        List<Keszlet> keszletLista = new List<Keszlet>();
        Keszlet keszlet;
        Alkatresz alkatresz;
        // List<AlkatreszParameter> alkatreszParameterLista = new List<AlkatreszParameter>();
        int valasztottKaterogiaIndex = 0;
        #endregion
       
        #region Property-k
        internal List<Keszlet> KeszletLista
        {
            get => keszletLista;
            set => keszletLista = value;
        }
        #endregion

        #region Konstruktorok
        public UjAlkatreszFrm()     //módosításhoz 1 alkatrész paraméterét felvinni!!!
        {
            InitializeComponent();

            button5.Enabled = false;
            parameterTSMI.Enabled = false;
            //lv1 fejlec
            lv1.Columns.Add("*", 30);
            lv1.Columns.Add("Készlet", 50);
            lv1.Columns.Add("Darabár", 75);
            lv1.Columns.Add("Kategória", 150);
            lv1.Columns.Add("Megnevezés", 150);
            lv1.Columns.Add("Paraméterek", 300);

            KategoriaFrissit();
            ListaFrissit();
        }
        #endregion

        #region ListView metódusok

        private void ListaFrissit()
        {
            try
            {
                lv1.Items.Clear();
                int i = 1;
                foreach (Keszlet item in keszletLista)
                {
                    lv1.Items.Add(LVSorFeltolt(i,item));
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private ListViewItem LVSorFeltolt(int sorszam, Keszlet keszletElem)
        {
            string parameterekString = "";
            foreach (AlkatreszParameter parameter in keszletElem.Alkatresz.Parameterek)
            {
                parameterekString += parameter + "; ";
            }
            string[] ujSor = new string[] { sorszam.ToString(), keszletElem.DarabSzam.ToString() + " Db", keszlet.DarabAr.ToString() + " Ft", keszletElem.Alkatresz.Kategoria.KategoriaMegnevezes, keszletElem.Alkatresz.Megnevezes, parameterekString };
            return new ListViewItem(ujSor);
        }
        #endregion
        
        #region Menüsor metódusok

        private void bezarTSMI_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void kategoriaTSMI_Click(object sender, EventArgs e)
        {
            UjKategoriaFrm katFrm = new UjKategoriaFrm();
            if (katFrm.ShowDialog() == DialogResult.OK)
            {
                Kategoria kat = katFrm.UjKategoria;
                try
                {
                    ABKezelo.UjKategoria(kat);
                }
                catch (ABKivetel ex)
                {
                    MessageBox.Show(ex.Message, "Adatbázis hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (katFrm.Parameterez)
                {
                    UjParameterFrm paramFrm = new UjParameterFrm((Kategoria)kat);
                    if (paramFrm.ShowDialog() == DialogResult.OK)
                    {
                        labLecLbl.Text = $"Új paraméter(ek) lett(ek) hozzáadva/módosítva a(z) {kat} kategóriához";
                    }
                }
                KategoriaFrissit();
            }
        }
        private void parameterTSMI_Click(object sender, EventArgs e)
        {
            if (kategoriaCbx.SelectedItem != null)
            {
                UjParameterFrm frm = new UjParameterFrm((Kategoria)kategoriaCbx.SelectedItem);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    labLecLbl.Text = $"Új paraméterek hozzáadva a(z){kategoriaCbx.SelectedItem} kategóriához!";
                }

                KategoriaFrissit();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott kategória", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        
        #region ComboBox metódusok
        private void KategoriaFrissit()
        {
            kategoriaCbx.SelectedIndexChanged -= KategoriaCbx_SelectedIndexChanged;
            kategoriaCbx.DataSource = null;
            kategoriaCbx.DataSource = ABKezelo.AktivKategoriaLekerdezes();
            kategoriaCbx.SelectedIndexChanged += KategoriaCbx_SelectedIndexChanged;
            if (kategoriaCbx.Items.Count > 0)
            {
                if (valasztottKaterogiaIndex > 0)
                {
                    kategoriaCbx.SelectedIndex = valasztottKaterogiaIndex;
                }
                else
                {
                    kategoriaCbx.SelectedIndex = 0;
                    KategoriaCbx_SelectedIndexChanged(this, null);
                }
            }
        } //ok
        private void KategoriaCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kategoriaCbx.SelectedItem != null)
            {
                parameterTSMI.Enabled = true;
                button5.Enabled = true;
                valasztottKaterogiaIndex = kategoriaCbx.SelectedIndex;
                VezerloFeltoltes((Kategoria)kategoriaCbx.SelectedItem);
            }
            else
            {
                button5.Enabled = false;
                parameterTSMI.Enabled = false;
                MessageBox.Show("Nincs kiválasztott kategória!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }

        #endregion
        
        #region Button metódusok

        private void Button1_Click(object sender, EventArgs e) //hozzáad listához
        {
            if (kategoriaCbx.SelectedItem != null)
            {
                List<AlkatreszParameter> alkatreszParameterLista = new List<AlkatreszParameter>();
                if (UjAlkatreszLista(alkatreszParameterLista))
                {
                    if (string.IsNullOrWhiteSpace(megnevezTxB.Text))
                    {
                        megnevezTxB.Text = (kategoriaCbx.SelectedItem as Kategoria).KategoriaMegnevezes;
                    }
                    keszlet = new Keszlet((int)keszletNud.Value, (float)darabArNud.Value, megjegyzesTbx.Text, new Alkatresz(
                         (Kategoria)kategoriaCbx.SelectedItem,
                         megnevezTxB.Text, new List<AlkatreszParameter>(alkatreszParameterLista)
                        ));

                    if (!keszletLista.Contains(keszlet))
                    {
                        keszletLista.Add(keszlet);
                    }
                    else
                    {
                        MessageBox.Show("Már van ilyen alkatrszész a listában!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    // alkatreszParameterLista.Clear();
                }
            }
            ListaFrissit();
        }
        private void button6_Click(object sender, EventArgs e) //uj alkatresz
        {
            if (kategoriaCbx.SelectedItem != null)
            {
                megjegyzesTbx.Clear();
                darabArNud.Value = 0;
                keszletNud.Value = 0;
                kategoriaCbx.SelectedIndex = 0;
            }
            else
            {
                if (MessageBox.Show("Nincs kiválasztható kategória a listában!\n\r\n\r Szeretnél új kategóriát hozzáadni???", "Figyelem...", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    kategoriaTSMI_Click(sender, e);
                }
            }
        }
        private void button5_Click_1(object sender, EventArgs e)  //torles
        {
            if (lv1.SelectedItems != null)
            {
                foreach (Keszlet item in lv1.SelectedItems)
                {
                    keszletLista.Remove(item);
                }
                ListaFrissit();
            }
        }
        private void button2_Click(object sender, EventArgs e) //OK
        {
            //adatbázis feltöltése
            
        }
        #endregion
        
        #region panel dinamikus feltöltés
        public void VezerloFeltoltes(Kategoria kategoria)
        {
            panel2.Controls.Clear();
            ParameterLista parameterek = ABKezelo.ParameterekLekerdez(kategoria);
            int elemHossza = 75; int gbUjPozicio = 0;
            Padding szelek = new Padding(0, 5, 0, 10);
            int top = 3, left = 5;
            for (int i = 0; i < parameterek.Parameterek.Count; i++)
            {
                Label lbl = new Label
                {
                    Name = "lbl" + i.ToString(),
                    Parent = panel2,
                    Margin = szelek,
                    Top = top + 10,
                    Left = left,
                    AutoSize = true,
                    Text = parameterek.Parameterek[i].ParameterMegnevezes
                };

                top = lbl.Bottom + left;

                switch (parameterek.Parameterek[i].ParameterTipus)
                {
                    case 0: //string
                        {
                            TextBox txb = new TextBox
                            {
                                Parent = panel2,
                                Margin = szelek,
                                Top = top,
                                Left = left,
                                Size = new Size(elemHossza, 23),
                                //  Size = new Size(label2.Width-(left*2), 23),
                            };
                            gbUjPozicio = txb.Top;
                            top = txb.Bottom;
                        }
                        break;
                    case 1:  //int
                        {
                            NumericUpDown nud = new NumericUpDown
                            {
                                Parent = panel2,
                                Margin = szelek,
                                Size = new Size(elemHossza, 23),
                                Top = top,
                                Left = left,
                                Increment = 1,
                                Minimum = -1000,
                                Maximum = 1000
                            };
                            gbUjPozicio = nud.Top;
                            top = nud.Bottom;
                            // elemHossza = nud.Height;
                        }
                        break;
                    case 2:  //float
                        {
                            NumericUpDown nud = new NumericUpDown
                            {
                                Parent = panel2,
                                Margin = szelek,
                                Top = top,
                                Left = left,
                                Size = new Size(elemHossza, 23),
                                Increment = 0.01m,
                                DecimalPlaces = 2,
                                Minimum = -1000,
                                Maximum = 1000
                            };
                            gbUjPozicio = nud.Top;
                            top = nud.Bottom;
                            // elemHossza = nud.Height;
                        }
                        break;
                    case 3: // bool
                        {
                            CheckBox chbx = new CheckBox
                            {
                                Parent = panel2,
                                Margin = szelek,
                                Top = top,
                                Left = left,
                                Text = null
                            };
                            gbUjPozicio = chbx.Top;
                            top = chbx.Bottom;
                        }
                        break;
                }
                if (parameterek.Parameterek[i].ParameterMertekEgyseg.Length > 1)
                {
                    ComboBox meCbx = new ComboBox
                    {
                        Name = "meCbx",
                        Parent = panel2,
                        Size = new Size(elemHossza, 23),
                        Margin = szelek,
                        Top = gbUjPozicio,
                        Left = elemHossza + 20,
                        DataSource = parameterek.Parameterek[i].ParameterMertekEgyseg,
                        // Font=new Font("Microsoft Sans Serif",9,)
                    };
                }
                else
                {
                    Label meLbl = new Label
                    {
                        Name = "meLbl",
                        Parent = panel2,
                        // Margin = szelek,
                        Top = gbUjPozicio + 2,
                        Margin = szelek,
                        Left = elemHossza + 20,
                        AutoSize = true,
                        Text = parameterek.Parameterek[i].ParameterMertekEgyseg[0]
                    };
                }

            }
        }
        private bool UjAlkatreszLista(List<AlkatreszParameter> lista)
        {
            if (panel2.Controls != null)
            {
                string str = "";
                string meStr = "";
                int ParameterSorszam = 0;
                foreach (Control item in panel2.Controls)
                {
                    string s = (item is Label lbl) ? lbl.Text : "";
                    if ((item is TextBox txb))
                    {
                        if (!string.IsNullOrWhiteSpace(txb.Text))
                        {
                            str = txb.Text;
                            ParameterSorszam++;
                        }
                        else
                        {
                            throw new ArgumentNullException($"A \"{s}\" paraméter nem lehet üres;");
                        }
                    }
                    else if (item is NumericUpDown nud)
                    {
                        str = nud.Value.ToString();
                        ParameterSorszam++;
                    }
                    else if (item is CheckBox chbx)
                    {
                        str = (chbx.Checked) ? "1" : "0";
                        ParameterSorszam++;
                    }
                    if (item is ComboBox cbx && cbx.Name == "meCbx")
                    {
                        meStr = cbx.SelectedItem.ToString();
                    }
                    else if (item is Label meLbl && meLbl.Name == "meLbl")
                    {
                        meStr = meLbl.Text;
                    }
                    else
                    {
                        //  meStr = "";
                    }
                    if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(meStr))
                    {
                        lista.Add(new AlkatreszParameter(ParameterSorszam, str, meStr));
                        str = "";
                        meStr = "";
                    }
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}
