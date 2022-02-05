using System;
using System.Collections;
using System.Linq;

namespace EKNyilvantarto.AlkatreszOsztalyok
{
    public class ParameterDef : IEnumerable, IEquatable<ParameterDef>
    {
        #region Fieldek

        private static int sorszam = 1;
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
        public ParameterDef(string parameterMegnevezes, string[] parameterMertekegyseg, int parameterTipus)
        {
            parameterSorszam = sorszam;
            ParameterMegnevezes = parameterMegnevezes;
            ParameterMertekEgyseg = parameterMertekegyseg;
            ParameterTipus = parameterTipus;
        }
        public ParameterDef(int ParameterSorszam, string parameterMegnevezes, string[] parameterMertekegyseg, int parameterTipus)
        {
            parameterSorszam = ParameterSorszam;
            ParameterMegnevezes = parameterMegnevezes;
            ParameterMertekEgyseg = parameterMertekegyseg;
            ParameterTipus = parameterTipus;
        }

        #endregion

        #region Metódusok
        public static string TombbolStringbeKonvertal(string[] mertekEgyseg)
        {
            string s = "";
            if (mertekEgyseg.Length > 1)
            {
                foreach (string item in mertekEgyseg)
                {
                    s += item + ";";
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

        bool IEquatable<ParameterDef>.Equals(ParameterDef other)
        {
            if (String.Equals(this.parameterMegnevezes, other.parameterMegnevezes) &&
                String.Equals(TombbolStringbeKonvertal(this.ParameterMertekEgyseg), TombbolStringbeKonvertal(other.ParameterMertekEgyseg)) &&
                this.ParameterTipus == other.ParameterTipus)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
