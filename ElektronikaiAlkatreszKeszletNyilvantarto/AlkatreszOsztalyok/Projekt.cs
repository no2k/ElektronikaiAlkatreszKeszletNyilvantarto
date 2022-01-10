using EKNyilvantarto.AlkatreszOsztalyok;
using System;
using System.Collections.Generic;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    class Projekt
    {
        #region Fieldek
        string prjNev, leiras;
        int azonosito;
        List<Keszlet> lista;
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
        public int Azonosito
        {
            get => azonosito;
            private set
            {
                if (value > 0)
                {
                    azonosito = value;
                }
                else
                {
                    azonosito = 1;
                    //throw new ArgumentNullException("Az azonositó nem lehetkissebb mint 1!");
                }
            }
        }
        internal List<Keszlet> Lista
        {
            get => lista;
            set => lista = value;
        }
        #endregion

        #region Konstruktor
        public Projekt(string prjNev, string leiras, int azonosito, List<Keszlet> lista)
        {
            PrjNev = prjNev;
            Leiras = leiras;
            Azonosito = azonosito;
            Lista = lista;
        }
        #endregion


    }
}
