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

/*
 * TODO: A listához adásnál az értékeket ellenőrizni kel! Dobj egy hibát!
 * 
 * */

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    public partial class AlkatreszFelvitelFrm : Form
    {
        Alkatresz alkatresz;
        List<Alkatresz> alkatreszLista = new List<Alkatresz>();

        internal List<Alkatresz> AlkatreszLista { get => alkatreszLista; set => alkatreszLista = value; }

        public AlkatreszFelvitelFrm()
        {
            InitializeComponent();
            SzelektorokFeltoltese();
        }

        private void SzelektorokFeltoltese()
        {
            kategoriaCbx.DataSource = Enum.GetValues(typeof(AlkatreszOsztalyok.Kategoria));
            kategoriaCbx.SelectedIndex = 0;
            tokozasCbx.DataSource = Enum.GetValues(typeof(AlkatreszOsztalyok.PasszivTokozas));

            induktivitasMertekCbx.DataSource = Enum.GetValues(typeof(AlkatreszOsztalyok.InduktivMertekEgyseg));
            induktivEllenallasMertekCbx.DataSource = Enum.GetValues(typeof(AlkatreszOsztalyok.InduktivEllenallasMertekegyseg));
            induktivAramMertekCbx.DataSource = Enum.GetValues(typeof(AlkatreszOsztalyok.InduktivUzemiAramMertekEgyseg));

            kondiTipusCbx.DataSource = Enum.GetValues(typeof(AlkatreszOsztalyok.KondenzatorTipus));
            kondiMertekEgysegCbx.DataSource = Enum.GetValues(typeof(AlkatreszOsztalyok.KapacitasMertekEgyseg));

            ellenallasMertekEgysegCbx.DataSource = Enum.GetValues(typeof(AlkatreszOsztalyok.EllenallasMertekEgyseg));
            ellenallasBox.Visible = true;
            kondenzatorBox.Visible = false;
            induktivBox.Visible = false;

        }

        private void ListaFrissit()
        {
            if (alkatreszLista != null)
            {
                listBox1.DataSource = null;
                listBox1.DataSource = alkatreszLista;
            }

        }
        private void KategoriaCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (kategoriaCbx.SelectedIndex)
            {
                case 0:
                    {
                        megnevezesTbx.Enabled = false;
                        megnevezesTbx.Text = kategoriaCbx.SelectedItem.ToString();
                        ellenallasBox.Visible = true;
                        kondenzatorBox.Visible = false;
                        induktivBox.Visible = false;
                    }
                    break;

                case 1:
                    {
                        megnevezesTbx.Enabled = false;
                        megnevezesTbx.Text = kategoriaCbx.SelectedItem.ToString();
                        ellenallasBox.Visible = false;
                        kondenzatorBox.Visible = true;
                        induktivBox.Visible = false;
                    }
                    break;

                case 2:
                    {
                        megnevezesTbx.Enabled = false;
                        megnevezesTbx.Text = kategoriaCbx.SelectedItem.ToString();
                        ellenallasBox.Visible = false;
                        kondenzatorBox.Visible = false;
                        induktivBox.Visible = true;
                    }
                    break;
            }
            megjegyzesTbx.Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch (kategoriaCbx.SelectedIndex)
            {
                case 0: //ellenallas
                    {

                        try
                        {
                            alkatresz = (new Ellenalas((float)ellenallasErtekNUD.Value,
                                                              (EllenallasMertekEgyseg)ellenallasMertekEgysegCbx.SelectedItem,
                                                              (float)ellenallasTeljesitmenyNUD.Value,
                                                              megnevezesTbx.Text,
                                                              (int)keszletNud.Value,
                                                              (int)darabArNud.Value,
                                                              (Kategoria)kategoriaCbx.SelectedItem,
                                                              (PasszivTokozas)tokozasCbx.SelectedItem,
                                                              (float)toleranciaNud.Value,
                                                              (float)raszterNUD.Value,
                                                              megjegyzesTbx.Text));


                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    break;

                case 1:  //kondi
                    {
                        try
                        {
                            alkatresz = (new Kondenzator((float)kapacitasErtekNUD.Value,
                                                                 (KapacitasMertekEgyseg)kondiMertekEgysegCbx.SelectedItem,
                                                                 (float)kondiFeszultsegNUD.Value,
                                                                 (KondenzatorTipus)kondiTipusCbx.SelectedItem,
                                                                 megnevezesTbx.Text, (int)keszletNud.Value,
                                                                 (int)darabArNud.Value,
                                                                 (Kategoria)kategoriaCbx.SelectedItem,
                                                                 (PasszivTokozas)tokozasCbx.SelectedItem,
                                                                 (float)toleranciaNud.Value,
                                                                 (float)raszterNUD.Value,
                                                                 megjegyzesTbx.Text));
                        }
                        catch (Exception ex)
                        {


                            MessageBox.Show(ex.Message, "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    break;

                case 2:   //induktiv
                    {
                        try
                        {
                            alkatresz = (new Induktivitas((float)induktivErtekNUD.Value,
                                                                  (float)induktivEllenallasNUD.Value,
                                                                  (float)induktivUzemiAramNUD.Value,
                                                                  (InduktivEllenallasMertekegyseg)induktivEllenallasMertekCbx.SelectedItem,
                                                                  (InduktivMertekEgyseg)induktivitasMertekCbx.SelectedItem,
                                                                  (InduktivUzemiAramMertekEgyseg)induktivAramMertekCbx.SelectedItem,
                                                                  megnevezesTbx.Text,
                                                                  (int)keszletNud.Value,
                                                                  (int)darabArNud.Value,
                                                                  (Kategoria)kategoriaCbx.SelectedItem,
                                                                  (PasszivTokozas)tokozasCbx.SelectedItem,
                                                                  (float)toleranciaNud.Value,
                                                                  (float)raszterNUD.Value,
                                                                  megjegyzesTbx.Text));

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
            }
            // bool van = alkatreszLista.Contains(alkatresz) ;

            //infoTSMI.Text = (van) ? "Van ilyen elem a listában" : "noncs még egy ilyen elem a listában";
            /* if (AlkatreszLista.Count() != 0)
             {

                 foreach (Alkatresz item in alkatreszLista)
                 {

                     if (!alkatresz.Equals(item))
                     {
                         alkatreszLista.Add(alkatresz);
                     }
                     else
                     {
                         MessageBox.Show("Az alkatrész már a listában van!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     }
                 }
             }
             else
             {
                 alkatreszLista.Add(alkatresz);
             }*/
            if (!alkatreszLista.Contains(alkatresz))
            {
                alkatreszLista.Add(alkatresz);
                infoTSMI.Text = "Alkatrész hozzáadva az alkatrész listához!";
            }
            else
            {
                MessageBox.Show("Az alkatrész már a listában van!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ListaFrissit();
        }

        private void TokozasCbx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kategoriaCbx.SelectedIndex < 3 && tokozasCbx.SelectedIndex != 0)
            {
                raszterNUD.Enabled = false;
                raszterNUD.Value = 0;
            }
            else
            {
                raszterNUD.Enabled = true;
            }
        }
    }
}
