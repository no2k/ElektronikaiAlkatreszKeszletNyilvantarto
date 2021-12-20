using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    public class Parameter : IComparable
    {
        #region Fieldek
        
        private int sorszam=0;
        private int parameterSorszam;
        private string parameterMegnevezes;
        private string parameterErtek;
        private int parameterTipus;
        #endregion

        #region Propertyk

        public int ParameterSorszam
        {
            get => parameterSorszam;
            private set
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
        public string ParameterErtek
        {
            get => parameterErtek;
            private set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    parameterErtek = value;
                }
                else
                {
                    throw new ArgumentNullException("Az érték paraméter nem lehet üres!");
                }
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
        public Parameter(string parameterMegnevezes, string parameterErtek, int parameterTipus)
        {
            parameterSorszam=++sorszam;
            ParameterMegnevezes = parameterMegnevezes;
            ParameterErtek = parameterErtek;
            ParameterTipus = parameterTipus;
        }

        #endregion

        #region Metódusok

        public override string ToString()
        {
            return $"-{parameterSorszam}-{parameterMegnevezes}: {parameterErtek}; /{parameterTipus}/";
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
