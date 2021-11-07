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
    public partial class ProjektFul : UserControl
    {
        public ProjektFul()
        {
            InitializeComponent();
        }

        private string projektNeve;
        private string projektLeiras;
        private Image prjIkon;

        [Category ("Projekt nev")]
        public string Megnevezes
        {
            get { return projektNeve; }
            set { projektNeve = value; prjNev.Text = value; }
        }
        [Category("Projekt leiras")]
        public string Leiras
        {
            get { return projektLeiras; }
            set { projektLeiras = value;
                prjLeiras.Text = value;
            }
        }
        [Category("Projekt ikon")]
        public Image Ikon
        {
            get { return prjIkon; }
            set { prjIkon = value;
                ikonBox.Image = value;
            }
        }

       
    }
}
