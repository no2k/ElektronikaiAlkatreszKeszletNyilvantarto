using System;
using System.Collections.Generic;

namespace EKNyilvantarto.AlkatreszOsztalyok
{

     class Keszlet : IEquatable<Keszlet>
    {
        #region Fied-ek
        Alkatresz alkatresz;
        int? keszletId;
        float darabSzam;
        float darabAr; 
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
        public Keszlet(int? keszletId, float darabSzam, float darabAr, string megjegyzes, Alkatresz alkatresz)
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

        public override string ToString()
        {
            return $"{darabSzam} {darabAr} , {Alkatresz}";

        }
        public bool Equals(Keszlet other)
        {
            if (alkatresz.Kategoria.KategoriaMegnevezes.ToLower() == other.alkatresz.Kategoria.KategoriaMegnevezes.ToLower() &&
                alkatresz.Megnevezes.ToLower() == other.Alkatresz.Megnevezes.ToLower() &&
                alkatresz.Parameterek.Count == other.Alkatresz.Parameterek.Count)
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
                if (eggyezik == parameterekSzama)
                {
                    return true;
                }

            }
            return false;
        }

        
    }
}
