using System;
using System.Collections.Generic;

namespace EKNyilvantarto.AlkatreszOsztalyok
{
    class Alkatresz : IEquatable<Alkatresz>
    {
        int alkatreszId;
        Kategoria kategoria;
        string megnevezes;
        List<AlkatreszParameter> parameterek = new List<AlkatreszParameter>();

        public Kategoria Kategoria { get => kategoria; /*set => kategoria = value;*/ }
        public List<AlkatreszParameter> Parameterek
        {
            get => parameterek;
            set
            {
                if (value != null)
                {
                    parameterek = value;
                }
            }
        }
        public string Megnevezes
        {
            get => megnevezes;
            set
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
        public int AlkatreszId
        {
            get => alkatreszId; private set
            {
                if (value > 0)
                {
                    alkatreszId = value;
                }
                else
                {
                    throw new ArgumentNullException("Az alkatrész azonosító nem lehet 0!");
                }
            }
        }

        public Alkatresz()
        {
        }

        public Alkatresz(int azonosito, Kategoria kategoria, string megnevezes, List<AlkatreszParameter> parameterek)
        {

            this.kategoria = kategoria;
            this.megnevezes = megnevezes;
            this.parameterek = parameterek;
            AlkatreszId = azonosito;
        }


        public override string ToString()
        {
            string parameterString = string.Empty;
            foreach (AlkatreszParameter item in parameterek)
            {
                parameterString += item.ToString() + " ";
            }
            return parameterString;
            //   return $"{parameterek.Select(x => x.ParameterErtek + x.ParameterMertekegyseg)}";
        }
        public bool Equals(Alkatresz other)
        {
            if (parameterek.Equals(other.Parameterek))
            {
                return true;
            }
            return false;
        }


    }
}
