
using System;
using System.Collections.Generic;

namespace EKNyilvantarto.AlkatreszOsztalyok
{
    internal class Projekt
    {
        #region Fieldek
        string projektNev, leiras, megjegyzes;
        int? projektAzonosito; //adatbázisból lekérdezi
        List<Keszlet> alkatreszLista;
        bool lezartStatusz;

        #endregion

        #region Property-k
        public string ProjektNev
        {
            get => projektNev;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    projektNev = value;
                }
                else
                {
                    throw new ArgumentNullException("A Projekt Név nem lehet üres!");
                }
            }
        }
        public string Leiras
        {
            get => leiras;
            set => leiras = value;
        }
        public int? ProjektAzonosito
        {
            get => projektAzonosito;
            set
            {
                if (projektAzonosito == null)
                {
                    projektAzonosito = value;
                }
                else
                {
                    throw new ArgumentNullException("Az azonositót csak egyszer lehet beeállítani!");
                }
            }
        }
        internal List<Keszlet> AlkatreszLista
        {
            get => alkatreszLista;
            set => alkatreszLista = value;
        }
        public string Megjegyzes { get => megjegyzes; set => megjegyzes = value; }
        public bool LezartStatusz { get => lezartStatusz; set => lezartStatusz = value; }
        #endregion

        #region Konstruktor
        public Projekt(string projektNev, string leiras, int? projektAzonosito, List<Keszlet> alkatreszLista, string megjegyzes, bool lezartStatusz)
        {
            ProjektNev = projektNev;
            Leiras = leiras;
            ProjektAzonosito = projektAzonosito;
            AlkatreszLista = alkatreszLista;
            Megjegyzes = megjegyzes;
            LezartStatusz = lezartStatusz;
        }
        #endregion

        public Queue<string> NyomtathatoFormatum()
        {
            Queue<string> kimenetiSorTarolo = new Queue<string>();
            string kimenetiString = $"Azonositó:{projektAzonosito} |Megnevezés:{projektNev} |Leírás:{leiras} |Alkatrész lista:\n\r";
            string[] kimenetiTomb = kimenetiString.Split('|');
            foreach (string item in kimenetiTomb)
            {
                kimenetiSorTarolo.Enqueue(item);
            }
            foreach (Keszlet alkatresz in alkatreszLista)
            { //a sort előről vagy hátulról járja be????
                foreach (string adatok in alkatresz.NyomtathatoFormatum())
                {
                    kimenetiSorTarolo.Enqueue(adatok);
                }
            }
            // A többit a projektben lévő készlet állítja elő alkatrészenként
            return kimenetiSorTarolo;
        }

    }
}
