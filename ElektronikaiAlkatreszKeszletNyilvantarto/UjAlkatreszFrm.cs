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
    public partial class UjAlkatreszFrm : Form
    {
        // ParameterLista lista;
        List<Alkatresz> alkatreszLista = new List<Alkatresz>();
        
        int valasztottKaterogiaIndex = 0;
        internal List<Alkatresz> AlkatreszLista { get => alkatreszLista; set => alkatreszLista = value; }

        public UjAlkatreszFrm()
        {
            InitializeComponent();
            parameterTSMI.Enabled = false;
            KategoriaFrissit();
        }

        private void KategoriaFrissit()
        {
            kategoriaCbx.SelectedIndexChanged -= KategoriaCbx_SelectedIndexChanged;
            kategoriaCbx.DataSource = null;
            kategoriaCbx.DataSource = ABKezelo.AktivKategoriaLekerdezes();
            kategoriaCbx.SelectedIndexChanged += KategoriaCbx_SelectedIndexChanged;
            if (kategoriaCbx.Items.Count > 0)
            {
                if (valasztottKaterogiaIndex > 0)
                {
                    kategoriaCbx.SelectedIndex = valasztottKaterogiaIndex;
                }
                else
                {
                    kategoriaCbx.SelectedIndex = 0;
                    KategoriaCbx_SelectedIndexChanged(this, null);
                }

            }
        } //ok

        private void ListaFrissit()
        {

        }
        private void KategoriaCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kategoriaCbx.SelectedItem != null)
            {
                parameterTSMI.Enabled = true;
                valasztottKaterogiaIndex = kategoriaCbx.SelectedIndex;
                VezerloFeltoltes((Kategoria)kategoriaCbx.SelectedItem);
            }
            else
            {
                parameterTSMI.Enabled = false;
                MessageBox.Show("Nincs kiválasztott kategória!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
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

        private void button5_Click(object sender, EventArgs e)  //Uj parameter
        {
            if (kategoriaCbx.SelectedItem != null)
            {

                UjParameterFrm frm = new UjParameterFrm((Kategoria)kategoriaCbx.SelectedItem);

                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    // kategoriaCbx.SelectedIndex = valasztottKaterogiaIndex;
                }
                KategoriaFrissit();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott kategória", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
        public void VezerloFeltoltes(Kategoria kategoria)
        {
            panel2.Controls.Clear();
            ParameterLista parameterek = ABKezelo.ParameterekLekerdez(kategoria);
            int elemHossza = 75;
            Padding szelek = new Padding(0, 5, 0, 10);
            int top = 3, left = 5;
            for (int i = 0; i < parameterek.Parameterek.Count; i++)
            {
                Label lbl = new Label
                {
                    Parent = panel2,
                    Margin = szelek,
                    Top = top+10,
                    Left = left,
                    AutoSize = true,
                    Text = parameterek.Parameterek[i].ParameterMegnevezes
                };
                top = lbl.Bottom + left;

                if (parameterek.Parameterek[i].ParameterMertekEgyseg.Length > 1)
                {
                    ComboBox cbx = new ComboBox
                    {
                        Parent = panel2,
                        Size = new Size(elemHossza, 23),
                        Margin = szelek,
                        Top = top,
                        Left = elemHossza+20,
                        DataSource = parameterek.Parameterek[i].ParameterMertekEgyseg,
                       // Font=new Font("Microsoft Sans Serif",9,)
                    };

                }
                else
                {
                    Label lbl1 = new Label
                    {
                        Parent = panel2,
                        // Margin = szelek,
                        Top = top+2,
                        Margin = szelek,
                        Left = elemHossza + 20,
                        AutoSize = true,
                        Text = parameterek.Parameterek[i].ParameterMertekEgyseg[0]
                    };
                }
                switch (parameterek.Parameterek[i].ParameterTipus)
                {
                    case 0: //string
                        {
                            TextBox txb = new TextBox
                            {
                                Parent = panel2,
                                Margin = szelek,
                                Top = top,
                                Left = left,
                                Size = new Size(label2.Width - (left * 2), 23),
                            };
                            top = txb.Bottom;

                        }
                        break;
                    case 1:  //int
                        {
                            NumericUpDown nud = new NumericUpDown
                            {
                                Parent = panel2,
                                Margin = szelek,
                                Size=new Size(elemHossza,23),
                                Top = top,
                                Left = left,
                                Increment = 1,
                                Minimum = -1000,
                                Maximum = 1000
                            };
                            top = nud.Bottom;
                           // elemHossza = nud.Height;
                        }
                        break;
                    case 2:  //float
                        {
                            NumericUpDown nud = new NumericUpDown
                            {
                                Parent = panel2,
                                Margin = szelek,
                                Top = top,
                                Left = left,
                                Size = new Size(elemHossza, 23),
                                Increment = 0.01m,
                                DecimalPlaces = 2,
                                Minimum = -1000,
                                Maximum = 1000
                            };
                            top = nud.Bottom;
                           // elemHossza = nud.Height;
                        }
                        break;
                    case 3: // bool
                        {
                            CheckBox chbx = new CheckBox
                            {
                                Parent = panel2,
                                Margin = szelek,
                                Top = top,
                                Left = left,
                                Text = null
                            };
                            top = chbx.Bottom;
                        }
                        break;
                }

            }

            // panel2.Controls.Add();

        }

        private void bezarTSMI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kategoriaTSMI_Click(object sender, EventArgs e)
        {
            UjKategoriaFrm katFrm = new UjKategoriaFrm();
            if (katFrm.ShowDialog() == DialogResult.OK)
            {
                Kategoria kat = katFrm.UjKategoria;
                try
                {
                    ABKezelo.UjKategoria(kat);
                }
                catch (ABKivetel ex)
                {
                    MessageBox.Show(ex.Message, "Adatbázis hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (katFrm.Parameterez)
                {
                    UjParameterFrm paramFrm = new UjParameterFrm((Kategoria)kat);
                    if (paramFrm.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
                KategoriaFrissit();
            }
        }

        private void parameterTSMI_Click(object sender, EventArgs e)
        {
            if (kategoriaCbx.SelectedItem != null)
            {
                UjParameterFrm frm = new UjParameterFrm((Kategoria)kategoriaCbx.SelectedItem);
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    // kategoriaCbx.SelectedIndex = valasztottKaterogiaIndex;
                }
                KategoriaFrissit();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott kategória", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       
    }
}
