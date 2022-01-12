using EKNyilvantarto.AlkatreszOsztalyok;
using ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections.Generic;
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

        ListViewItem.ListViewSubItem kivalasztottSubItem;
        bool hianyzik;
        //  Alkatresz alkatresz;
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

        private void ProjektekBetoltes()
        {

            projektek = ABKezelo.ProjektekLekerdez();
            foreach (Projekt item in projektek)
            {
                ProjektFul prj = new ProjektFul()
                {
                    Megnevezes = item.PrjNev,
                    Leiras = item.Leiras,
                    HatterSzinMO = prjInaktiv,
                    //HatterSzinMH = prjKivalaszt,
                    Anchor = AnchorStyles.Left
                };
                prj.Click += Prj_Click;
                projektPanel.Controls.Add(prj);
            }
            projektPanel.Refresh();
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
        private void projektLv_MouseUp(object sender, MouseEventArgs e)
        {
            /*https://stackoverflow-com.translate.goog/questions/471859/c-how-do-you-edit-items-and-subitems-in-a-listview?_x_tr_sl=en&_x_tr_tl=hu&_x_tr_hl=en  */

            ListViewHitTestInfo lVinfo = projektLV.HitTest(e.X, e.Y);

            kivalasztottSubItem = lVinfo.SubItem;
            // bool bennevan = kivalasztottSubItem.Text.ToString().EndsWith(" Db");
            if (kivalasztottSubItem == null)
            {
                return;
            }
            else
            {
                if (!kivalasztottSubItem.Text.ToString().EndsWith(" Db"))
                {
                    return;
                }
            }

            int keret = 0;
            switch (projektLV.BorderStyle)
            {
                case BorderStyle.None:
                    keret = 0;
                    break;
                case BorderStyle.FixedSingle:
                    keret = 1;
                    break;
                case BorderStyle.Fixed3D:
                    keret = 2;
                    break;
            }
            int cellaWidth = kivalasztottSubItem.Bounds.Width;
            int cellaHeight = kivalasztottSubItem.Bounds.Height;
            int balPozicio = keret + projektLV.Left + lVinfo.SubItem.Bounds.Left;
            int felsoPozicio = projektLV.Top + kivalasztottSubItem.Bounds.Top;

            if (lVinfo.SubItem == lVinfo.Item.SubItems[0])
            {
                cellaWidth = projektLV.Columns[0].Width;
            }

            int hossz = kivalasztottSubItem.Text.Length - 3;
            darabNud.Visible = true;
                        darabNud.Size = new Size(cellaWidth, cellaHeight);
            darabNud.Value = decimal.Parse(kivalasztottSubItem.Text.ToString().Remove(hossz));
            darabNud.Location = new Point(balPozicio, felsoPozicio);
            projektLV.Scrollable = false;
            darabNud.BringToFront();
            darabNud.Focus();
            darabNud.Select();
        }
        private void projektLv_MouseDown(object sender, MouseEventArgs e)
        {
            DarabNudElRejt();
        }
        private void projektLv_Scroll(object sender, EventArgs e)
        {
            DarabNudElRejt();
        }
        private void DarabNudElRejt()
        {
            darabNud.Visible = false;
            if (kivalasztottSubItem != null)
                kivalasztottSubItem.Text = darabNud.Value.ToString() + " Db";
            kivalasztottSubItem = null;
            projektLV.Scrollable = true ;
            // darabNud.Value = 0;
        }

        private void projektLv_Leave(object sender, EventArgs e)
        {
            DarabNudElRejt();
        }
        private void projektLv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                DarabNudElRejt();
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
                        // keszletListaFrissit();
                    }
                    else
                    {
                        MessageBox.Show("Az alkatrészeket nem lehetett betölteni, a felvitel után!", "Betöltési hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // keszletLbx.DataSource = alkatreszLista;

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
        private void projektTSMI_Click(object sender, EventArgs e)
        {
            UjProjektFrm frm = new UjProjektFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {

                projekt = frm.Projekt;
                projektek.Add(projekt);
                ABKezelo.UjProjekt(projekt);
                projektPanel.Refresh();
            }
        } //uj projekt
        private void Prj_Click(object sender, EventArgs e)
        {
            if ((sender is ProjektFul prj))
            {

                foreach (ProjektFul item in projektPanel.Controls)
                {
                    if (item != prj)
                    {
                        item.HatterSzinInaktiv = prjInaktiv;
                    }
                    else
                    {
                        //item.HatterSzinAktiv = prjAktiv;
                        item.HatterSzinMO = prjAktiv;
                    }
                }
                projektPanel.Refresh();
                foreach (Projekt item in projektek)
                {
                    if (item.PrjNev == prj.Megnevezes)
                    {
                        projekt = item;
                    }
                }
                //projekt.AlkatreszLista = new List<Keszlet>(projektek.FirstOrDefault(x => x.PrjNev == prj.Megnevezes).AlkatreszLista);
                ListaFrissit(projektLV, projekt.AlkatreszLista);
            }

        }
        private void projekthezAdBtn_Click(object sender, EventArgs e)
        {
            if ((keszletLV.SelectedItems) != null)
            {
                if (projekt == null)
                {
                    MessageBox.Show("Nincs kiválasztott Projekt!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
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
                                projekt.AlkatreszLista.Add(ujKeszlet);
                            }
                        }
                    }
                }
                ListaFrissit(projektLV, projekt.AlkatreszLista);
            }
        }

        #endregion

        #region Kategória metódusok

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
        #endregion
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

        private void darabNud_Leave(object sender, EventArgs e)
        {
            DarabNudElRejt();
        }

        private void KilepesTSMI_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
