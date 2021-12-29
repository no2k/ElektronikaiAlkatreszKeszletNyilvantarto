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

        } //not null
        public string ParameterMertekegyseg
        {
            get => parameterMertekegyseg;
            set => parameterMertekegyseg = value;
        } //null
        public int ParameterSorszam
        {
            get => parameterSorszam; private set
            {
                if (value > 0)
                {
                    parameterSorszam = value;
                }
                else
                {
                    throw new ArgumentNullException("A paraméter Sorszáma nem lehet 0 vagy kevesebb!");
                }
            }
        }

        public AlkatreszParameter(int parameterSorszam, string parameterErtek, string parameterMertekegyseg)
        {

            ParameterSorszam = parameterSorszam;
            ParameterErtek = parameterErtek;
            ParameterMertekegyseg = parameterMertekegyseg;
        }

        int IComparable<AlkatreszParameter>.CompareTo(AlkatreszParameter other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(AlkatreszParameter other)
        {
            throw new NotImplementedException();
        }
    }
}
