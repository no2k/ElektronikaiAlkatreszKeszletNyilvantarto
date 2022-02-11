using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EKNyilvantarto.AlkatreszOsztalyok;
using Microsoft.Reporting.WinForms;

namespace EKNyilvantarto
{
    internal partial class ReporterFrm : Form
    {
        #region Fieldek
        Projekt projekt;
        Keszlet keszlet;

        #endregion
        #region Propertyk

        internal Keszlet Keszlet { get => keszlet; set => keszlet = value; }
        internal Projekt Projekt {/* get => projekt;*/ set => projekt = value; }
        #endregion
        
        #region konstruktorok

        public ReporterFrm()
        {
            InitializeComponent();
        }

        public ReporterFrm(Projekt projekt): this()
        {
            Projekt = projekt;
            ProjektReport();
        }

        public ReporterFrm(Keszlet keszlet) : this()
        {
            Keszlet = keszlet;
            KeszletReport();
        }
        #endregion

        private void ProjektReport()
        {
            ReportDataSource forras = new ReportDataSource("ProjektData");
            forras.Value = null;
            reportViewer1.LocalReport.ReportPath = @"Report/TesztReport.rdlc";
            ReportParameter rp = new ReportParameter();
            rp.Name = "projektNev";
            rp.Values.Add(projekt.ProjektNev.ToString());
            rp.Visible = true;
            ReportParameter rp1 = new ReportParameter();
            rp1.Name = "leiras";
            rp1.Values.Add(projekt.Leiras.ToString());
            rp1.Visible = true;
            ReportParameter rp2 = new ReportParameter();
            rp2.Name = "megjegyzes";
            rp2.Values.Add(projekt.Megjegyzes.ToString());
            rp2.Visible = true;
            ReportParameter[] parameterek = new ReportParameter[] {rp,rp1,rp2};
            reportViewer1.LocalReport.SetParameters(parameterek);
            reportViewer1.RefreshReport();
        }


        private void KeszletReport()
        {
            throw new NotImplementedException();
        }

        private void ReporterFrm_Load(object sender, EventArgs e)
        {
         //   reportViewer1.RefreshReport();
        }
    }
}
