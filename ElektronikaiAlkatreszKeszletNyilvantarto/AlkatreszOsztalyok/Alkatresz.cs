using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
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
    }

    abstract class Alkatresz:IEquatable<Alkatresz>,IComparable
    {
        Kategoria kategoria;
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
        internal Kategoria Kategoria { get => kategoria; /* set => kategoria = value;*/ }
        public string Megjegyzes { get => megjegyzes; set => megjegyzes = value; }

        public Alkatresz(string megnevezes, int darabSzam, int darabAr, Kategoria kategoria, string megjegyzes)
        {
            Megnevezes = megnevezes;
            DarabSzam = darabSzam;
            DarabAr = darabAr;
            this.kategoria = kategoria;
            Megjegyzes = megjegyzes;
        }

        public int AlkatreszOsszAR()
        {
            return darabAr * darabSzam;
        }
      
        public override string ToString() => $"{Megnevezes}-{Kategoria}";
        public abstract bool Equals(Alkatresz other);
        public abstract int CompareTo(object obj);


        /*  public int CompareTo(Alkatresz masikAlkatresz)
          {
              return ToString().CompareTo(masikAlkatresz.ToString());
          }*/


    }
       
}
