using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ElektronikaiAlkatreszKeszletNyilvantarto
{

    public partial class AlkatreszFelvitelFrm : Form
    {
        Alkatresz alkatresz;
        #region Fieldek
        private List<string> alKategoria;
        private List<string> foKategoria;
        #endregion

        #region Property
        public List<string> AlKategoria { get => alKategoria; set => alKategoria = value; }
        public List<string> FoKategoria { get => foKategoria; set => foKategoria = value; }

        #endregion

        #region Konstruktorok
        public AlkatreszFelvitelFrm()
        {
            InitializeComponent();
            AlKategoria = Fajlkezelo.StringFajlbolBeolvasas("alkategoria.txt");
            FoKategoria = Fajlkezelo.StringFajlbolBeolvasas("fokategoria.txt");
            comboBox3.DataSource = AlKategoria;
            comboBox1.DataSource = FoKategoria;
            szerelCbx.DataSource = Enum.GetValues(typeof(ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.Tokozas));
            alkatreszTipusCbx.DataSource = Enum.GetValues(typeof(ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek.AnyagTipus));
            mertekEgysegCbx.DataSource = Enum.GetValues(typeof(ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek.Mertekegyseg));
        }

        #endregion

        #region Metódusok

        void CBFrissit(string kategoria)
        {
            switch (kategoria)
            {
                case "alKategoria":
                    comboBox3.DataSource = null;
                    comboBox3.DataSource = AlKategoria;
                    break;
                case "foKategoria":
                    comboBox1.DataSource = null;
                    comboBox1.DataSource = FoKategoria;
                    break;
                default:
                    comboBox1.DataSource = null;
                    comboBox3.DataSource = null;
                    comboBox1.DataSource = AlKategoria;
                    comboBox3.DataSource = FoKategoria;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HozzaadKategoriaFrm frm = new HozzaadKategoriaFrm();
            frm.Text = "Új alkategória hozzáadása";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AlKategoria.Add(frm.Kategoria);
                CBFrissit("alKategoria");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HozzaadKategoriaFrm frm = new HozzaadKategoriaFrm();
            frm.Text = "Új főkategória hozzáadása";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                FoKategoria.Add(frm.Kategoria);
                CBFrissit("foKategoria");

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Fokategoria szelekcio
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        //groupBox2.Visible = false;
                        groupBox1.BringToFront();
                        groupBox1.Visible = true;
                    }
                    break;
                case 1:
                    {
                        groupBox1.Visible = false;
                        // groupBox2.BringToFront();
                        // groupBox2.Visible = true;
                    }
                    break;
            }
        }

        #endregion

        #endregion

        private void szerelRBtn1_CheckedChanged(object sender, EventArgs e)
        {
            szerelCbx.Enabled = false;
            numericUpDown4.Enabled = true;
        }
        //smd
        private void szerelRBtn2_CheckedChanged(object sender, EventArgs e)
        {
            szerelCbx.Enabled = true;
            numericUpDown4.Enabled = false;
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
    }

}
