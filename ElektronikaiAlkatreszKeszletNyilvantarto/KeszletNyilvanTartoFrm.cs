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
                    HatterSzinEgerAlatt = Color.LightSlateGray,
                    AlapHatterSzin = Color.FromArgb(50, 100, 100, 250),
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
        private void Prj_Clicked(object sender, EventArgs e)
        {
            if ((sender is ProjektFul prj))
            {
                foreach (Projekt item in projektek)
                {
                    if (item.ProjektNev == prj.Megnevezes)
                    {
                        prj.AlapHatterSzin = Color.LightSkyBlue;
                        projekt = item;
                        ABKezelo.ProjektAlkatreszLekerdez(projekt);
                    }
                    else
                    {
                        prj.AlapHatterSzin = Color.DeepSkyBlue;
                    }
                }
                ListaFrissit(projektLV, projekt.AlkatreszLista);
            }
        }
        private void projekthezAdBtn_Click(object sender, EventArgs e)
        {
            int kategoriaIndex = kategoriaTSCBX1.SelectedIndex;
            if (keszletLV.SelectedItems.Count == 0) return;
            if (projekt == null)
            {
                MessageBox.Show("Nincs kiválasztott Projekt!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            List<Keszlet> atrakniKivantAlkatreszek = new List<Keszlet>(ListViewElemekbolAlkatreszLista(keszletLV.SelectedItems, keszletLista));
            List<Keszlet> beallitani = DuplaAlkatreszSzeparator(atrakniKivantAlkatreszek, projekt.AlkatreszLista);
            DarabSzamBeallit(atrakniKivantAlkatreszek);
            if (atrakniKivantAlkatreszek.Count > 0)
            {
                ProjektAlkatreszDarabszamBeallit(beallitani);
                kategoriaTSCBX1.SelectedIndex = kategoriaIndex;
                kategoriaTSCBX1_SelectedIndexChange(this,EventArgs.Empty);
                //KategoriaFrissit();
                ListaFrissit(projektLV, projekt.AlkatreszLista);
                ListaFrissit(keszletLV, keszletLista);
            }
        }
        private void ProjektAlkatreszDarabszamBeallit(List<Keszlet> melyikAlkatreszeket)
        {
            Keszlet keresett;
            foreach (Keszlet projektAlkatresz in projekt.AlkatreszLista)
            {
                keresett = ABKezelo.KeszletKeres(projektAlkatresz.Alkatresz);
                if (melyikAlkatreszeket.Count != 0 && melyikAlkatreszeket.Contains(projektAlkatresz))
                {
                    foreach (Keszlet beallitando in melyikAlkatreszeket)
                    {
                        if (beallitando.Equals(projektAlkatresz))
                        {
                            if (beallitando.DarabSzam > projektAlkatresz.DarabSzam)
                            {
                                keresett.DarabSzam -= beallitando.DarabSzam - projektAlkatresz.DarabSzam;
                                projektAlkatresz.DarabSzam = beallitando.DarabSzam;
                                ABKezelo.KeszletModositas(keresett);
                                ABKezelo.ProjektAlkatreszModositas((int)projekt.ProjektAzonosito, projektAlkatresz);
                            }
                            else
                            {
                                keresett.DarabSzam += projektAlkatresz.DarabSzam - beallitando.DarabSzam;;
                                projektAlkatresz.DarabSzam = beallitando.DarabSzam;
                                ABKezelo.KeszletModositas(keresett);
                                ABKezelo.ProjektAlkatreszModositas((int)projekt.ProjektAzonosito, projektAlkatresz);
                            }
                        }
                    }
                }
                else
                {
                    ABKezelo.ProjektAlkatreszModositas((int)projekt.ProjektAzonosito, projektAlkatresz);
                    keresett.DarabSzam -= projektAlkatresz.DarabSzam;
                    ABKezelo.KeszletModositas(keresett);
                    ABKezelo.ProjektAlkatreszFelvitel((int)projekt.ProjektAzonosito, projektAlkatresz);
                }
            }
        }

        /// <summary>
        /// A metódus a forrás listából az elemeket a cél listához adja.
        /// Amennyiben duplikálció lép fel, akkor egy üzenetablak rákérdez, hogy akarod e módosítani a duplikált elemek darabszámát az új elemek hozzáadásakor (returns), vagy nem, ezesetben a forráslistából eltávolítja a duplikált elemeket.
        /// </summary>
        /// <param name="celLista">Cél lista, ahová az új alkatrészeket kell hozzáadni</param>
        /// <param name="forrasLista">A hozzáadni kívánt alkatrészek forrás listája</param>
        /// <returns>A duplikált elemek listája, amik már benne vannak a cél listában</returns>
        private List<Keszlet> DuplaAlkatreszSzeparator(List<Keszlet> forrasLista, List<Keszlet> celLista)
        {
            List<Keszlet> duplikalt = new List<Keszlet>();
            foreach (Keszlet item in forrasLista)
            {
                if (celLista.Contains(item))
                {
                    duplikalt.Add(item);
                }
                else
                {
                    celLista.Add(item);
                }
            }
            if (duplikalt.Count > 0 && MessageBox.Show("A kiválasztott alkatrészek közzül már van a listában!\n\rSzeretné azokat az alkatrészeket módosítani?\n\rAmennyiben a Nem-re kattint a duplikált elemeket kiveszem a listából!", "Figyelem duplikáció!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                foreach (Keszlet alkatresz in duplikalt)
                {
                    forrasLista.Remove(alkatresz);
                }
            }
            return duplikalt;
        }  //OK!

        private void DarabSzamBeallit(List<Keszlet> melyikAlkatreszListan, int maxDarabszam = 0)
        {
            if (melyikAlkatreszListan.Count == 0) return;
            AlkatreszDarabszamBeallitasFrm frm = new AlkatreszDarabszamBeallitasFrm(melyikAlkatreszListan, maxDarabszam);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                return;
            }
            melyikAlkatreszListan.Clear();

        } //OK!
        private List<Keszlet> ListViewElemekbolAlkatreszLista(ListView.SelectedListViewItemCollection kivalasztottElemek, List<Keszlet> melyikListabol)
        {
            List<Keszlet> kivalasztottAlkatreszek = new List<Keszlet>();
            foreach (ListViewItem item in kivalasztottElemek)
            {
                string parameterek = item.SubItems[6].Text;
                float darabSzam = float.Parse(item.SubItems[2].Text.Remove((item.SubItems[2].Text.Length - 3)));
                foreach (Keszlet alkatreszelem in melyikListabol)
                {
                    string str = alkatreszelem.Alkatresz.ToString();
                    if (str == parameterek /*&& alkatreszelem.DarabSzam > 0*/)
                    {
                        Keszlet ujKeszlet = new Keszlet(alkatreszelem.KeszletId, darabSzam, alkatreszelem.DarabAr, alkatreszelem.Megjegyzes, alkatreszelem.Alkatresz);
                        //    if (!projekt.AlkatreszLista.Contains(ujKeszlet))
                        {
                            kivalasztottAlkatreszek.Add(ujKeszlet);
                        }
                    }
                }
            }
            return kivalasztottAlkatreszek;
        }
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
            if (projektLV.SelectedItems != null)
            {
                ;
                AlkatreszDarabszamBeallitasFrm frm = new AlkatreszDarabszamBeallitasFrm(ListViewElemekbolAlkatreszLista(projektLV.SelectedItems, projekt.AlkatreszLista));
            }
        }
        private void prjAlkatreszModosit_Click(object sender, EventArgs e)
        {
            int kategoriaIndex = kategoriaTSCBX1.SelectedIndex;
            if (projektLV.SelectedItems.Count == 0) { return; }
            Keszlet keresett;
            List<Keszlet> modositandoAlkatreszek = ListViewElemekbolAlkatreszLista(projektLV.SelectedItems, projekt.AlkatreszLista);
            DarabSzamBeallit(modositandoAlkatreszek);
            foreach (Keszlet modositott in modositandoAlkatreszek)
            {
                keresett = ABKezelo.KeszletKeres(modositott.Alkatresz);
                foreach(Keszlet projektAlkatresz in projekt.AlkatreszLista)
                {
                    if (projektAlkatresz.Equals(modositott))
                    {
                        if (projektAlkatresz.DarabSzam < modositott.DarabSzam)
                        {
                            keresett.DarabSzam -= modositott.DarabSzam - projektAlkatresz.DarabSzam;
                            projektAlkatresz.DarabSzam += modositott.DarabSzam - projektAlkatresz.DarabSzam;
                        }
                        else
                        {
                            keresett.DarabSzam += projektAlkatresz.DarabSzam - modositott.DarabSzam;
                            projektAlkatresz.DarabSzam -= projektAlkatresz.DarabSzam - modositott.DarabSzam;
                        }
                        ABKezelo.ProjektAlkatreszModositas((int)projekt.ProjektAzonosito, projektAlkatresz);
                        ABKezelo.KeszletModositas(keresett);
                        if (keszletLista.Contains(projektAlkatresz))
                        {
                            kategoriaTSCBX1.SelectedIndex = kategoriaIndex;
                            kategoriaTSCBX1_SelectedIndexChange(this, EventArgs.Empty);
                        }
                    }
                }
            }
            ListaFrissit(keszletLV, keszletLista);
            ListaFrissit(projektLV, projekt.AlkatreszLista);
        }
        private void prjAlkatreszTorolBtn_Click(object sender, EventArgs e)
        {
            if (projektLV.SelectedItems.Count > 0 && MessageBox.Show("Biztos törölni akarod a kiválasztott alkatrészeket, a projekt alkatrész listájáról?", "Biztos törlöd?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int kategoriaIndex = kategoriaTSCBX1.SelectedIndex;
                Keszlet keresett;
                List<Keszlet> torlendoLista = ListViewElemekbolAlkatreszLista(projektLV.SelectedItems, projekt.AlkatreszLista);
                foreach (Keszlet alkatresz in torlendoLista)
                {
                    keresett = ABKezelo.KeszletKeres(alkatresz.Alkatresz);
                    keresett.DarabSzam += alkatresz.DarabSzam;
                    ABKezelo.KeszletModositas(keresett);
                    ABKezelo.ProjektAlkatreszTorles((int)projekt.ProjektAzonosito, (int)alkatresz.KeszletId);
                    projekt.AlkatreszLista.Remove(alkatresz);

                }
               
                    kategoriaTSCBX1.SelectedIndex = kategoriaIndex;
                    kategoriaTSCBX1_SelectedIndexChange(this, EventArgs.Empty);
                
                ListaFrissit(projektLV, projekt.AlkatreszLista);
                ListaFrissit(keszletLV, keszletLista);

            }
        }
        private void keszletAlkatreszModositBtn_Click(object sender, EventArgs e)
        {
            if (keszletLV.SelectedItems.Count==0) { return; }
            List<Keszlet> modositandoAlkatreszek = ListViewElemekbolAlkatreszLista(keszletLV.SelectedItems, keszletLista);
            DarabSzamBeallit(modositandoAlkatreszek, 2000);
            foreach (Keszlet eredeti in keszletLista)
            {
                foreach (Keszlet modositott in modositandoAlkatreszek)
                {
                    if (modositott.Alkatresz.Equals(eredeti.Alkatresz))
                    {
                        eredeti.DarabSzam = modositott.DarabSzam;

                        ABKezelo.KeszletModositas(eredeti);
                    }
                }
            }
            ListaFrissit(keszletLV, keszletLista);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AlkatreszTSMI_Click(this, EventArgs.Empty);
        }

        private void printTSMIBtn_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void keszletAlkatreszKeresTxb_TextChanged(object sender, EventArgs e)
        {
            if (keszletAlkatreszKeresTxb.Text.Length > 3)
            {
                keszletLista = ABKezelo.Kereses(keszletAlkatreszKeresTxb.Text);
                if (keszletLista.Count>0)
                {
                    ListaFrissit(keszletLV, keszletLista);
                }
               
            }
        }
    }

}
