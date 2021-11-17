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
 * CONNECTION STRING
 Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pejoc\source\repos\ElektronikaiAlkatreszKeszletNyilvantarto\ElektronikaiAlkatreszKeszletNyilvantarto\AlkatreszDB.mdf;Integrated Security=True
 */

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    public partial class AlkatreszKeszletFrm : Form
    {
        private string DBConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pejoc\source\repos\ElektronikaiAlkatreszKeszletNyilvantarto\ElektronikaiAlkatreszKeszletNyilvantarto\AlkatreszDB.mdf;Integrated Security=True";
        //  Alkatresz alkatresz;
        List<Alkatresz> alkatreszLista = new List<Alkatresz>();
        List<Alkatresz> projektAlkatreszLista = new List<Alkatresz>();

        internal List<Alkatresz> AlkatreszLista { get => alkatreszLista; set => alkatreszLista = value; }

        public AlkatreszKeszletFrm()
        {
            InitializeComponent();
            kategoriaTSCBX.ComboBox.DataSource = Enum.GetValues(typeof(Kategoria));
        }
        void ListaFrissit()
        {
            keszletLbx.DataSource = null;
            keszletLbx.DataSource = alkatreszLista;
        }
        private void AlkatreszKeszletFrm_Load(object sender, EventArgs e)
        {

        }

        private void AlkatreszTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                AlkatreszFelvitelFrm frm = new AlkatreszFelvitelFrm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.AlkatreszLista != null)
                    {
                        alkatreszLista = frm.AlkatreszLista;
                    }
                    else
                    {
                        MessageBox.Show("Az alkatrészeket nem lehetett betölteni, a felvitel után!", "Betöltési hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    keszletLbx.DataSource = alkatreszLista;

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void kategoriaTSCBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlkatreszLista != null)
            {
                switch (kategoriaTSCBX.SelectedIndex)
                {
                    case 0:
                        {
                            keszletLbx.Items.Clear();

                            foreach (Alkatresz item in alkatreszLista)
                            {
                                if (item is Ellenalas)
                                {
                                    keszletLbx.Items.Add(item);
                                }
                            }
                        }
                        break;
                    case 1:
                        {
                            foreach (Alkatresz item in alkatreszLista)
                            {
                                if (item is Kondenzator)
                                {
                                    keszletLbx.Items.Add(item);
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            foreach (Alkatresz item in alkatreszLista)
                            {
                                if (item is Induktivitas)
                                {
                                    keszletLbx.Items.Add(item);
                                }
                            }
                        }
                        break;
                }
            }
        }

        private void keszletLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (keszletLbx.SelectedItem != null)
            {
                infoTSMI.Text = keszletLbx.SelectedItem.ToString();
            }
        }

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
    }
}
