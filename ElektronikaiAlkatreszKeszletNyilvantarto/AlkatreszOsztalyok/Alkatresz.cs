using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    /*
     * alkatrész osztály adatai:
     * -kategória / a meglévő kategória adatbázis kategória oszlopának beolvasása majd enumba konvertálás.(amennyiben van egyszerübb és gyorsabb módja akkor azt kell felkutatni és használni!!!
     * 
     * -paraméterek[] /egyedi saját lista dictionary alapokon + a felviteli adat típusát rögzítő integer vagy bináris szám
     * 
     * -készleten lévő (int v. uint)
     * .beszer.ár (float vagy double szám)
     * -megjegyzés (srting)*
     * 
     * /

    enum Kategoria
    {
        Ellenállás,
        Kondenzátor,
        Induktivitás/*,
      Dióda,
        Tranzisztor,
        FET,
        Tirisztor,
        IGBT,
        Intergrált,
        Digitális*/


    class Alkatresz//:IEquatable<Alkatresz>,IComparable
    {
        ParameterLista parameterek;
        string megnevezes;
        int darabSzam;
        int darabAr;
        string megjegyzes;


        public string Megnevezes
        {
            get => megnevezes;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    megnevezes = value;
                }
                else
                {
                    throw new ArgumentNullException("A megnevezés nem lehet üres!");
                }
            }
        }
        public int DarabSzam
        {
            get => darabSzam;
            set
            {
                if (value > 0)
                {
                    darabSzam = value;
                }
                else
                {
                    throw new ArgumentNullException("A darabszám nem lehet 0  !");
                }
            }
        }
        public int DarabAr
        {
            get => darabAr;
            set
            {
                if (value >= 0)
                {
                    darabAr = value;
                }
                else
                {
                    throw new ArgumentNullException("A darab ár nem lehet kevesebb mint 0 !");
                }
            }
        }

        public string Megjegyzes { get => megjegyzes; set => megjegyzes = value; }
        public ParameterLista Parameterek
        {
            get => parameterek;
            set
            {
                if (value != null)
                {
                    parameterek = value;
                }
                else
                {
                    throw new ArgumentNullException("Az alkatrész paraméter listája nem lehet üres!");
                }
            }
        }

        public Alkatresz(string megnevezes, int darabSzam, int darabAr, string megjegyzes, ParameterLista parameterek)
        {
            Megnevezes = megnevezes;
            DarabSzam = darabSzam;
            DarabAr = darabAr;
            Megjegyzes = megjegyzes;
            Parameterek = parameterek;
        }

        public int AlkatreszOsszAR()
        {
            return darabAr * darabSzam;
        }


        //   public  bool Equals(Alkatresz other);
        // public int CompareTo(object obj);


        /*  public int CompareTo(Alkatresz masikAlkatresz)
          {
              return ToString().CompareTo(masikAlkatresz.ToString());
          }*/


    }

}
