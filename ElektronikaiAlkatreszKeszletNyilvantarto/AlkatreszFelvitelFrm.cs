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
    public partial class AlkatreszFelvitelFrm : Form
    {
        ParameterLista lista;
        List<Alkatresz> alkatreszLista = new List<Alkatresz>();
        Kategoria katerogia;
        internal List<Alkatresz> AlkatreszLista { get => alkatreszLista; set => alkatreszLista = value; }

        public AlkatreszFelvitelFrm()
        {
            InitializeComponent();

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

                    }
                    break;

                case 1:
                    {

                    }
                    break;

                case 2:
                    {

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


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
            }
            // bool van = alkatreszLista.Contains(alkatresz) ;

            //infoTSMI.Text = (van) ? "Van ilyen elem a listában" : "nincs még egy ilyen elem a listában";
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
            /* if (!alkatreszLista.Contains(alkatresz))
             {
                 alkatreszLista.Add(alkatresz);
                 infoTSMI.Text = "Alkatrész hozzáadva az alkatrész listához!";
             }
             else
             {
                 MessageBox.Show("Az alkatrész már a listában van!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }*/

            ListaFrissit();
        }

        private void TokozasCbx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)  //Uj parameter
        {
            if (kategoriaCbx.SelectedItem != null )
            {

                UjParameterFrm frm = new UjParameterFrm(katerogia);
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void button4_Click(object sender, EventArgs e) //Uj kategoria
        {
            UjKategoriaFrm katFrm = new UjKategoriaFrm();
            if (katFrm.ShowDialog() == DialogResult.OK)
            {
                Kategoria kat = new Kategoria(null, katFrm.Kategoria);
                try
                {
                    ABKezelo.UjKategoria(kat);
                }
                catch (ABKivetel ex)
                {
                    MessageBox.Show(ex.Message,"Adatbázis hiba!",MessageBoxButtons.OK,MessageBoxIcon.Error);                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
               
                if (katFrm.Parameterez)
                {
                    UjParameterFrm paramFrm = new UjParameterFrm((Kategoria)kat);
                    if (paramFrm.ShowDialog()==DialogResult.OK)
                    {

                    }
                }
            }
        }
    }
}
