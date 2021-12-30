using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    class AlkatreszParameter : IComparable<AlkatreszParameter>, IEquatable<AlkatreszParameter>
    {
        int parameterSorszam;
        string parameterErtek, parameterMertekegyseg;
       
        public string ParameterErtek
        {
            get => parameterErtek;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    parameterErtek = value;
                }
                else
                {
                    throw new ArgumentNullException("A paraméter érték nem lehet üres!");
                }
            }

        } 
        public string ParameterMertekegyseg
        {
            get => parameterMertekegyseg;
           private set => parameterMertekegyseg = value;
        } 
        public int ParameterSorszam
        {
            get => parameterSorszam; private set
            {
                if (value >=0)
                {
                    parameterSorszam = value;
                }
                else
                {
                    throw new ArgumentNullException("A paraméter Sorszáma nem lehet kevesebb mint 0!");
                }
            }
        }

        public AlkatreszParameter(int parameterSorszam, string parameterErtek, string parameterMertekegyseg)
        {

            ParameterSorszam = parameterSorszam;
            ParameterErtek = parameterErtek;
            ParameterMertekegyseg = parameterMertekegyseg;
        }

        public override string ToString()
        {
            return $"{ParameterErtek} {parameterMertekegyseg}";
        }
        int IComparable<AlkatreszParameter>.CompareTo(AlkatreszParameter other)
        {
            return ToString().CompareTo(other.ToString());
        }

        public bool Equals(AlkatreszParameter other)
        {
            if (parameterSorszam==other.parameterSorszam &&
                parameterErtek==other.parameterErtek &&
                parameterMertekegyseg==other.parameterMertekegyseg)
            {
                return true;
            }
            return false;
        }
    }

    class Alkatresz:IEquatable<Alkatresz>
    {
        Kategoria kategoria;
        private List<AlkatreszParameter> parameterek = new List<AlkatreszParameter>();

        public Kategoria Kategoria { get => kategoria; /*set => kategoria = value;*/ }
        internal List<AlkatreszParameter> Parameterek { get => parameterek; /*set => parameterek = value; */}

        public Alkatresz(Kategoria kategoria, List<AlkatreszParameter> parameterek)
        {
            this.kategoria = kategoria;
            this.parameterek = parameterek;
        }

        public bool Equals(Alkatresz other)
        {
            if (parameterek.Equals(other))
            {
                return true;
            }
            return false;
        }
    }
}
