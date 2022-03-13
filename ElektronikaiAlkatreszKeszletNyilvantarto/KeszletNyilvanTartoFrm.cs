using EKNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EKNyilvantarto
{
    public partial class AlkatreszKeszletFrm : Form
    {
        int kategoriaKivalasztottIndex = 0;
        bool hianyzik, voltKereses;
        List<Keszlet> keszletLista = new List<Keszlet>();
        List<Projekt> projektek = new List<Projekt>();
        List<ProjektFul> projektFulLista = new List<ProjektFul>();
        Projekt projekt;
        LVRendez lvRendez;

        public AlkatreszKeszletFrm()
        {
            AdatBazisCsatlakozas();
            InitializeComponent();
            LVBeallitas();
            lvRendez = new LVRendez();
            keszletLV.ListViewItemSorter = lvRendez;
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
                Application.Exit();
            }
        } //OK!
        private void KategoriaFrissit()
        {
            kategoriaTSCBX1.ComboBox.DataSource = null;
            kategoriaTSCBX1.ComboBox.DataSource = ABKezelo.KategoriaLekerdezes();
        }   //OK!
        private void kategoriaTSCBX1_SelectedIndexChange(object sender, EventArgs e)
        {
            Kategoria kat = (Kategoria)kategoriaTSCBX1.SelectedItem;
            if (kat != null)
            {
                try
                {
                    if (keszletLista != null) keszletLista.Clear();
                    keszletLista = ABKezelo.KeszletLeker(kat);
                    kategoriaKivalasztottIndex = kategoriaTSCBX1.SelectedIndex;
                    ListaFrissit(keszletLV, keszletLista);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba a kategória betötése közben!\n\r" + ex.Message, "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #region ListView metódusok
        private void LVBeallitas()
        {
            keszletLV.MultiSelect = true;
            keszletLV.FullRowSelect = true;
            keszletLV.Columns.Add("*").Name = "Sorszam";
            keszletLV.Columns.Add("Kategória").Name = "Kategoria";
            keszletLV.Columns.Add("Készlet").Name = "Keszlet";
            keszletLV.Columns.Add("Darabár").Name = "DarabAr";
            keszletLV.Columns.Add("Készlet ár").Name = "KeszletAr";
            keszletLV.Columns.Add("Megnevezés").Name = "Megnevezes";
            keszletLV.Columns.Add("Paraméterek").Name = "Parameterek";
            keszletLV.Columns.Add("Megjegyzés").Name = "Megjegyzes";

            projektLV.Columns.Add("*").Name = "Sorszam";
            projektLV.Columns.Add("Kategória").Name = "Kategoria";
            projektLV.Columns.Add("Készlet").Name = "Keszlet";
            projektLV.Columns.Add("Darabár").Name = "DarabAr";
            projektLV.Columns.Add("Készlet ár").Name = "KeszletAr";
            projektLV.Columns.Add("Megnevezés").Name = "Megnevezes";
            projektLV.Columns.Add("Paraméterek").Name = "Parameterek";
            projektLV.Columns.Add("Megjegyzés").Name = "Megjegyzes";

            projektLV.MultiSelect = true;
            projektLV.FullRowSelect = true;

            LVFejlecMeretezes(keszletLV);
            LVFejlecMeretezes(projektLV);

        }
        private void LVFejlecMeretezes(ListView lv)
        {

            int x = lv.Width / 8 == 0 ? 1 : lv.Width / 8;
            lv.Columns[0].Width = x / 4;
            lv.Columns[1].Width = x;
            lv.Columns[2].Width = x / 2 + (x / 4);
            lv.Columns[3].Width = x / 2 + (x / 4);
            lv.Columns[4].Width = x / 2 + (x / 4);
            lv.Columns[5].Width = x;
            lv.Columns[6].Width = x * 2;
            lv.Columns[7].Width = x * 2;

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
        private void keszletLV_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            List<Keszlet> rendezettKezlet = new List<Keszlet>();
            rendezettKezlet.Clear();
            switch (e.Column)
            {
                case 0:
                    rendezettKezlet = keszletLista.OrderBy(o => o.KeszletId).ToList();
                    keszletLista = new List<Keszlet>(rendezettKezlet);
                    break;
                case 1:
                    rendezettKezlet = keszletLista.OrderBy(o => o.Alkatresz.Kategoria).ToList();
                    keszletLista = new List<Keszlet>(rendezettKezlet);
                    break;
                case 2:
                    rendezettKezlet = keszletLista.OrderBy(o => o.DarabSzam).ToList();
                    keszletLista = new List<Keszlet>(rendezettKezlet);
                    break;
                case 3:
                    rendezettKezlet = keszletLista.OrderBy(o => o.DarabAr).ToList();
                    keszletLista = new List<Keszlet>(rendezettKezlet);
                    break;
                case 4:
                    rendezettKezlet = keszletLista.OrderBy(o => o.AlkatreszOsszAR()).ToList();
                    keszletLista = new List<Keszlet>(rendezettKezlet);
                    break;
                case 5:
                    rendezettKezlet = keszletLista.OrderBy(o => o.Alkatresz.Megnevezes).ToList();
                    keszletLista = new List<Keszlet>(rendezettKezlet);
                    break;
                case 6:
                    rendezettKezlet = keszletLista.OrderBy(o => o.Alkatresz.ToString()).ToList();
                    keszletLista = new List<Keszlet>(rendezettKezlet);
                    break;
            }
            ListaFrissit(keszletLV, keszletLista);
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
            LVFejlecMeretezes(keszletLV);
            LVFejlecMeretezes(projektLV);
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
                DialogResult = DialogResult.None;
            }
        }
        private void ujAlkatreszTSBtn_Click(object sender, EventArgs e)
        {
            AlkatreszTSMI_Click(this, EventArgs.Empty);
        }
        #endregion

        #region "Projekt" metódusok
        private void ProjektekBetoltes()
        {
            projektek.Clear();
            projektek = ABKezelo.ProjektekLekerdez();
            ProjektFulFeltoltes(projektek);
        }
        private void ProjektFulFeltoltes(List<Projekt> projektlista)
        {
            projektFulLista.Clear();

            foreach (Projekt item in projektlista)
            {
                ProjektFul prj = new ProjektFul()
                {
                    Index = (int)item.ProjektAzonosito,
                    Width = 220,
                    Megnevezes = item.ProjektNev,
                    Leiras = item.Leiras,
                    Megjegyzes = item.Megjegyzes,
                    Anchor = AnchorStyles.Left,
                    BackColor = Color.LightSkyBlue,
                    AlapHatterSzin = Color.LightSkyBlue,
                    HatterSzinEgerAlatt = Color.DeepSkyBlue,
                    AktivHatterSzin = Color.DodgerBlue,
                };
                prj.Clicked += Prj_Clicked;
                prj.BtnClick += Prj_Button1_Click;
                projektFulLista.Add(prj);
            }
            List<ProjektFul> rendezett = new List<ProjektFul>(projektFulLista.OrderByDescending(x => x.Index));
            projektFulLista.Clear();
            projektFulLista = new List<ProjektFul>(rendezett);
            ProjektPanelFrissit();
        }
        void ProjektPanelFrissit()
        {
            projektPanel.Controls.Clear();
            projektPanel.Controls.AddRange(projektFulLista.ToArray());
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
                projektFulLista.ForEach(
                    elem =>
                    {
                        if (elem.Megnevezes == prj.Megnevezes)
                        {
                            elem.AktivProjektFul = true;
                            elem.HatterSzinEgerAlatt = Color.CornflowerBlue;
                        }
                        else
                        {
                            elem.AktivProjektFul = false;
                            elem.HatterSzinEgerAlatt = Color.DeepSkyBlue;
                        }
                    });
                ProjektPanelFrissit();

                foreach (Projekt item in projektek)
                {
                    if (item.ProjektNev == prj.Megnevezes)
                    {
                        projekt = item;
                        ABKezelo.ProjektAlkatreszLekerdez(projekt);
                        if (!projekt.LezartStatusz)
                        {
                            prjAlkatreszTorolBtn.Enabled = true;
                            prjAlkatreszModosit.Enabled = true;
                            projekthezAdBtn.Enabled = true;
                            projektLezarPrjPanelTSBtn.Image = global::EKNyilvantarto.Properties.Resources.Drop_Box_Folder_black_icon;
                            prjLezarPrjLVTSBtn.Image = projektLezarPrjPanelTSBtn.Image;
                        }
                        else
                        {
                            prjAlkatreszTorolBtn.Enabled = false;
                            prjAlkatreszModosit.Enabled = false;
                            projekthezAdBtn.Enabled = false;
                            projektLezarPrjPanelTSBtn.Image = global::EKNyilvantarto.Properties.Resources.Private_Folder_black_icon;
                            prjLezarPrjLVTSBtn.Image = projektLezarPrjPanelTSBtn.Image;
                        }
                    }
                }
                ListaFrissit(projektLV, projekt.AlkatreszLista);
            }
        } //OK
        private void Prj_Button1_Click(object sender, EventArgs e)
        {
            if (projekt == null) return;
            if (!projekt.LezartStatusz)
            {
                int projektIndex = projektek.IndexOf(projekt);
                int prjFulIndex = projektFulLista.IndexOf(
                    projektFulLista.First(
                        x => x.Megnevezes == projekt.ProjektNev
                        ));
                UjProjektFrm frm = new UjProjektFrm(projekt);
                frm.ShowDialog();
                ABKezelo.ProjektModositas(projekt);
                ProjektFulFeltoltes(projektek);
            }
            else
            {
                MessageBox.Show("A projekt lezárt státuszban nem mdosítható!\n\rA módosításhoz fel kell oldani a projektet!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void ProjekthezAdBtn_Click(object sender, EventArgs e)
        {
            int kategoriaIndex = kategoriaTSCBX1.SelectedIndex;
            if (keszletLV.SelectedItems.Count == 0) return;
            if (projekt == null)
            {
                MessageBox.Show("Nincs kiválasztott Projekt!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            List<Keszlet> alkatreszek;
            List<Keszlet> duplikaltak;
            alkatreszek = new List<Keszlet>(ListViewElemekbolAlkatreszLista(keszletLV.SelectedItems, keszletLista));
            duplikaltak = DuplaAlkatreszSzeparator(alkatreszek, projekt.AlkatreszLista);
            DarabSzamBeallit(alkatreszek);
            if (alkatreszek.Count > 0)
            {
                ProjektAlkatreszDarabszamBeallit(alkatreszek);
                ProjektAlkatreszDarabszamBeallit(duplikaltak);
                kategoriaTSCBX1.SelectedIndex = kategoriaIndex;
                kategoriaTSCBX1_SelectedIndexChange(this, EventArgs.Empty);
                ListaFrissit(projektLV, projekt.AlkatreszLista);
                ListaFrissit(keszletLV, keszletLista);
            }
        }  //OK
        private void ProjektAlkatreszDarabszamBeallit(List<Keszlet> melyikAlkatreszeket)
        {
            if (melyikAlkatreszeket.Count == 0) return;

            foreach (Keszlet alkatresz in melyikAlkatreszeket)
            {
                Keszlet keresett;
                keresett = ABKezelo.KeszletKeres(alkatresz.Alkatresz);
                if (projekt.AlkatreszLista.Contains(alkatresz))
                {
                    foreach (var prjAlkatresz in projekt.AlkatreszLista)
                    {
                        if (alkatresz.Equals(prjAlkatresz))
                        {
                            if (alkatresz.DarabSzam >= prjAlkatresz.DarabSzam)
                            {
                                keresett.DarabSzam -= alkatresz.DarabSzam - prjAlkatresz.DarabSzam;
                                prjAlkatresz.DarabSzam = alkatresz.DarabSzam;
                                ABKezelo.KeszletModositas(keresett);
                                ABKezelo.ProjektAlkatreszModositas((int)projekt.ProjektAzonosito, prjAlkatresz);
                            }
                            else
                            {
                                keresett.DarabSzam += prjAlkatresz.DarabSzam - alkatresz.DarabSzam; ;
                                prjAlkatresz.DarabSzam = alkatresz.DarabSzam;
                                ABKezelo.KeszletModositas(keresett);
                                ABKezelo.ProjektAlkatreszModositas((int)projekt.ProjektAzonosito, prjAlkatresz);
                            }
                        }
                    }
                }
                else
                {
                    keresett.DarabSzam -= alkatresz.DarabSzam;
                    ABKezelo.KeszletModositas(keresett);
                    ABKezelo.ProjektAlkatreszFelvitel((int)projekt.ProjektAzonosito, alkatresz);
                    projekt.AlkatreszLista.Add(alkatresz);
                }
            }
        } //OK
        private void ProjektLV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (projektLV.SelectedItems != null)
            {
                AlkatreszDarabszamBeallitasFrm frm = new AlkatreszDarabszamBeallitasFrm(ListViewElemekbolAlkatreszLista(projektLV.SelectedItems, projekt.AlkatreszLista));
            }
        } //OK
        private void PrjAlkatreszModosit_Click(object sender, EventArgs e)
        {
            int kategoriaIndex = kategoriaTSCBX1.SelectedIndex;
            if (projektLV.SelectedItems.Count == 0) { return; }
            Keszlet keresett;
            List<Keszlet> modositandoAlkatreszek = ListViewElemekbolAlkatreszLista(projektLV.SelectedItems, projekt.AlkatreszLista);
            DarabSzamBeallit(modositandoAlkatreszek, 100);
            foreach (Keszlet modositott in modositandoAlkatreszek)
            {
                keresett = ABKezelo.KeszletKeres(modositott.Alkatresz);
                foreach (Keszlet projektAlkatresz in projekt.AlkatreszLista)
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
        } //OK
        private void PrjAlkatreszTorolBtn_Click(object sender, EventArgs e)
        {
            if (projektLV.SelectedItems.Count > 0 && MessageBox.Show("Biztos törölni akarod a kiválasztott alkatrészeket, a projekt alkatrész listájáról?", "Biztos törlöd?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int kategoriaIndex = kategoriaTSCBX1.SelectedIndex;
                Keszlet keresett;
                List<Keszlet> torlendoLista = ListViewElemekbolAlkatreszLista(projektLV.SelectedItems, projekt.AlkatreszLista);

                AlkatreszVisszairasAdatbazisba(torlendoLista);

                kategoriaTSCBX1.SelectedIndex = kategoriaIndex;
                kategoriaTSCBX1_SelectedIndexChange(this, EventArgs.Empty);

                ListaFrissit(projektLV, projekt.AlkatreszLista);
                ListaFrissit(keszletLV, keszletLista);

            }
        } //OK
        private void AlkatreszVisszairasAdatbazisba(List<Keszlet> torlendoLista)
        {
            Keszlet keresett;
            foreach (Keszlet alkatresz in torlendoLista)
            {
                keresett = ABKezelo.KeszletKeres(alkatresz.Alkatresz);
                keresett.DarabSzam += alkatresz.DarabSzam;
                ABKezelo.KeszletModositas(keresett);
                ABKezelo.ProjektAlkatreszTorles((int)projekt.ProjektAzonosito, (int)alkatresz.KeszletId);
                //projekt.AlkatreszLista.Remove(alkatresz);
            }
            torlendoLista.Clear();
        }
        private List<Keszlet> DuplaAlkatreszSzeparator(List<Keszlet> forrasLista, List<Keszlet> referenciaLista)
        {
            List<Keszlet> duplikalt = new List<Keszlet>();
            foreach (Keszlet item in forrasLista)
            {
                if (referenciaLista.Contains(item))
                {
                    duplikalt.Add(item);
                }
            }
            if (duplikalt.Count > 0 && MessageBox.Show("A kiválasztott alkatrészek közzül már van a listában!\n\rSzeretné azokat az alkatrészeket módosítani?\n\rAmennyiben a Nem-re kattint a \"duplikált\" alkatrészeket kiveszem a listából!", "Figyelem duplikáció!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                foreach (Keszlet alkatresz in duplikalt)
                {
                    forrasLista.Remove(alkatresz);
                }
                duplikalt.Clear();
            }
            return duplikalt;
        }  //OK!
        private void DarabSzamBeallit(List<Keszlet> melyikAlkatreszListan, int maxDarab = 0)
        {
            if (melyikAlkatreszListan.Count == 0) return;
            AlkatreszDarabszamBeallitasFrm frm = new AlkatreszDarabszamBeallitasFrm(melyikAlkatreszListan, maxDarab);
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
        } //OK
        private void ProjektLezarTSBtn_Click(object sender, EventArgs e)
        {
            if (projekt == null) return;
            string msgSzoveg = projekt.LezartStatusz ?
                "Biztosan feloldod a lezárt projektet?\n\rA feloldás után lehetséges a módosítás.\n\rFigyelem!\n\rAz eddig elkészített valós projekt alkatrészei, a projekt módosításakor  eltérhetnek!!!"
                : "Biztosan be akarod zárni a pojektet?\n\rA lezárás után a projekt befejezettnek minősül.A további módosításra nincs lehetőség, csak a feloldáskor!!!";
            string msgFejlec = projekt.LezartStatusz ? "Projekt feloldása..." : "Projekt lezárása...";
            if (MessageBox.Show(msgSzoveg, msgFejlec, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (projekt.LezartStatusz)
                {
                    projekt.LezartStatusz = false;
                }
                else
                {
                    projekt.LezartStatusz = true; ;
                }
                ABKezelo.ProjektStatuszBeallit(projekt, projekt.LezartStatusz);
                ProjektekBetoltes();
            }


        } //OK
        private void projektTorolTSBtn_Click(object sender, EventArgs e)
        {
            if (projekt == null) return;
            if (MessageBox.Show($"Biztosan szeretnéd törölni a(z) \"{projekt}\" projektet?", "Biztosan törlöd?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ABKezelo.ProjektTorles(projekt);
                AlkatreszVisszairasAdatbazisba(projekt.AlkatreszLista);
                projektek.Remove(projekt);
                ProjektekBetoltes();
                kategoriaTSCBX1.SelectedIndex = kategoriaKivalasztottIndex;
                kategoriaTSCBX1_SelectedIndexChange(this, EventArgs.Empty);
            }
        }  //OK
        private void ProjektMasolBtn_Click(object sender, EventArgs e)
        {
            if (projekt != null)
            {
                Projekt masolat = projekt.MasolatKeszites();
                UjProjektFrm frm = new UjProjektFrm(masolat);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ABKezelo.UjProjekt(masolat);
                    projekt = null;
                    projekt = new Projekt(masolat.ProjektNev, masolat.Leiras, (int)masolat.ProjektAzonosito, new List<Keszlet>(), masolat.Megjegyzes, masolat.LezartStatusz);
                    AlkatreszDarabszamEllenorzes(masolat.AlkatreszLista);
                    ProjektAlkatreszDarabszamBeallit(masolat.AlkatreszLista);
                    ProjektekBetoltes();
                    kategoriaTSCBX1.SelectedIndex = kategoriaKivalasztottIndex;
                    KategoriaFrissit();
                    ListaFrissit(keszletLV, keszletLista);
                }
            }
        }
        private bool AlkatreszDarabszamEllenorzes(List<Keszlet> alkatreszLista)
        {
            List<Keszlet> hianyzoAlkatreszekListaja = new List<Keszlet>();

            foreach (Keszlet item in alkatreszLista)
            {
                Keszlet keresett = ABKezelo.KeszletKeres(item.Alkatresz);
                if (keresett.DarabSzam < item.DarabSzam)
                {
                    hianyzoAlkatreszekListaja.Add(item);
                }
            }
            if (hianyzoAlkatreszekListaja.Count == 0)
            {
                return true;
            }
            else
            {
                string listaElemek = string.Empty;
                foreach (Keszlet item in hianyzoAlkatreszekListaja)
                {
                    listaElemek += " - " + item.Alkatresz + "\r\n";
                    alkatreszLista.Remove(item);
                }
                MessageBox.Show($"Nem sikerül minden alkatrészt átrakni, mivel a készleten lévő alkatrészek némelyikének nincs elegendő darabszáma! \r\nA hiányos darabszámú alkatrészek nem kerülnek be a projektbe!\n\rA következő alkatrészeket nem sikerült átrakni darabszám hiánya miatt:\r\n" +
                    $"{listaElemek}", "Hiányzó alkatrészek", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        #endregion

        #region Keszlet Metódusok
        private void keszletAlkatreszModositBtn_Click(object sender, EventArgs e)
        {
            if (keszletLV.SelectedItems.Count == 0) { return; }
            List<Keszlet> modositandoAlkatreszek = ListViewElemekbolAlkatreszLista(keszletLV.SelectedItems, keszletLista);
            DarabSzamBeallit(modositandoAlkatreszek, 100);
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
        private void keszletAlkatreszKeresTxb_TextChanged(object sender, EventArgs e)
        {
            if (keszletAlkatreszKeresTxb.Text.Length > 0)
            {
                KeszletlistaFeltoltesGlobalisKeresessel(keszletAlkatreszKeresTxb.Text);
            }
            else
            {
                kategoriaTSCBX1_SelectedIndexChange(this, EventArgs.Empty);
            }

        }
        private void keszletAlkatreszKeresTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(keszletAlkatreszKeresTxb.Text))
            {
                KeszletlistaFeltoltesGlobalisKeresessel(keszletAlkatreszKeresTxb.Text);
            }
        }
        private void KeszletlistaFeltoltesGlobalisKeresessel(string keresendoSzoveg)
        {
            keszletLista.Clear();
            keszletLista = ABKezelo.GlobalisKereses(keresendoSzoveg);
            voltKereses = true;
            ListaFrissit(keszletLV, keszletLista);

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

        #region Report metódusok

        private void KategoriaReportTSMI_Click(object sender, EventArgs e)
        {
            if (kategoriaTSCBX1.SelectedItem == null) return;
            ReporterFrm frm = new ReporterFrm(keszletLista);
            frm.Show();
        }
        private void projektReportTSBtn_Click(object sender, EventArgs e)
        {
            if (projekt == null) return;
            ReporterFrm frm = new ReporterFrm(projekt);
            frm.Show();
        }
        private void LeltarReportTSMI_Click(object sender, EventArgs e)
        {
            List<Keszlet> teljesKeszlet = new List<Keszlet>();
            List<Kategoria> kategoriaLista = ABKezelo.KategoriaLekerdezes();

            foreach (Kategoria kategoria in kategoriaLista)
            {
                teljesKeszlet.AddRange(ABKezelo.KeszletLeker(kategoria));
            }
            ReporterFrm frm = new ReporterFrm(teljesKeszlet, true);
            frm.ShowDialog();
        }
        private void statisztikaTSMI_Click_1(object sender, EventArgs e)
        {
            Statisztika stat = new Statisztika();
            ReporterFrm frm = new ReporterFrm(stat);
            frm.ShowDialog();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            KategoriaReportTSMI_Click(sender, EventArgs.Empty);
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
        private void KilepesTSMI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlkatreszKeszletFrm_Resize(object sender, EventArgs e)
        {
            LVFejlecMeretezes(keszletLV);
            LVFejlecMeretezes(projektLV);
        }
    }


}
