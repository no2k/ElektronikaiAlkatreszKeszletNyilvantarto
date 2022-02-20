using EKNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKNyilvantarto
{
    internal class KategoriaAdatTarolo
    {
        #region Fieldek

        string megnevez;
        int alkatreszekSzama;
        float darabSzam;
        float osszertek;

        #endregion

        #region Propertyk

        public string Megnevez { get => megnevez; set => megnevez = value; }
        public int AlkatreszekSzama { get => alkatreszekSzama; set => alkatreszekSzama = value; }
        public float DarabSzam { get => darabSzam; set => darabSzam = value; }
        public float Osszertek { get => osszertek; set => osszertek = value; }

        #endregion

        #region Konstruktor

        public KategoriaAdatTarolo(string megnevez, int alkatreszekSzama, float darabSzam, float osszertek)
        {
            Megnevez = megnevez;
            AlkatreszekSzama = alkatreszekSzama;
            DarabSzam = darabSzam;
            Osszertek = osszertek;
        }
       
        #endregion
    }
    public class Statisztika: IEnumerable
    {
        #region Fieldek

        int osszAlkatreszSzam;
        float osszAlkatreszDarabSzam;
        float teljesKeszletAr;
        int kategoriakSzama;
        internal List<KategoriaAdatTarolo> kategoriaAdatok=new List<KategoriaAdatTarolo>();
        int projektekSzama, lezartProjektekSzama, nyitottProjektekSzama;
        #endregion

        #region Propertyk

        public int OsszAlkatreszSzam { get => osszAlkatreszSzam; set => osszAlkatreszSzam = value; }
        public float OsszAlkatreszDarabSzam { get => osszAlkatreszDarabSzam; }
        public float TeljesKeszletAr { get => teljesKeszletAr; }
        public int KategoriakSzama { get => kategoriakSzama; }
        internal List<KategoriaAdatTarolo> KategoriaAdatok { get => kategoriaAdatok; }
        public int ProjektekSzama { get => projektekSzama; }
        public int LezartProjektekSzama { get => lezartProjektekSzama; }
        public int NyitottProjektekSzama { get => nyitottProjektekSzama; set => nyitottProjektekSzama = value; }

        #endregion

        #region Konstruktor

        public Statisztika()
        {
            OsszesAlkatreszSzam();
            OsszDarabSzam();
            TeljesAlkatreszKeszletAr();
            KategoriaFelsorolas();
            ProjektDarabSzam();
        }

        #endregion

        #region Metódusok
       
        private void OsszesAlkatreszSzam()
        {
            osszAlkatreszSzam = ABKezelo.AlkatreszekSzama();
        } //OK!
        private void OsszDarabSzam()
        {
            osszAlkatreszDarabSzam = ABKezelo.OsszesAlkatreszKeszletenLevoDarabszama();
        } //OK!
        private void TeljesAlkatreszKeszletAr()
        {
            teljesKeszletAr = ABKezelo.OsszesKeszletenLevoAlkatreszAr();
        } //OK!
        private void KategoriaFelsorolas()
        {
            List<Kategoria> kategoriaLista = ABKezelo.KategoriaLekerdezes();
            kategoriakSzama = kategoriaLista.Count;
            foreach (Kategoria kat in kategoriaLista)
            {
                string str = kat.KategoriaMegnevezes;
                int alkatreszSzam = ABKezelo.KategoriankentiAkatreszekSzamanakLekerdezese((int)kat.KategoriaId);
                float darabSzam= ABKezelo.KategoriankentiAkatreszekDarabSzamanakLekerdezese((int)kat.KategoriaId);
                float osszAr = ABKezelo.KategoriankentiOsszArLekerdezes((int)kat.KategoriaId);

                kategoriaAdatok.Add(
                new KategoriaAdatTarolo(str, alkatreszSzam, darabSzam, osszAr));
                
            }
        } //OK!
        private void ProjektDarabSzam()
        {
            projektekSzama = ABKezelo.OsszesProjektSzama();
            lezartProjektekSzama = ABKezelo.LezartProjektSzama();
            nyitottProjektekSzama = ABKezelo.NyitottProjektSzama();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)kategoriaAdatok).GetEnumerator();
        }

        #endregion
    }
}
