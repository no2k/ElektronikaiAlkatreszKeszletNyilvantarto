using System;
using System.Collections;
using System.Collections.Generic;

namespace EKNyilvantarto.AlkatreszOsztalyok
{
    class AlkatreszParameter : IComparable<AlkatreszParameter>, IEquatable<AlkatreszParameter>, IEnumerable
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
            get => parameterSorszam;
            private set
            {
                if (value >= 0)
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
            return $"{ParameterErtek} {parameterMertekegyseg};";
        }
        int IComparable<AlkatreszParameter>.CompareTo(AlkatreszParameter other)
        {
            return ToString().CompareTo(other.ToString());
        }

        public bool Equals(AlkatreszParameter other)
        {
            if (parameterErtek == other.parameterErtek &&
                parameterMertekegyseg == other.parameterMertekegyseg)
            {
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return parameterSorszam.ToString().GetEnumerator();
        }
             
    }

}
