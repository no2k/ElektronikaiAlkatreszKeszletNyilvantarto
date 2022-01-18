using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EKNyilvantarto
{
    public partial class ProjektFul : UserControl
    {
        public event EventHandler Clicked;
        public ProjektFul()
        {
            InitializeComponent();
           
        }

        private string projektNeve;
        private string projektLeiras;
        private Image prjIkon;
       // private Color hatterSzinKijelolt;
        private Color hatterSzinEgerAlatt;
        private Color alapHatterSzin;

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

        [Category("Háttérszín(egér alatt)")]
        public Color HatterSzinEgerAlatt
        {
            get { return hatterSzinEgerAlatt; }
            set { hatterSzinEgerAlatt = value; }
        }

        [Category("Alap háttérszín")]
        public Color AlapHatterSzin
        {
            get { return alapHatterSzin; }
            set { alapHatterSzin = value; }
        }

       
        private void ProjektFul_MouseClick(object sender, MouseEventArgs e)
        {
            Clicked?.Invoke(this, EventArgs.Empty);
            BackColor = alapHatterSzin;
        }

        private void ProjektFul_MouseHover(object sender, EventArgs e)
        {
            BackColor = hatterSzinEgerAlatt;
            
        }

        private void ProjektFul_MouseLeave(object sender, EventArgs e)
        {
            BackColor = alapHatterSzin;
        }

        
    }
}
