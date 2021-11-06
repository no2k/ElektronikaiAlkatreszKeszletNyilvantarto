using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok
{
    enum Tokozas
    {
        Furatszerelt = 0,
        SMD1201 = 1,
        SMD1206 = 2,
        SMD0805 = 3,
        SMD0603 = 4,
        SMD0402 = 5
    }

    internal abstract class PrimitivAlkatreszCsoport : Alkatresz//,IFajlFormatum
    {
        #region Field-ek
        float alkatreszErtek;
        Tokozas tokozas;
        float tolerancia;
        float raszterMeret;
        string megjegyzes;
        #endregion

        #region Poperty-k
        public float AlkatreszErtek
        {
            get => alkatreszErtek;
            set
            {
                if (value != 0)
                {
                    alkatreszErtek = value;
                }
                else
                {
                    throw new ArgumentNullException("Az alkatrész értéke nem lehet 0!");
                }
            }
        }
        internal Tokozas Tokozas
        {
            get => tokozas;
            set
            {
                tokozas = value;
            }
        }
        public float Tolerancia
        {
            get => tolerancia;
            set
            {
                if (value >= 0)
                {
                    tolerancia = value;
                }
                else
                {
                    throw new ArgumentNullException("Az alkatrész toleranciája nem lehet 0, vagy 0-nál kissebb!");
                }
            }
        }
        public float RaszterMeret
        {
            get => raszterMeret;
            set => raszterMeret = value;
        }
        public string Megjegyzes
        {
            get => megjegyzes;
            set => megjegyzes = value;
        }
       
        #endregion

        #region Konstruktorok
        protected PrimitivAlkatreszCsoport(float alkatreszErtek,
                                           Tokozas tokozas,
                                           float tolerancia,
                                           float raszterMeret,
                                           string megjegyzes,
                                           string alkatreszTipus,
                                           int darabszam,
                                           int darabAr) : base(alkatreszTipus,
                                                               darabszam,
                                                               darabAr)
        {
            
            AlkatreszErtek = alkatreszErtek;
            Tokozas = tokozas;
            Tolerancia = tolerancia;
            RaszterMeret = raszterMeret;
            Megjegyzes = megjegyzes;
        }
        #endregion

        #region Metodusok
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override string AzonositoGenerator()
        {
            return base.AzonositoGenerator();
        }

        
        /*    List<T> IFajlFormatum.CSVFormatum<T>(string elvalaszoKarakter)
            {
                throw new NotImplementedException();
            }

            List<T> IFajlFormatum.AdatFormatum<T>(List<string> stringLista, char elvalaszto)
            {
                throw new NotImplementedException();
            }*/


        #endregion
    }
}
