using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{

    class Keszlet:IEquatable<Alkatresz>,IComparable<Alkatresz>
    {
        Alkatresz alkatresz;

        // string megnevezes;
        int darabSzam;// darabdb
        int darabAr; //ar db
        string megjegyzes;


        /*  public string Megnevezes
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
          }*/
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
        internal Alkatresz Alkatresz
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

        public Keszlet(/*string megnevezes,*/ int darabSzam, int darabAr, string megjegyzes)
        {
            // Megnevezes = megnevezes;
            DarabSzam = darabSzam;
            DarabAr = darabAr;
            Megjegyzes = megjegyzes;

        }

        public int AlkatreszOsszAR()
        {
            return darabAr * darabSzam;
        }


        public bool Equals(Alkatresz other)
        {
            return ((IEquatable<Alkatresz>)alkatresz).Equals(other);
        }

        int IComparable<Alkatresz>.CompareTo(Alkatresz other)
        {
            return ToString().CompareTo(other.ToString());
        }
    }
}
