using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    public class Parameter : IEnumerable,IEquatable<Parameter>
    {
        #region Fieldek

        private static int sorszam = 0;
        private int parameterSorszam;
        private string parameterMegnevezes;
        private string[] parameterMertekEgyseg;
        private int parameterTipus;
        #endregion

        #region Propertyk

        public int ParameterSorszam
        {
            get => parameterSorszam;
            set
            {
                if (value > 0)
                {
                    parameterSorszam = value;
                }
                else
                {
                    throw new ArgumentException("A megadott paraméter sorszáma nem lehet kevesebb mint 0");
                }

            }
        }
        public string ParameterMegnevezes
        {
            get => parameterMegnevezes;
            private set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    parameterMegnevezes = value;
                }
                else
                {
                    throw new ArgumentNullException("A megnevezés paraméter nem lehet üres!");
                }
            }
        }
        public string[] ParameterMertekEgyseg
        {
            get => parameterMertekEgyseg;
            private set
            {
               // parameterMertekEgyseg = value;
                parameterMertekEgyseg = value.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            }
        }
        public int ParameterTipus
        {
            get => parameterTipus;
            private set
            {
                if (value >= 0)
                {
                    parameterTipus = value;
                }
                else
                {
                    throw new ArgumentException("A megadott paraméter típusa nem lehet kevesebb mint 0");
                }
            }
        }
        #endregion

        #region Konstruktorok
        public Parameter(string parameterMegnevezes, string[] parameterMertekegyseg, int parameterTipus)
        {
            parameterSorszam = ++sorszam;
            ParameterMegnevezes = parameterMegnevezes;
            ParameterMertekEgyseg = parameterMertekegyseg;
            ParameterTipus = parameterTipus;
        }
        public Parameter(int ParameterSorszam, string parameterMegnevezes, string[] parameterMertekegyseg, int parameterTipus)
        {
            parameterSorszam = ParameterSorszam;
            ParameterMegnevezes = parameterMegnevezes;
            ParameterMertekEgyseg = parameterMertekegyseg;
            ParameterTipus = parameterTipus;
        }

        #endregion

        #region Metódusok
        public static string TombbolStringbeKonvertal(string[] mertekEgyseg)
        {    string s = "";
            if (mertekEgyseg.Length > 1)
            {
                foreach (string item in mertekEgyseg)
                {
                    s += item+";";
                }
                return s;
            }
            return mertekEgyseg[0];
        }
        public override string ToString()
        {
            string mertekegysegek = "";
            foreach (string item in parameterMertekEgyseg)
            {
                mertekegysegek += item + " ";
            }
            return $"-{parameterMegnevezes}: {mertekegysegek}; /{parameterTipus}/";
        }

        public IEnumerator GetEnumerator()
        {
            return parameterMertekEgyseg.GetEnumerator();
        }

        bool IEquatable<Parameter>.Equals(Parameter other)
        {
            if (String.Equals(this.parameterMegnevezes , other.parameterMegnevezes) &&
                String.Equals(TombbolStringbeKonvertal(this.ParameterMertekEgyseg ) , TombbolStringbeKonvertal(other.ParameterMertekEgyseg)) &&
                this.ParameterTipus == other.ParameterTipus)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
