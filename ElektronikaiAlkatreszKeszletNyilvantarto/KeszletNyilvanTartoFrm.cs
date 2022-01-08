using System;
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
    public partial class AlkatreszKeszletFrm : Form
    {

        //  Alkatresz alkatresz;
        List<Keszlet> keszletLista = new List<Keszlet>();
        // List<Keszlet> projektAlkatreszLista = new List<Keszlet>();

        // internal List<Keszlet> AlkatreszLista { get => keszletLista; set => keszletLista = value; }

        public AlkatreszKeszletFrm()
        {
            AdatBazisCsatlakozas();
            InitializeComponent();
            LVFejlecekFeltoltes();
            KategoriaFrissit();
            //kategoriaTSCBX1_Click(null,null);
        }

        private void LVFejlecekFeltoltes()
        {
            keszletLV.Columns.Add("*", 30);
            keszletLV.Columns.Add("Kategória", 150);
            keszletLV.Columns.Add("Készlet", 50);
            keszletLV.Columns.Add("Darabár", 75);
            keszletLV.Columns.Add("Készlet ár", 300);
            keszletLV.Columns.Add("Megnevezés", 150);
            keszletLV.Columns.Add("Paraméterek", 300);
            keszletLV.Columns.Add("Megjegyzés", 300);

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
        void keszletListaFrissit()
        {

            keszletLV.Items.Clear();
            int i = 1;
            foreach (Keszlet item in keszletLista)
            {
                keszletLV.Items.Add(LVSorFeltolt(i, item));
                i++;
            }
        }
        private ListViewItem LVSorFeltolt(int sorszam, Keszlet item)
        {
            string parameterekString = "";
            foreach (AlkatreszParameter parameter in item.Alkatresz.Parameterek)
            {
                parameterekString += parameter + "; ";
            }
            string[] ujSor = new string[] { sorszam.ToString(), item.Alkatresz.Kategoria.KategoriaMegnevezes, item.DarabSzam.ToString() + " Db", item.DarabAr.ToString() + " Ft", item.AlkatreszOsszAR().ToString(), item.Alkatresz.Megnevezes, parameterekString, item.Megjegyzes };
            return new ListViewItem(ujSor);
        }
        void PRJAlkatreszListaFrissit()
        {
            //kiválasztott projekt frissítése
        }
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
                        //alkatreszLista = frm.AlkatreszLista;
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

        private void projektTSMI_Click(object sender, EventArgs e)
        {
            //ide kell egy pojekt osztály ami az alktrészeket fogja tárolni!!

            UjProjektFrm frm = new UjProjektFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ProjektFul prj = new ProjektFul();
                prj.Megnevezes = frm.ProjektNev;
                prj.Leiras = frm.ProjektLeiras;
                prj.HatterSzinMO = this.BackColor;
                prj.HatterSzinMH = Color.FromArgb(52, 105, 216, 75);
                splitContainer1.Panel2.Controls.Add(prj);


            }
        }
        private void projektFul1_MouseHover(object sender, EventArgs e)
        {
            projektFul1.HatterSzinMH = Color.LightGray;
            projektFul1.BorderStyle = BorderStyle.FixedSingle;
        }
        private void projektFul1_MouseLeave(object sender, EventArgs e)
        {
            projektFul1.HatterSzinMO = this.BackColor;
            projektFul1.BorderStyle = BorderStyle.None;
        }
        private void projektFul1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void projektFul1_MouseDown(object sender, MouseEventArgs e)
        {
            projektFul1.BorderStyle = BorderStyle.Fixed3D;
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

        private void kategoriaTSCBX1_SelectedIndexChange(object sender, EventArgs e)
        {
            Kategoria kat = kategoriaTSCBX1.SelectedItem as Kategoria;
            if (kat != null)
            {
                try
                {
                    keszletLista.Clear();
                    keszletLista = ABKezelo.KeszletLekerdezes(kat);
                    keszletListaFrissit();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba a kategória betötése közben!\n\r" + ex.Message, "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
