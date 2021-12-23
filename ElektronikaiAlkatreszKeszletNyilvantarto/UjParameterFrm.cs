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
    public partial class UjParameterFrm : Form
    {
        #region Fieldek
        private int tipus;
        Kategoria kategoria;
        private Parameter parameter;
        private List<Parameter> lista=new List<Parameter>();
        private ParameterLista parameterLista;
        #endregion

        #region Propertyk
        public ParameterLista ParameterLista
        {
            get => parameterLista;
            private set
            {
                if (value != null)
                {
                    parameterLista = value;
                }
                else
                {
                    throw new ArgumentNullException("Az átadott paraméter lista üres!");
                }
            }
        }
        #endregion

        #region Konstruktorok
        public UjParameterFrm()
        {
            InitializeComponent();
        }
        public UjParameterFrm(Kategoria kategoria) 
        {
            InitializeComponent();
            if (kategoria!=null)
            {
                this.kategoria = kategoria;
                this.Text = $"Új {kategoria.KategoriaMegnevezes} paraméterek Hozzáadása";
                label1.Text = kategoria.KategoriaMegnevezes +" paraméterek";
                ParameterLista paramlista = ABKezelo.ParameterekLekerdez(kategoria);
                if (paramlista.Parameterek != null)
                {
                    throw new NotImplementedException("A paraméter lehívás nincs implementálva!");
                }
               
              /* foreach (Parameter item in paramlista)
                {
                    lista.Add(item);
                }*/
            }
        }
        #endregion

        #region Metódusok
       

        #endregion

      /*  private void button2_Click(object sender, EventArgs e)  //rögzÍt és bezár
        {
            if (parameterLista == null)
            {
                parameterLista = new ParameterLista(kategoria, lista);
            }
            else
            {
                parameterLista.UjParameter(parameter);
            }

        }*/

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str="";
            if (listBox1.SelectedItem is Parameter param)
            {
                MegnevezesTbx.Text = param.ParameterMegnevezes;
                foreach (string item in param.ParameterMertekEgyseg)
                {
                   str  = param.ParameterMertekEgyseg+Environment.NewLine;
                }
                MertekEgysegTxb.Text = str;
                switch (param.ParameterTipus)
                {
                    case 0: { radioButton1.Checked = true; } break;
                    case 1: { radioButton2.Checked = true; } break;
                    case 2: { radioButton3.Checked = true; } break;
                    case 3: { radioButton4.Checked = true; } break;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e) //Parameter hozzaadas (listboxba es listaba)
        {
            if (!string.IsNullOrWhiteSpace(MegnevezesTbx.Text) )
            {

                RadioButton radio = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                switch (radio.TabIndex)
                {
                    case 9:
                        { tipus = 0; }
                        break;
                    case 10:
                        { tipus = 1; }
                        break;
                    case 11:
                        { tipus = 2; }
                        break;
                    case 12:
                        { tipus = 3; }
                        break;
                }
                parameter = new Parameter(MegnevezesTbx.Text,MertekEgysegTxb.Text.Split('\n'), tipus);
                listBox1.Items.Add(parameter);
                lista.Add(parameter);
                MegnevezesTbx.Clear();
                MertekEgysegTxb.Clear();
            }
            else
            {
                MessageBox.Show("Minden mező kitöltése kötelező!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click_1(object sender, EventArgs e) //Rogzit es bezar
        {
            parameterLista = new ParameterLista(kategoria, lista);
            if (parameterLista!= null)
            {
                ABKezelo.UjParameterek(kategoria, parameterLista);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("A paraméter lista üres!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }

        
    }
}
