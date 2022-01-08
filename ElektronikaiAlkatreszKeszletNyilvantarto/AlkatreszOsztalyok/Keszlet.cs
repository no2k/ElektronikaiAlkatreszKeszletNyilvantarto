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
        #region Fied-ek
        Alkatresz alkatresz;
        int? keszletId;
        float darabSzam;// darabdb
        float darabAr; //ar db
        string megjegyzes;
        #endregion

        #region Propertyk

        public float DarabSzam
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
        public int? KeszletId 
        {
            get => keszletId;
            set
            {
                if (keszletId == null)
                {
                    keszletId = value;
                }
                else
                {
                    throw new InvalidOperationException("A készlet ID csak egyszer adható meg!");
                }
            }
        }
        #endregion

        #region Konstruktorok
        public Keszlet(int? keszletId, float darabSzam, float darabAr, string megjegyzes,Alkatresz alkatresz)
        {
            KeszletId = keszletId;
            DarabSzam = darabSzam;
            DarabAr = darabAr;
            Megjegyzes = megjegyzes;
            Alkatresz = alkatresz;
        }
        #endregion

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
