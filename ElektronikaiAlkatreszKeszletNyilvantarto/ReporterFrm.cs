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
        DataTable dt = new DataTable("Alkatresz");
        private void ProjektReport()
        {
          
            DataSet dataSet = new DataSet("Alkatresz");
            //dataSet.Tables.Add("Alkatresz", "Alkatresz");
            dt.Columns.Add("Megnevezes",typeof(string));
            dt.Columns.Add("Darab", typeof(string) );
            dt.Columns.Add("DarabAr", typeof(string));
            dt.Columns.Add("OsszAr", typeof(string));
            dt.Columns.Add("Parameterek", typeof(string));
            dt.Columns.Add("Kategoria", typeof(string));
            dt.Columns.Add("Megjegyzes", typeof(string));
            

            reportViewer1.LocalReport.ReportPath = @"Report/TesztReport2.rdlc";
             //ReportParameter rp = new ReportParameter();
             List<ReportParameter> parameterek = new List<ReportParameter>();
            parameterek.Add(new ReportParameter("ProjektNev",projekt.ProjektNev,true));
            parameterek.Add(new ReportParameter("ProjektLeiras", projekt.Leiras, true));
            parameterek.Add(new ReportParameter("ProjektMegjegyzes", projekt.Megjegyzes, true));
            DataRow sor;
            //projekt.AlkatreszLista.Sort();
            List<Keszlet> rendezettKezlet = projekt.AlkatreszLista.OrderBy(o => o.Alkatresz.Kategoria.KategoriaId).ToList();
            projekt.AlkatreszLista = rendezettKezlet;
              foreach (Keszlet alkatresz in projekt.AlkatreszLista)
              {
                  sor = dt.NewRow();
                  sor["Megnevezes"] = alkatresz.Alkatresz.Megnevezes;
                  sor["Darab"] = alkatresz.DarabSzam.ToString();
                  sor["DarabAr"] = alkatresz.DarabAr.ToString();
                  sor["OsszAr"] = alkatresz.AlkatreszOsszAR().ToString();
                  sor["Parameterek"] = alkatresz.Alkatresz.ToString();
                  sor["Kategoria"] =alkatresz.Alkatresz.Kategoria.ToString() ;
                  sor["Megjegyzes"] = alkatresz.Megjegyzes;
                dt.Rows.Add(sor);
                 
            }
            dataSet.Tables.Add(dt);
            foreach (Keszlet alkatresz in projekt.AlkatreszLista)
            {
                parameterek.Add(new ReportParameter("AlkatreszMegnevezes", alkatresz.Alkatresz.Megnevezes, true));
                parameterek.Add(new ReportParameter("AlkatreszDarabszam", alkatresz.DarabSzam.ToString(), true));
                parameterek.Add(new ReportParameter("AlkatreszDarabar", alkatresz.DarabAr.ToString(), true)); parameterek.Add(new ReportParameter("AlkatreszOsszar", alkatresz.AlkatreszOsszAR().ToString(), true));
                parameterek.Add(new ReportParameter("AlkatreszParameterek", alkatresz.Alkatresz.ToString(), true));
                parameterek.Add(new ReportParameter("Kategoria", alkatresz.Alkatresz.Kategoria.ToString(), true));
              //  parameterek.Add(new ReportParameter("AlkatreszMegjegyzes", alkatresz.Megjegyzes, true));
             
            }
           

            //dataSet.
            reportViewer1.LocalReport.SetParameters(parameterek);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet", dataSet.Tables[0]));
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
