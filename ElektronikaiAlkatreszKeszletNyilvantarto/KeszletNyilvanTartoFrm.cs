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


        ListViewItem.ListViewSubItem kivalasztottSubItem;
        bool hianyzik;
        //  Alkatresz alkatresz;
        List<Keszlet> keszletLista = new List<Keszlet>();
        List<Keszlet> projektAlkatreszLista = new List<Keszlet>();
        List<Projekt> projektek = new List<Projekt>();
        Projekt projekt;


        public AlkatreszKeszletFrm()
        {
            AdatBazisCsatlakozas();
            InitializeComponent();
            LVBeallitas();
            KategoriaFrissit();

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
            keszletLV.Columns.Add("*", 30);
            keszletLV.Columns.Add("Kategória", 150);
            keszletLV.Columns.Add("Készlet", 75);
            keszletLV.Columns.Add("Darabár", 75);
            keszletLV.Columns.Add("Készlet ár", 75);
            keszletLV.Columns.Add("Megnevezés", 150);
            keszletLV.Columns.Add("Paraméterek", 300);
            keszletLV.Columns.Add("Megjegyzés", 300);


            projektLV.Columns.Add("*", 30);
            projektLV.Columns.Add("Kategória", 150);
            projektLV.Columns.Add("Készlet", 75);
            projektLV.Columns.Add("Darabár", 75);
            projektLV.Columns.Add("Készlet ár", 75);
            projektLV.Columns.Add("Megnevezés", 150);
            projektLV.Columns.Add("Paraméterek", 300);
            projektLV.Columns.Add("Megjegyzés", 300);
            projektLV.MultiSelect = true;
            projektLV.FullRowSelect = true;

        }
        void ListaFrissit(ListView lv, List<Keszlet> alkatreszLista)
        {

            lv.Items.Clear();
            int i = 1;
            foreach (Keszlet item in alkatreszLista)
            {
                ListViewItem sor = new ListViewItem(i.ToString());
                if (hianyzik)
                {
                    if (item.DarabSzam > 0)
                    {
                        sor.SubItems.AddRange(lvSorFeltolt(i, item));
                        lv.Items.Add(sor);
                        i++;
                    }
                }
                else
                {
                    sor.SubItems.AddRange(lvSorFeltolt(i, item));
                    lv.Items.Add(sor);
                    i++;
                }
            }
        }
        private string[] lvSorFeltolt(int sorszam, Keszlet item)
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
            MessageBox.Show($"{lVinfo.SubItem.Text}\n\r");


            if (kivalasztottSubItem == null)
            {
                return;
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
            //nud beallitas

            darabNud.Visible = true;
            darabNud.Size = new Size(cellaWidth, cellaHeight);
            // darabNud.Size = kivalasztottSubItem.Bounds.Size;
            darabNud.Location = new Point(balPozicio, felsoPozicio);
            darabNud.BringToFront();
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

        /* private void projektLv_Leave(object sender, EventArgs e)
         {
             DarabNudElRejt();
         }*/
        /*  private void projektLv_KeyUp(object sender, KeyEventArgs e)
          {
              if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                  HideTextEditor();
          }*/
        private void DarabNudElRejt()
        {
            darabNud.Visible = false;
            if (kivalasztottSubItem != null)
                kivalasztottSubItem.Text = darabNud.Value.ToString();
            kivalasztottSubItem = null;
            darabNud.Value = 0;
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
        private void kategoriaTSCBX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*   private void keszletLbx_SelectedIndexChanged(object sender, EventArgs e)
           {
               if (keszletLbx.SelectedItem != null)
               {
                   infoTSMI.Text = keszletLbx.SelectedItem.ToString();
               }
           }*/
        #region "Projekt" metódusok
        private void projektTSMI_Click(object sender, EventArgs e)
        {

            UjProjektFrm frm = new UjProjektFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {

                projekt = frm.Projekt;
                projektek.Add(projekt);
                ProjektFul prj = new ProjektFul();
                prj.Megnevezes = projekt.PrjNev;
                prj.Leiras = projekt.Leiras;
                prj.HatterSzinMO = this.BackColor;
                prj.HatterSzinMH = Color.FromArgb(52, 105, 216, 75);
                prj.Click += Prj_Click;
                projektPanel.Controls.Add(prj);

                projektPanel.Refresh();
            }
        }
        private void Prj_Click(object sender, EventArgs e)
        {
            if ((sender is ProjektFul prj))
            {
                projektAlkatreszLista = new List<Keszlet>(projektek.FirstOrDefault(x => x.PrjNev == prj.Megnevezes).Lista);
            }

        }
        private void projekthezAdBtn_Click(object sender, EventArgs e)
        {
            if ((keszletLV.SelectedItems) != null)
            {
                foreach (ListViewItem item in keszletLV.SelectedItems)
                {
                    string parameterek = item.SubItems[6].Text;
                    foreach (Keszlet keszletElem in keszletLista)
                    {
                        string str = keszletElem.Alkatresz.ToString();
                        if (str == parameterek)
                        {
                            projektAlkatreszLista.Add(keszletElem);
                        }
                    }
                }
                ListaFrissit(projektLV, projektAlkatreszLista);
            }
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


        private void kategoriaTSCBX1_SelectedIndexChange(object sender, EventArgs e)
        {
            Kategoria kat = kategoriaTSCBX1.SelectedItem as Kategoria;
            if (kat != null)
            {
                try
                {
                    keszletLista.Clear();
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
            //ha a projekt be van töltve!!!
        }

        private void keszletLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (keszletLV.SelectedItems != null)
            {
                foreach (ListViewItem item in keszletLV.SelectedItems)
                {
                    NumericUpDown nud = new NumericUpDown();
                    // item.SubItems.Add(nud)
                }
            }
        }
    }
}
