using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{

    class Keszlet:IEquatable<Keszlet>
    {
        Alkatresz alkatresz;
        int darabSzam;// darabdb
        float darabAr; //ar db
        string megjegyzes;
       
        public int DarabSzam
        {
            get => darabSzam;
            set
            {
                if (value >= 0)
                {
                    darabSzam = value;
                }
                else
                {
                    throw new ArgumentNullException("A darabszám nem lehet kevesebb mint 0!");
                }
            }
        }
        public float DarabAr
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
        public Alkatresz Alkatresz
        {
            get => alkatresz;
            set
            {
                if (value != null)
                {
                    alkatresz = value;
                }
            }
        }

        public Keszlet( int darabSzam, float darabAr, string megjegyzes,Alkatresz alkatresz)
        {
            DarabSzam = darabSzam;
            DarabAr = darabAr;
            Megjegyzes = megjegyzes;
            Alkatresz = alkatresz;
        }

        public float AlkatreszOsszAR()
        {
            return darabAr * darabSzam;
        }

        bool IEquatable<Keszlet>.Equals(Keszlet other)
        {
            if (alkatresz.Kategoria.KategoriaMegnevezes.ToLower() == other.alkatresz.Kategoria.KategoriaMegnevezes.ToLower() &&
                alkatresz.Megnevezes.ToLower() ==other.Alkatresz.Megnevezes.ToLower() )
            {
                int eggyezik = 0;
                int parameterekSzama = alkatresz.Parameterek.Count;
                for (int i = 0; i < parameterekSzama; i++)
                {
                    if (alkatresz.Parameterek[i].Equals(other.alkatresz.Parameterek[i]))
                    {
                        eggyezik++;
                    }
                }
                if (eggyezik==parameterekSzama)
                {
                    return true;
                }

            }
            return false;
        }





        /*
         * bool IEquatable<Parameter>.Equals(Parameter other)
        {
            if (String.Equals(this.parameterMegnevezes , other.parameterMegnevezes) &&
                String.Equals(TombbolStringbeKonvertal(this.ParameterMertekEgyseg ) , TombbolStringbeKonvertal(other.ParameterMertekEgyseg)) &&
                this.ParameterTipus == other.ParameterTipus)
            {
                return true;
            }
            return false;
        }
         * 

        public bool Equals(Alkatresz other)
        {
            if (alkatresz.Equals(other))
            {
                return true;
            }
            return false;
        }*/

        /*  int IComparable<Alkatresz>.CompareTo(Alkatresz other)
          {
              return ToString().CompareTo(other.ToString());
          }

          public IEnumerator GetEnumerator()
          {
              return ((IEnumerable)alkatresz.ToString()).GetEnumerator();
          }*/
    }
}
