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
        List<Alkatresz> alkatreszLista;

        internal List<Alkatresz> AlkatreszLista { get => alkatreszLista; set => alkatreszLista = value; }

        public AlkatreszKeszletFrm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AlkatreszFelvitelFrm frm = new AlkatreszFelvitelFrm();
            frm.Show();
        }

        private void AlkatreszKeszletFrm_Load(object sender, EventArgs e)
        {
            //InicializaciosOsztaly.AdatokBetoltese();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void AlkatreszTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                AlkatreszFelvitelFrm frm = new AlkatreszFelvitelFrm();
                if (frm.ShowDialog()==DialogResult.OK)
                {
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }   
}
