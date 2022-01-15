using EKNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EKNyilvantarto
{
    public partial class AlkatreszKeszletFrm : Form
    {


        Color prjAktiv = Color.FromArgb(14, 155, 155);
        Color prjInaktiv = Color.FromArgb(112, 118, 155);
        Color prjKivalaszt = Color.FromArgb(0, 212, 167);


        bool hianyzik;

        List<Keszlet> keszletLista = new List<Keszlet>();


        List<Projekt> projektek = new List<Projekt>();
        Projekt projekt;


        public AlkatreszKeszletFrm()
        {
            AdatBazisCsatlakozas();
            InitializeComponent();
            LVBeallitas();
            KategoriaFrissit();
            ProjektekBetoltes();

        }


        private void AdatBazisCsatlakozas()
        {
            try
            {
                ABKezelo.Csatlakozas();

            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Csatlakozási hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //OK!
        private void KategoriaFrissit()
        {
            kategoriaTSCBX1.ComboBox.DataSource = null;
            kategoriaTSCBX1.ComboBox.DataSource = ABKezelo.AktivKategoriaLekerdezes();
        }   //OK!

        #region ListView metódusok
        private void LVBeallitas()
        {
            keszletLV.MultiSelect = true;
            keszletLV.FullRowSelect = true;
            keszletLV.Columns.Add("*", 30).Name = "Sorszam";
            keszletLV.Columns.Add("Kategória", 150).Name = "Kategoria";
            keszletLV.Columns.Add("Készlet", 75).Name = "Keszlet";
            keszletLV.Columns.Add("Darabár", 75).Name = "DarabAr";
            keszletLV.Columns.Add("Készlet ár", 75).Name = "KeszletAr";
            keszletLV.Columns.Add("Megnevezés", 150).Name = "Megnevezes";
            keszletLV.Columns.Add("Paraméterek", 300).Name = "Parameterek";
            keszletLV.Columns.Add("Megjegyzés", 300).Name = "Megjegyzes";


            projektLV.Columns.Add("*", 30).Name = "Sorszam";
            projektLV.Columns.Add("Kategória", 150).Name = "Kategoria";
            projektLV.Columns.Add("Készlet", 75).Name = "Keszlet";
            projektLV.Columns.Add("Darabár", 75).Name = "DarabAr";
            projektLV.Columns.Add("Készlet ár", 75).Name = "KeszletAr";
            projektLV.Columns.Add("Megnevezés", 150).Name = "Megnevezes";
            projektLV.Columns.Add("Paraméterek", 300).Name = "Parameterek";
            projektLV.Columns.Add("Megjegyzés", 300).Name = "Megjegyzes";
            projektLV.MultiSelect = true;
            projektLV.FullRowSelect = true;

        }
        void ListaFrissit(ListView lv, List<Keszlet> alkatreszLista)
        {
            lv.Items.Clear();
            int i = 1;
            foreach (Keszlet item in alkatreszLista)
            {
                Color BetuSzin = new Color();
                Color Hatterszin = new Color();
                ListViewItem sor = new ListViewItem(i.ToString());
                if (item.DarabSzam <= 5 && lv == keszletLV)
                {
                    sor.UseItemStyleForSubItems = false;
                    int G = (int)(5 + (50 * item.DarabSzam));
                    Hatterszin = Color.FromArgb(255, G, 0);
                    BetuSzin = (G < 84) ? Color.FromArgb(255, 255, 255) : Color.FromArgb(0, 0, 0);
                }
                if (hianyzik)
                {
                    if (item.DarabSzam > 0)
                    {
                        sor.SubItems.AddRange(LvSorFeltolt(item), BetuSzin, Hatterszin, default);
                        lv.Items.Add(sor);
                        i++;
                    }
                }
                else
                {
                    sor.SubItems.AddRange(LvSorFeltolt(item), BetuSzin, Hatterszin, default);
                    lv.Items.Add(sor);
                    i++;
                }
            }
        }
        private string[] LvSorFeltolt(Keszlet item)
        {
            return new string[] {
            item.Alkatresz.Kategoria.KategoriaMegnevezes,
            item.DarabSzam.ToString() + " Db",
            item.DarabAr.ToString() + " Ft",
            item.AlkatreszOsszAR().ToString() + " Ft",
            item.Alkatresz.Megnevezes,
            item.Alkatresz.ToString(),
            item.Megjegyzes};
        }
        #endregion

        #region "Alkatrész" metódusok
        private void AlkatreszKeszletFrm_Load(object sender, EventArgs e)
        {
            try
            {
                ABKezelo.Csatlakozas();
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Csatlakozási hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*  finally
              {
                  ABKezelo.KapcsolatBontas();
              }*/
        }
        private void AlkatreszTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                UjAlkatreszFrm frm = new UjAlkatreszFrm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.KeszletLista != null)
                    {
                        keszletLista = frm.KeszletLista;
                        KategoriaFrissit();

                    }
                    else
                    {
                        MessageBox.Show("Az alkatrészeket nem lehetett betölteni, a felvitel után!", "Betöltési hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            hianyzik = !hianyzik;
            ListaFrissit(keszletLV, keszletLista);
        }
        private void toolStripButton7_MouseUp(object sender, MouseEventArgs e)
        {
            if (hianyzik)
            {
                toolStripButton7.Image = global::EKNyilvantarto.Properties.Resources.power_button2;
            }
            else
            {
                toolStripButton7.Image = global::EKNyilvantarto.Properties.Resources.power_button1;
            }
        }
        private void toolStripButton7_MouseDown(object sender, MouseEventArgs e)
        {
            toolStripButton7.Image = global::EKNyilvantarto.Properties.Resources.power_button3;
        }
        #endregion


        #region "Projekt" metódusok
        private void ProjektekBetoltes()
        {

            projektek = ABKezelo.ProjektekLekerdez();
            projektPanel.Controls.Clear();
            foreach (Projekt item in projektek)
            {
                ProjektFul prj = new ProjektFul()
                {
                    Megnevezes = item.ProjektNev,
                    Leiras = item.Leiras,
                    HatterSzinMO = prjInaktiv,
                    //HatterSzinMH = prjKivalaszt,
                    Anchor = AnchorStyles.Left
                };
                prj.Clicked += Prj_Clicked;
                //prj.Click += Prj_Click;
                projektPanel.Controls.Add(prj);
            }
            projektPanel.Refresh();
        }


        private void UjProjektTSMI_Click(object sender, EventArgs e)
        {
            UjProjektFrm frm = new UjProjektFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ABKezelo.UjProjekt(frm.Projekt);
                ProjektekBetoltes();
            }
        }  //OK!
        //private void Prj_Click(object sender, EventArgs e)
        private void Prj_Clicked(object sender, EventArgs e)
        {
            if ((sender is ProjektFul prj))
            {
                
                foreach (Projekt item in projektek)
                {
                    if (item.ProjektNev == prj.Megnevezes)
                    {
                        prj.HatterSzinAktiv = prjKivalaszt;
                        projekt = item;
                        ABKezelo.ProjektAlkatreszLekerdez(projekt);

                    }
                    else
                    {
                        prj.HatterSzinInaktiv = prjInaktiv;
                    }

                }

                ListaFrissit(projektLV, projekt.AlkatreszLista);
            }

        }
        private void projekthezAdBtn_Click(object sender, EventArgs e)
        {
            if (keszletLV.SelectedItems == null) return;
            if (projekt == null)
            {
                MessageBox.Show("Nincs kiválasztott Projekt!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

           /* List<Keszlet> kivalasztottAlkatreszek = new List<Keszlet>();
            foreach (ListViewItem item in keszletLV.SelectedItems)
            {
                string parameterek = item.SubItems[6].Text;
                foreach (Keszlet keszletElem in keszletLista)
                {
                    string str = keszletElem.Alkatresz.ToString();
                    if (str == parameterek && keszletElem.DarabSzam > 0)
                    {
                        Keszlet ujKeszlet = new Keszlet(keszletElem.KeszletId, 1, keszletElem.DarabAr, keszletElem.Megjegyzes, keszletElem.Alkatresz);
                        if (!projekt.AlkatreszLista.Contains(ujKeszlet))
                        {
                            kivalasztottAlkatreszek.Add(ujKeszlet);
                        }
                    }
                }
            }*/

            DarabSzamBeallit(ListViewElemekbolAlkatreszLista(keszletLV.SelectedItems,keszletLista));
            ListaFrissit(projektLV, projekt.AlkatreszLista);
        }

        private void DarabSzamBeallit(List<Keszlet> alkatreszLista)
        {
            AlkatreszDarabszamBeallitasFrm frm = new AlkatreszDarabszamBeallitasFrm(alkatreszLista);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (Keszlet beallitottAlkatresz in frm.Alkatreszek)
                {
                    if (!projekt.AlkatreszLista.Contains(beallitottAlkatresz))
                    {
                        projekt.AlkatreszLista.Add(beallitottAlkatresz);
                    }
                }
                ABKezelo.ProjektAlkatreszFelvitel(projekt);
            }
        } //OK!
        #endregion
        private void kategoriaTSCBX1_SelectedIndexChange(object sender, EventArgs e)
        {
            Kategoria kat = kategoriaTSCBX1.SelectedItem as Kategoria;
            if (kat != null)
            {
                try
                {
                    if (keszletLista != null) keszletLista.Clear();
                    keszletLista = ABKezelo.KeszletLeker(kat);
                    ListaFrissit(keszletLV, keszletLista);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba a kategória betötése közben!\n\r" + ex.Message, "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void kategoriaTSCBX2_Click(object sender, EventArgs e)
        {

        }
        private void AlkatreszKeszletFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ABKezelo.KapcsolatBontas();
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Kapcsolat bontási hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void KilepesTSMI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void projektLV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (projektLV.SelectedItems!=null)
            {
                ;
                AlkatreszDarabszamBeallitasFrm frm = new AlkatreszDarabszamBeallitasFrm(ListViewElemekbolAlkatreszLista(projektLV.SelectedItems,projekt.AlkatreszLista));
            }
        }

        private List<Keszlet> ListViewElemekbolAlkatreszLista(ListView.SelectedListViewItemCollection kivalasztottElemek,List<Keszlet> alkatreszLista)
        {
            List<Keszlet> kivalasztottAlkatreszek = new List<Keszlet>();
            foreach (ListViewItem item in kivalasztottElemek)
            {
                string parameterek = item.SubItems[6].Text;
                foreach (Keszlet alkatreszelem in alkatreszLista)
                {
                    string str = alkatreszelem.Alkatresz.ToString();
                    if (str == parameterek && alkatreszelem.DarabSzam > 0)
                    {
                        Keszlet ujKeszlet = new Keszlet(alkatreszelem.KeszletId, 1, alkatreszelem.DarabAr, alkatreszelem.Megjegyzes, alkatreszelem.Alkatresz);
                        if (!projekt.AlkatreszLista.Contains(ujKeszlet))
                        {
                            kivalasztottAlkatreszek.Add(ujKeszlet);
                        }
                    }
                }
            }
            return kivalasztottAlkatreszek;
        }
    }
}
