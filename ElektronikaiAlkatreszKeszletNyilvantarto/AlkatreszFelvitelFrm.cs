using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek;
using ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok;



namespace ElektronikaiAlkatreszKeszletNyilvantarto
{

    public partial class AlkatreszFelvitelFrm : Form
    {

        #region Fieldek
        List<Alkatresz> alkatreszLista = new List<Alkatresz>();
        Alkatresz alkatresz;
        List<string> kategoria;
        // private List<string> foKategoria;
        #endregion

        #region Property
        internal List<string> Kategoria { get => kategoria; set => kategoria = value; }
        internal List<Alkatresz> AlkatreszLista { get => alkatreszLista; set => alkatreszLista = value; }
        internal Alkatresz Alkatresz { get => alkatresz; set => alkatresz = value; }

        //  public List<string> FoKategoria { get => foKategoria; set => foKategoria = value; }

        #endregion

        #region Konstruktorok
        public AlkatreszFelvitelFrm()
        {
            InitializeComponent();
            Kategoria = Fajlkezelo.StringFajlbolBeolvasas("kategoria.txt");
            // FoKategoria = Fajlkezelo.StringFajlbolBeolvasas("fokategoria.txt");
            kategoriaCbx.DataSource = Kategoria;
            kategoriaCbx.SelectedIndex = 1;
            // comboBox1.DataSource = FoKategoria;
            //  szerelCbx.DataSource = Enum.GetValues(typeof(ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.Tokozas));
            tokozasCbx.DataSource = Enum.GetValues(typeof(ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.Tokozas));
        }

        #endregion

        #region Metódusok

        void LBFrissit()
        {
            listBox1.DataSource = null;
            if (AlkatreszLista != null)
            {
                listBox1.DataSource = AlkatreszLista;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Fokategoria szelekcio
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (kategoriaCbx.SelectedIndex)
            {
                case 0: //ellenallas
                    {
                        ellenallasGbx.Visible = true;
                        kondenzatorGbx.Visible = false;
                        induktivitasGbx.Visible = false;

                    }
                    break;
                case 1:  //kondi
                    {

                        kondenzatorGbx.Visible = true;
                        ellenallasGbx.Visible = false;
                        induktivitasGbx.Visible = false;
                    }
                    break;
                case 2:  //induktivitas
                    {

                        induktivitasGbx.Visible = true;
                        kondenzatorGbx.Visible = false;
                        ellenallasGbx.Visible = false;
                    }
                    break;
            }
        }

        #endregion

        #endregion

        private void szerelRBtn1_CheckedChanged(object sender, EventArgs e)
        {
            tokozasCbx.Enabled = false;
            raszterMeretNUD.Enabled = true;
        }
        //smd
        private void szerelRBtn2_CheckedChanged(object sender, EventArgs e)
        {
            tokozasCbx.Enabled = true;
            raszterMeretNUD.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (kategoriaCbx.SelectedIndex)
            {
                case 0:  //ellen
                    {
                        try
                        {
                            AlkatreszLista.Add(new Ellenallas(

                                kategoriaCbx.SelectedItem.ToString(),
                                (float)ellenallasErtekNUD.Value, 
                                (IndEllMertEgyseg)ellenallasMECbx.SelectedItem,
                                (float)ellTeljesNUD.Value,
                                (int)ellToleranciaNUD.Value, 
                                (Tokozas)tokozasCbx.SelectedItem, 
                                (int)raszterMeretNUD.Value,
                                megjegyzesTXB.Text,
                                (int)darabSzamNUD.Value, 
                                (int)darabArNUD.Value));
                            LBFrissit();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message,"Figyelem",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            
                        }
                    }
                    break;
                case 1:   //kondi
                    {
                        try
                        {
                            AlkatreszLista.Add(new Kondenzator(
                                (KondenzatorTipus)kondiTipusCbx.SelectedItem,
                                (float)kondiErtekNUD.Value,
                                (KondMertEgyseg)kondiMECbx.SelectedItem,
                                (float)kondiUzemFeszNUD.Value,
                                (Tokozas)tokozasCbx.SelectedItem,
                                (float)kondiTolearnciaNUD.Value,
                                (float)raszterMeretNUD.Value,
                                megjegyzesTXB.Text,
                                kategoriaCbx.SelectedItem.ToString(),
                                (int)darabSzamNUD.Value,
                                (int)darabArNUD.Value));
                            LBFrissit();

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    break;
                case 2:  //induk
                    {

                    }
                    break;

            }
        }
        #region CBXFeltoltes
        private void kondenzatorGbx_VisibleChanged(object sender, EventArgs e)
        {
            if (kondenzatorGbx.Visible)
            {
                kondiTipusCbx.DataSource = Enum.GetValues(typeof(ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek.KondenzatorTipus));
                kondiTipusCbx.SelectedIndex = 1;
                kondiMECbx.DataSource = Enum.GetValues(typeof(ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek.KondMertEgyseg));
                kondiMECbx.SelectedIndex = 1;
            }
        }

        private void ellenallasGbx_VisibleChanged(object sender, EventArgs e)
        {
            if (ellenallasGbx.Visible)
            {
                ellenallasMECbx.DataSource = Enum.GetValues(typeof(ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek.IndEllMertEgyseg));
                ellenallasMECbx.SelectedIndex = 1;
            }
        }

        private void induktivitasGbx_VisibleChanged(object sender, EventArgs e)
        {
            induktivMECbx.DataSource = Enum.GetValues(typeof(ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek.IndukciosMertekEgyseg));
            induktivMECbx.SelectedIndex = 1;
            induktivEllMECbx.DataSource = Enum.GetValues(typeof(ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek.IndEllMertEgyseg));
            induktivEllMECbx.SelectedIndex = 1;
        }

        #endregion

        private void tokozasCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tokozasCbx.SelectedIndex==0)
            {
                raszterMeretNUD.Enabled = true;
            }
            else
            {
                raszterMeretNUD.Enabled = false;
            }
        }
    }


}
