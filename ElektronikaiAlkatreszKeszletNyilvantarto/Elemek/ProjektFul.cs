using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EKNyilvantarto
{
    public partial class ProjektFul : UserControl
    {
        public event EventHandler Clicked;
        public event EventHandler BtnClick;

        private string projektNeve;
        private string projektLeiras;
        private string projektMegjegyzes;
        private bool aktivProjektFul = false;

        private Color hatterSzinEgerAlatt;
        private Color alapHatterSzin, aktivHatterSzin;
        #region Propertyk

        public bool AktivProjektFul { get => aktivProjektFul; set => aktivProjektFul = value; }

        [Category("Text")]
        public string Megnevezes
        {
            get { return projektNeve; }
            set { projektNeve = value; prjNev.Text = value; }
        }

        [Category("Text")]
        public string Leiras
        {
            get { return projektLeiras; }
            set
            {
                projektLeiras = value;
                prjLeiras.Text = value;
            }
        }

        [Category("Text")]
        public string Megjegyzes
        {
            get => projektMegjegyzes;
            set => projektMegjegyzes = value;
        }

        [Category("Szin")]
        public Color HatterSzinEgerAlatt
        {
            get { return hatterSzinEgerAlatt; }
            set { hatterSzinEgerAlatt = value; }
        }

        [Category("Szin")]
        public Color AlapHatterSzin
        {
            get { return alapHatterSzin; }
            set { alapHatterSzin = value; }
        }

        public Color AktivHatterSzin { get => aktivHatterSzin; set => aktivHatterSzin = value; }
        #endregion
        public ProjektFul()
        {
            BackColor = alapHatterSzin;
            InitializeComponent();

        }

        private void ProjektFul_MouseClick(object sender, MouseEventArgs e)
        {
            Clicked?.Invoke(this, EventArgs.Empty);
            BackColor = alapHatterSzin;
        }

        private void ProjektFul_MouseEnter(object sender, EventArgs e)
        {
            BackColor = hatterSzinEgerAlatt;
            if (!aktivProjektFul)
            {
                toolTip1.SetToolTip(this, projektLeiras + "\n\r" + projektMegjegyzes);
            }

        }

        private void ProjektFul_MouseLeave(object sender, EventArgs e)
        {
            if (aktivProjektFul)
            {
                BackColor = aktivHatterSzin;
            }
            else
            {
                BackColor = alapHatterSzin;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnClick?.Invoke(this, EventArgs.Empty);
        }

    }
}
