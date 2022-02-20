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
        List<Keszlet> keszletLista;
        private Statisztika stat;

        DataTable dt;

        #endregion

        #region Propertyk

        internal Keszlet Keszlet { get => keszlet; set => keszlet = value; }
        internal Projekt Projekt {/* get => projekt;*/ set => projekt = value; }
        public List<Keszlet> KeszletLista { get => keszletLista; set => keszletLista = value; }
        #endregion

        #region konstruktorok

        public ReporterFrm()
        {
            InitializeComponent();
        }

        public ReporterFrm(Projekt projekt) : this()
        {
            Projekt = projekt;
            Text = "Nyomtatási riport: " + projekt.ProjektNev;
            ProjektReport();
        }

        public ReporterFrm(List<Keszlet> keszletLista, bool leltar = false) : this()
        {
            KeszletLista = keszletLista;
            if (leltar)
            {
                Text = "Leltár riport ";
                LeltarReport();
            }
            else
            {
                Text = "Nyomtatási riport ";
                KeszletReport();
            }

        }

        private void LeltarReport()
        {
            reportViewer1.LocalReport.ReportPath = @"Report/LeltarReport.rdlc";
            dt = new DataTable("Alkatresz");
            dt.Clear();

            DataSet dataSet = new DataSet("Alkatresz");

            dt.Columns.Add("Megnevezes", typeof(string));
            dt.Columns.Add("Darab", typeof(string));
            dt.Columns.Add("DarabAr", typeof(string));
            dt.Columns.Add("OsszAr", typeof(string));
            dt.Columns.Add("Parameterek", typeof(string));
            dt.Columns.Add("Kategoria", typeof(string));
            dt.Columns.Add("Megjegyzes", typeof(string));
            DataRow sor;
            foreach (Keszlet alkatresz in keszletLista)
            {
                sor = dt.NewRow();
                sor["Megnevezes"] = alkatresz.Alkatresz.Megnevezes;
                sor["Darab"] = alkatresz.DarabSzam.ToString();
                sor["DarabAr"] = alkatresz.DarabAr.ToString();
                sor["OsszAr"] = alkatresz.AlkatreszOsszAR().ToString();
                sor["Parameterek"] = alkatresz.Alkatresz.ToString();
                sor["Kategoria"] = alkatresz.Alkatresz.Kategoria.ToString();
                sor["Megjegyzes"] = alkatresz.Megjegyzes;
                dt.Rows.Add(sor);
            }
            dataSet.Tables.Add(dt);

            int kategoriaId = (int)keszletLista[0].Alkatresz.Kategoria.KategoriaId;

            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(
                new ReportParameter(
                    "KategoriakSzama",
                    ABKezelo.KategoriakSzamanakLekerdezese().ToString(),
                    true));
            rpc.Add(
                new ReportParameter(
                    "AlkatreszekSzama",
                    ABKezelo.AlkatreszekSzama().ToString(),
                    true));
            rpc.Add(
                new ReportParameter(
                    "AlkatreszOsszDarabSzam",
                    ABKezelo.OsszesAlkatreszKeszletenLevoDarabszama().ToString(),
                    true));
           
            reportViewer1.LocalReport.SetParameters(rpc);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet", dataSet.Tables["Alkatresz"]));
            reportViewer1.RefreshReport();
        }

        public ReporterFrm(Statisztika stat) : this()
        {
            Text = "Statisztikai adatok";
            this.stat = stat;
            StatReport();
        }

        /// <summary>
        /// Statisztikai report megjelenítéséhez szolgáló adatok összeállítása, a ReportViewer és ezáltal a Statisztika.rdlc report fájl adatainak feltöltését végzi el.
        /// </summary>
        private void StatReport()
        {
            reportViewer1.Clear();
            reportViewer1.LocalReport.ReportPath = @"Report/Statisztika.rdlc";
            DataSet dataSet = new DataSet("StatisztikaDS");
            dt = new DataTable("StatisztikaDS");
            dt.Clear();
            dt.Columns.Add("Megnevezes", typeof(string));
            dt.Columns.Add("AlkatreszekSzama", typeof(int));
            dt.Columns.Add("AlkatreszOsszDarabSzam", typeof(float));
            dt.Columns.Add("OsszErtek", typeof(float));
            DataRow sor;
            foreach (KategoriaAdatTarolo adatok in stat.KategoriaAdatok)
            {
                sor = dt.NewRow();
                sor["Megnevezes"] = adatok.Megnevez;
                sor["AlkatreszekSzama"] = adatok.AlkatreszekSzama;
                sor["AlkatreszOsszDarabSzam"] = adatok.DarabSzam;
                sor["OsszErtek"] = adatok.Osszertek;
                dt.Rows.Add(sor);
            }
            dataSet.Tables.Add(dt);
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("OsszAlkatreszSzam", stat.OsszAlkatreszSzam.ToString(), true));
            rpc.Add(new ReportParameter("OsszAlkatreszDarabSzam", stat.OsszAlkatreszDarabSzam.ToString(), true));
            rpc.Add(new ReportParameter("TeljesKeszletAr", stat.TeljesKeszletAr.ToString(), true));
            rpc.Add(new ReportParameter("KategoriakSzama", stat.KategoriakSzama.ToString(), true));
            rpc.Add(new ReportParameter("ProjektekSzama", stat.ProjektekSzama.ToString(), true));
            rpc.Add(new ReportParameter("LezartProjektekSzama", stat.LezartProjektekSzama.ToString(), true));
            rpc.Add(new ReportParameter("NyitottProjektekSzama", stat.NyitottProjektekSzama.ToString(), true));

            reportViewer1.LocalReport.SetParameters(rpc);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("StatisztikaDS", dataSet.Tables["StatisztikaDS"]));
            reportViewer1.RefreshReport();
        }
        #endregion

        /// <summary>
        /// A projekt adatainak reportálásához való ReportViewer, és az ezáltal a ProjektReport.rdlc reportfájl, adatainak feltöltését végzi el.
        /// </summary>
        private void ProjektReport()
        {
            reportViewer1.LocalReport.ReportPath = @"Report/ProjektReport.rdlc";
            dt = new DataTable("Alkatresz");
            DataSet dataSet = new DataSet("Alkatresz");

            dt.Columns.Add("Megnevezes", typeof(string));
            dt.Columns.Add("Darab", typeof(string));
            dt.Columns.Add("DarabAr", typeof(string));
            dt.Columns.Add("OsszAr", typeof(string));
            dt.Columns.Add("Parameterek", typeof(string));
            dt.Columns.Add("Kategoria", typeof(string));
            dt.Columns.Add("Megjegyzes", typeof(string));



            DataRow sor;
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
                sor["Kategoria"] = alkatresz.Alkatresz.Kategoria.ToString();
                sor["Megjegyzes"] = alkatresz.Megjegyzes;
                dt.Rows.Add(sor);
            }
            dataSet.Tables.Add(dt);

            List<ReportParameter> parameterek = new List<ReportParameter>
            {
                new ReportParameter("ProjektNev", projekt.ProjektNev, true),
                new ReportParameter("ProjektLeiras", projekt.Leiras, true),
                new ReportParameter("ProjektMegjegyzes", projekt.Megjegyzes, true)
            };
            foreach (Keszlet alkatresz in projekt.AlkatreszLista)
            {
                parameterek.Add(new ReportParameter("AlkatreszMegnevezes", alkatresz.Alkatresz.Megnevezes, true));
                parameterek.Add(new ReportParameter("AlkatreszDarabszam", alkatresz.DarabSzam.ToString(), true));
                parameterek.Add(new ReportParameter("AlkatreszDarabar", alkatresz.DarabAr.ToString(), true)); parameterek.Add(new ReportParameter("AlkatreszOsszar", alkatresz.AlkatreszOsszAR().ToString(), true));
                parameterek.Add(new ReportParameter("AlkatreszParameterek", alkatresz.Alkatresz.ToString(), true));
                parameterek.Add(new ReportParameter("Kategoria", alkatresz.Alkatresz.Kategoria.ToString(), true));
            }
            reportViewer1.LocalReport.SetParameters(parameterek);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet", dataSet.Tables[0]));
            reportViewer1.RefreshReport();
        }

        /// <summary>
        /// A készlet adatainak reportálását megvalósító metódus. A ReportViewer és az azt megjelenítő KeszletReport.rdlc fájl adatainak feltöltését végzi el.
        /// </summary>
        private void KeszletReport()
        {
            reportViewer1.LocalReport.ReportPath = @"Report/KeszletReport.rdlc";
            dt = new DataTable("Alkatresz");
            dt.Clear();

            DataSet dataSet = new DataSet("Alkatresz");

            dt.Columns.Add("Megnevezes", typeof(string));
            dt.Columns.Add("Darab", typeof(string));
            dt.Columns.Add("DarabAr", typeof(string));
            dt.Columns.Add("OsszAr", typeof(string));
            dt.Columns.Add("Parameterek", typeof(string));
            dt.Columns.Add("Kategoria", typeof(string));
            dt.Columns.Add("Megjegyzes", typeof(string));
            DataRow sor;
            foreach (Keszlet alkatresz in keszletLista)
            {
                sor = dt.NewRow();
                sor["Megnevezes"] = alkatresz.Alkatresz.Megnevezes;
                sor["Darab"] = alkatresz.DarabSzam.ToString();
                sor["DarabAr"] = alkatresz.DarabAr.ToString();
                sor["OsszAr"] = alkatresz.AlkatreszOsszAR().ToString();
                sor["Parameterek"] = alkatresz.Alkatresz.ToString();
                sor["Kategoria"] = alkatresz.Alkatresz.Kategoria.ToString();
                sor["Megjegyzes"] = alkatresz.Megjegyzes;
                dt.Rows.Add(sor);
            }
            dataSet.Tables.Add(dt);

            int kategoriaId = (int)keszletLista[0].Alkatresz.Kategoria.KategoriaId;

            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(
                new ReportParameter(
                    "Kategoria",
                    keszletLista[0].Alkatresz.Kategoria.KategoriaMegnevezes,
                    true));
            rpc.Add(
                new ReportParameter(
                    "AlkatreszekSzama",
                    ABKezelo.KategoriankentiAkatreszekSzamanakLekerdezese(kategoriaId).ToString(),
                    true));
            rpc.Add(
                new ReportParameter(
                    "AlkatreszOsszDarabSzam",
                    ABKezelo.KategoriankentiAkatreszekDarabSzamanakLekerdezese(kategoriaId).ToString(),
                    true));
            rpc.Add(
                new ReportParameter(
                    "OsszErtek",
                    ABKezelo.KategoriankentiOsszArLekerdezes(kategoriaId).ToString(),
                    true));
            reportViewer1.LocalReport.SetParameters(rpc);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet", dataSet.Tables["Alkatresz"]));
            reportViewer1.RefreshReport();
        }

        private void ReporterFrm_Load(object sender, EventArgs e)
        {
            //   reportViewer1.RefreshReport();
        }
    }
}
