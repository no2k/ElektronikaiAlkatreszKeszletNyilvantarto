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
        private Color hatterSzinMH;
        private Color hatterSzinMO;

        [Category("Projekt név")]
        public string Megnevezes
        {
            get { return projektNeve; }
            set { projektNeve = value; prjNev.Text = value; }
        }
        [Category("Projekt leirás")]
        public string Leiras
        {
            get { return projektLeiras; }
            set
            {
                projektLeiras = value;
                prjLeiras.Text = value;
            }
        }
        [Category("Projekt ikon")]
        public Image Ikon
        {
            get { return prjIkon; }
            set
            {
                prjIkon = value;
                ikonBox.Image = value;
            }
        }

        [Category("Háttérszín (egér fölé)")]
        public Color HatterSzinMH
        {
            get { return hatterSzinMH; }
            set { hatterSzinMH = value; }
        }

        [Category("Háttérszín (egér kívül)")]
        public Color HatterSzinMO
        {
            get { return hatterSzinMO; }
            set { hatterSzinMO = value; }
        }

        private void ProjektFul_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = hatterSzinMH;
        }

        private void ProjektFul_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = hatterSzinMO;
        }
    }
}
