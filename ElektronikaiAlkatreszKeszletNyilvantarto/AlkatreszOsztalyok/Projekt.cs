using EKNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections.Generic;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    class Projekt
    {
        #region Fieldek
        string prjNev, leiras,megjegyzes;
        int? azonosito; //adatbázisból lekérdezi
        List<Keszlet> alkatreszLista;
        bool statusz;
        
        #endregion

        #region Property-k
        public string PrjNev
        {
            get => prjNev;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    prjNev = value;
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
        public int? Azonosito
        {
            get => azonosito;
            set
            {
                if (azonosito ==null)
                {
                    azonosito = value;
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
        public bool Statusz { get => statusz; private set => statusz = value; }
        #endregion

        #region Konstruktor
        public Projekt(string prjNev, string leiras, int? azonosito, List<Keszlet> alkatreszLista, string megjegyzes, bool statusz)
        {
            PrjNev = prjNev;
            Leiras = leiras;
            Azonosito = azonosito;
            AlkatreszLista = alkatreszLista;
            Megjegyzes = megjegyzes;
            Statusz = statusz;
        }
        #endregion


    }
}
