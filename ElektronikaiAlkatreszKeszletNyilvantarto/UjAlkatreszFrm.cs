using EKNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace EKNyilvantarto
{
    public partial class UjAlkatreszFrm : Form
    {
        #region Fieldek
        // ParameterLista lista;
        List<Keszlet> meglevoKeszletLista = new List<Keszlet>();
        List<Keszlet> ujKeszletLista = new List<Keszlet>();
        Keszlet keszlet, keresett;
        int keresettIndex;
        // List<AlkatreszParameter> alkatreszParameterLista = new List<AlkatreszParameter>();
        int valasztottKaterogiaIndex = 0;
        int AlkatreszId;
        #endregion

        #region Property-k
        internal List<Keszlet> KeszletLista
        {
            get => ujKeszletLista;
            set => ujKeszletLista = value;
        }
        #endregion

        #region Konstruktorok
        public UjAlkatreszFrm()     //módosításhoz 1 alkatrész paraméterét felvinni!!!
        {
            InitializeComponent();

            AlkatreszId = ABKezelo.UtolsoAlkatreszId();
            button5.Enabled = false;
            parameterTSMI.Enabled = false;
            //lv1 fejlec
            LVFejlecFeltolt();

            KategoriaFrissit();
            ListaFrissit();
        }

        #endregion

        #region ListView metódusok
        private void LVFejlecFeltolt()
        {
            lv1.Columns.Add("*", 30);
            lv1.Columns.Add("Készlet", 50);
            lv1.Columns.Add("Darabár", 75);
            lv1.Columns.Add("Kategória", 150);
            lv1.Columns.Add("Megnevezés", 150);
            lv1.Columns.Add("Paraméterek", 300);
            lv1.Columns.Add("Megjegyzés");
        }
        private void ListaFrissit()
        {
            try
            {
                lv1.Items.Clear();
                int i = 1;
                foreach (Keszlet item in ujKeszletLista)
                {
                    lv1.Items.Add(LVSorFeltolt(i, item));
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
            string[] ujSor = new string[] { sorszam.ToString(), keszletElem.DarabSzam.ToString() + " Db", keszletElem.DarabAr.ToString() + " Ft", keszletElem.Alkatresz.Kategoria.KategoriaMegnevezes, keszletElem.Alkatresz.Megnevezes, keszletElem.Alkatresz.ToString(), keszletElem.Megjegyzes };
            return new ListViewItem(ujSor);
        }
        private void Lv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button5.Enabled = true;
            if (lv1.SelectedItems.Count == 0) return;
            kategoriaCbx.Enabled = false;
            keresett = LVItembolKeszlet(lv1.SelectedItems);
            keresettIndex = KeszletLista.IndexOf(keresett);
            kategoriaCbx.SelectedIndex = kategoriaCbx.FindStringExact(keresett.Alkatresz.Kategoria.ToString());
            megnevezTxB.Text = keresett.Alkatresz.Megnevezes;
            darabArNud.Value = (decimal)keresett.DarabAr;
            keszletNud.Value = (decimal)keresett.DarabSzam;
            megjegyzesTbx.Text = keresett.Megjegyzes;
            DinamikusListaAdatFeltolt(keresett.Alkatresz.Parameterek);
            button1.Text = "Módosítás";

        }

        private Keszlet LVItembolKeszlet(SelectedListViewItemCollection lvItems)
        {
            string keresendo = string.Empty;
            foreach (ListViewItem item in lv1.SelectedItems)
            {
                keresendo = item.SubItems[5].Text;
            }
            return KeszletLista.FirstOrDefault(elem => elem.Alkatresz.ToString() == keresendo);
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
            kategoriaCbx.DataSource = ABKezelo.KategoriaLekerdezes();
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
                //button5.Enabled = true;
                valasztottKaterogiaIndex = kategoriaCbx.SelectedIndex;
                VezerloFeltoltes((Kategoria)kategoriaCbx.SelectedItem);
            }
            else
            {
                //button5.Enabled = false;
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
                button5.Enabled = false;
                List<AlkatreszParameter> alkatreszParameterLista = new List<AlkatreszParameter>();
                if (UjAlkatreszLista(alkatreszParameterLista) && keszletNud.Value > 0)
                {
                    if (string.IsNullOrWhiteSpace(megnevezTxB.Text))
                    {
                        megnevezTxB.Text = (kategoriaCbx.SelectedItem as Kategoria).KategoriaMegnevezes;
                    }
                    if (keresett != null)
                    {
                        int id = KeszletLista[keresettIndex].Alkatresz.AlkatreszId;
                        KeszletLista[keresettIndex] = new Keszlet(null, (float)keszletNud.Value, (float)darabArNud.Value, megjegyzesTbx.Text, new Alkatresz(id,
                         (Kategoria)kategoriaCbx.SelectedItem,
                         megnevezTxB.Text, new List<AlkatreszParameter>(alkatreszParameterLista)
                        )); ;
                        button1.Text = "Listához ad";
                        keresett = null;
                        ListaFrissit();
                        kategoriaCbx.Enabled = true;
                    }
                    else
                    {
                        AlkatreszId++;
                        keszlet = new Keszlet(null, (float)keszletNud.Value, (float)darabArNud.Value, megjegyzesTbx.Text, new Alkatresz(AlkatreszId,
                             (Kategoria)kategoriaCbx.SelectedItem,
                             megnevezTxB.Text, new List<AlkatreszParameter>(alkatreszParameterLista)
                            ));
                        ListahozAd(keszlet);
                        darabArNud.Value = 0;
                        keszletNud.Value = 0;
                        megnevezTxB.Clear();
                        //megjegyzesTbx.Clear();
                    }
                    ListaFrissit();
                }
                else
                {
                    MessageBox.Show("Az alkatrész darabszáma nem lehet kevesebb mint 1!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ListahozAd(Keszlet keszlet)
        {
            if (!ujKeszletLista.Contains(keszlet))
            {
                ujKeszletLista.Add(keszlet);
                megnevezTxB.Clear();
            }
            else
            {
                if (MessageBox.Show("Már van ilyen alkatrszész a listában!\n\rSzeretnéd frissíteni az alkatrész darabszámát és az árát?", "Figyelem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Keszlet alkatresz in ujKeszletLista)
                    {
                        if (alkatresz.Equals(keszlet))
                        {
                            alkatresz.DarabAr = keszlet.DarabAr;
                            alkatresz.DarabSzam += keszlet.DarabSzam;

                            //ListaFrissit();
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) //uj alkatresz
        {
            button5.Enabled = false;
            button1.Text = "Listához ad";
            lv1.SelectedIndexChanged -= Lv1_SelectedIndexChanged;
            lv1.SelectedIndices.Clear();
            lv1.SelectedIndexChanged += Lv1_SelectedIndexChanged;
            kategoriaCbx.Enabled = true;
            if (kategoriaCbx.SelectedItem != null)
            {
                megnevezTxB.Clear();
                megjegyzesTbx.Clear();
                darabArNud.Value = 0;
                keszletNud.Value = 0;
                kategoriaCbx.SelectedIndex = 0;
                VezerloFeltoltes((Kategoria)kategoriaCbx.SelectedItem);
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
            button5.Enabled = false;
            if (lv1.SelectedItems.Count != 0)
            {
                ujKeszletLista.Remove(LVItembolKeszlet(lv1.SelectedItems));
                lv1.SelectedIndices.Clear();
                ListaFrissit();
                button6_Click(sender, EventArgs.Empty);
            }
        }
        private void button2_Click(object sender, EventArgs e) //OK
        {
            if (ujKeszletLista.Count > 0)
            {
                foreach (Keszlet ujKeszlet in ujKeszletLista)
                {
                    if (ABKezelo.VanIlyenAlkatresz(ujKeszlet.Alkatresz))
                    {
                        keszlet = ABKezelo.KeszletKeresParameterekAlapjan(ujKeszlet.Alkatresz.Parameterek);
                        keszlet.DarabSzam += ujKeszlet.DarabSzam;
                        keszlet.DarabAr = ujKeszlet.DarabAr;
                        if (!string.IsNullOrEmpty(ujKeszlet.Megjegyzes))
                        {
                            keszlet.Megjegyzes = ujKeszlet.Megjegyzes;
                        }

                        ABKezelo.KeszletModositas(keszlet);
                    }
                    else
                    {
                        ujKeszlet.KeszletId = ABKezelo.UjAlkatresz(ujKeszlet.Alkatresz);
                        ABKezelo.UjKeszlet(ujKeszlet);
                    }
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }
        #endregion

        #region panel dinamikus feltöltés
        public void VezerloFeltoltes(Kategoria kategoria)
        {
            panel2.Controls.Clear();
            ParameterDefLista parameterek = ABKezelo.ParameterDefLekerdez(kategoria);
            int elemHossza = (panel2.Height / 2) - 10;
            int gbUjPozicio = 0;
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
                    Text = parameterek.Parameterek[i].ParameterMegnevezes + ":"
                };
                top = lbl.Bottom + left;
                switch (parameterek.Parameterek[i].ParameterTipus)
                {
                    case 0: //string
                        {
                            TextBox txb = new TextBox
                            {
                                Name = "txb",
                                Parent = panel2,
                                Margin = szelek,
                                Top = top,
                                Left = left,
                                Size = new Size(elemHossza, 23),
                            };
                            gbUjPozicio = txb.Top;
                            top = txb.Bottom;
                        }
                        break;
                    case 1:  //int
                        {
                            NumericUpDown nud = new NumericUpDown
                            {
                                Name = "intNud",
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
                        }
                        break;
                    case 2:  //float
                        {
                            NumericUpDown nud = new NumericUpDown
                            {
                                Name = "floatNud",
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
                        }
                        break;
                    case 3: // bool
                        {
                            CheckBox chbx = new CheckBox
                            {
                                Name = "CheckBox",
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
                    case 4: // felsorolas
                        {
                            TextBox txb = new TextBox
                            {
                                Name = "txbLista",
                                Parent = panel2,
                                Margin = szelek,
                                Top = top,
                                Left = left,
                                Size = new Size(elemHossza, 23),
                                Text = "-",
                                Visible = false
                            };
                            gbUjPozicio = txb.Top;
                            top = txb.Bottom;
                        }
                        break;
                }
                if (parameterek.Parameterek[i].ParameterMertekEgyseg.Length > 1)
                {
                    ComboBox meCbx = new ComboBox
                    {
                        Name = "meCbx",
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Parent = panel2,
                        Size = new Size(elemHossza, 23),
                        Margin = szelek,
                        Top = (parameterek.Parameterek[i].ParameterTipus == 4) ? lbl.Bottom + left : gbUjPozicio,
                        Left = (parameterek.Parameterek[i].ParameterTipus == 4) ? left : elemHossza + 20,
                        DataSource = parameterek.Parameterek[i].ParameterMertekEgyseg,
                    };
                }
                else
                {
                    Label meLbl = new Label
                    {
                        Name = "meLbl",
                        Parent = panel2,
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
                bool elozoVezerloCheckBoxVolt = false;
                string labelText = string.Empty;
                string ertekStr = "-";
                string meStr = "";
                int ParameterSorszam = 0;
                foreach (Control item in panel2.Controls)
                {
                    if (item is Label lbl)
                    {
                        if (elozoVezerloCheckBoxVolt)
                        {
                            meStr = labelText;
                        }
                        else
                        {
                            labelText = lbl.Text;
                        }
                    }
                    if ((item is TextBox txb))
                    {
                        if (!string.IsNullOrWhiteSpace(txb.Text))
                        {
                            ertekStr = txb.Text;
                            ParameterSorszam++;
                        }
                        else
                        {
                            MessageBox.Show($"A \"{labelText}\" paraméter nem lehet üres;", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else if (item is NumericUpDown nud)
                    {
                        ertekStr = nud.Value.ToString();
                        ParameterSorszam++;
                    }
                    else if (item is CheckBox chbx)
                    {
                        //meStr = labelText.TrimEnd(':');
                        ertekStr = (chbx.Checked) ? "Igen" : "Nem";
                        elozoVezerloCheckBoxVolt = true;
                        ParameterSorszam++;
                    }
                    if (item is ComboBox cbx && cbx.Name == "meCbx")
                    {
                        meStr = cbx.SelectedItem.ToString();
                    }
                    else if (item is Label meLbl && meLbl.Name == "meLbl")
                    {

                        if (elozoVezerloCheckBoxVolt)
                        {
                            meStr = labelText.TrimEnd(':');
                            elozoVezerloCheckBoxVolt = false;
                        }
                        else
                        {
                            meStr = meLbl.Text;
                        }
                        //meStr = meLbl.Text;
                    }
                    if (!string.IsNullOrEmpty(ertekStr) && !string.IsNullOrEmpty(meStr))
                    {
                        lista.Add(new AlkatreszParameter(ParameterSorszam, ertekStr, meStr.TrimEnd('\r')));
                        ertekStr = "-";
                        meStr = "";
                    }
                }
                return true;
            }
            return false;
        }
        private void DinamikusListaAdatFeltolt(List<AlkatreszParameter> parameterek)
        {
            if (parameterek.Count == 0 || panel2.Controls.Count == 0) return;
            int parameterSorszam = 0;

            foreach (Control item in panel2.Controls)
            {

                if (item is TextBox txb)
                {
                    if (txb.Name == "txb")
                    {
                        txb.Text = parameterek[parameterSorszam].ParameterErtek;
                    }
                    if (txb.Name == "txbLista")
                    {
                        txb.Text = parameterek[parameterSorszam].ParameterErtek;
                    }
                }
                if (item is NumericUpDown nud)
                {
                    if (nud.Name == "floatNud")
                    {
                        nud.Value = decimal.Parse(parameterek[parameterSorszam].ParameterErtek);
                    }
                    if (nud.Name == "intNud")
                    {
                        nud.Value = decimal.Parse(parameterek[parameterSorszam].ParameterErtek);
                    }
                }
                if (item is CheckBox checkbox)
                {
                    if (checkbox.Name == "CheckBox")
                    {
                        checkbox.Checked = (parameterek[parameterSorszam].ParameterErtek == "Igen") ? true : false;
                    }
                }
                if (item is ComboBox cbx)
                {
                    if (cbx.Name == "meCbx")
                    {
                        cbx.SelectedIndex = cbx.FindString(parameterek[parameterSorszam].ParameterMertekegyseg);
                        parameterSorszam++;
                    }
                }
                if (item is Label lbl)
                {
                    if (lbl.Name == "meLbl")
                    {
                        lbl.Text = parameterek[parameterSorszam].ParameterMertekegyseg;
                        parameterSorszam++;
                    }
                }
            }
        }
        #endregion

    }
}
