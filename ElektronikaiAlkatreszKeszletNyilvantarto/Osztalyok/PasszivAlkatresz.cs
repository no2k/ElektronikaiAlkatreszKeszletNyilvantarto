using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok
{
    enum Szereles
    {
        Furatszerelt = 0,
        SMD = 1
    }
    enum Tokozas
    {
        SMD1201,
        SMD1206,
        SMD0805,
        SMD0603,
        SMD0402
    }
    struct UzemiHomerseklet
    {
        int min, max;
        public int Min
        {
            get => min;
            private set
            {
                if (value < max)
                {
                    min = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("A legkissebb üzemi hőmérséklet nem lehet nagyobb, vagy egyenlő, mint a maximális hőmérséklet");
                }
            }
        }
        public int Max
        {
            get => max;

            private set
            {
                if (value > min)
                {
                    max = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("A legnagyobb üzemi hőmérséklet nem lehet kissebb, vagy egyenlő, mint a minimális hőmérséklet!");
                }
            }
        }

        public UzemiHomerseklet(int min, int max) : this()
        {
            Min = min;
            Max = max;
        }
    }

    internal class PasszivAlkatresz :Alkatresz//,IFajlFormatum
    {
        #region Field-ek
        //általános adatok
        Szereles szerelesTipusa;   //nem lehet üres
        Tokozas tokozasTipusa;      //lehet amennyiben az alkatresz tht
        string alkatreszTipus;      //nem lehet üres
        float alkatreszParameter;       //nem lehet üres
        float tolerancia;           //nem lehet üres
        float raszterMeret;       //lehet üres
        UzemiHomerseklet uzemiHomerseklet;
        string gyarto, gyartoMegnevezes;  //lehet üres
        float xMeret, yMeret, zMeret, radiusz;




        #endregion

        #region Poperty-k
        public string AlkatreszTipus
        {
            get => alkatreszTipus;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    alkatreszTipus = value;
                }
                else
                {
                    throw new ArgumentNullException("Az alkatrész típusát meg kell adni!");
                }
            }
        }
        public float AlkatreszParameter
        {
            get => alkatreszParameter;
            set
            {
                if (value != 0)
                {
                    alkatreszParameter = value;
                }
                else
                {
                    throw new ArgumentNullException("Az alkatrész paramétere nem lehet 0!");
                }
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
        /*   public int UzemiHomerseklet 
           {
               get => uzemiHomerseklet;
               set
               {
                   if (value != 0)
                   {
                       uzemiHomerseklet = value;
                   }
                   else
                   {
                       throw new ArgumentNullException("Az alkatrész paramétere nem lehet 0!");
                   }
               }
           }*/
        public string Gyarto
        {
            get => gyarto;
            set => gyarto = value;
        }
        public string GyartoMegnevezes
        {
            get => gyartoMegnevezes;
            set => gyartoMegnevezes = value;
        }
        public float XMeret
        {
            get => xMeret;
            set => xMeret = value;
        }
        public float YMeret
        {
            get => yMeret;
            set => yMeret = value;
        }
        public float ZMeret
        {
            get => zMeret;
            set => zMeret = value;
        }
        public float Radiusz
        {
            get => radiusz;
            set => radiusz = value;
        }
        internal Szereles SzerelesTipusa
        {
            get => szerelesTipusa;
            set
            {
                szerelesTipusa = value;
            }
        }
        internal Tokozas TokozasTipusa // még meg kell nézni a propertyt
        {
            get => tokozasTipusa;
            set
            {
                if (SzerelesTipusa == Szereles.Furatszerelt)
                {
                    tokozasTipusa = value;
                }
            }
        }
        internal UzemiHomerseklet UzemiHomerseklet 
        {
            get => uzemiHomerseklet; 
            set => uzemiHomerseklet = value; 
        }


        #endregion


        #region Konstruktorok

        public PasszivAlkatresz(
            string AlkatreszTipus,
            float AlkatreszParameter,
            float Tolerancia,
            float RaszterMeret,
            string Gyarto,
            string GyartoMegnevezes,
            float XMeret,
            float YMeret,
            float ZMeret,
            float Radiusz,
            Szereles SzerelesTipusa,
            Tokozas TokozasTipusa,
            UzemiHomerseklet UzemiHomerseklet,
            string AlkatreszAzonosito,
            string AlkatreszMegnevezes,
            uint Darabszam,
            int DarabAr) :base(AlkatreszAzonosito, AlkatreszMegnevezes,Darabszam,DarabAr)
            {
            AlkatreszTipus = alkatreszTipus;
            AlkatreszParameter = alkatreszParameter;
            Tolerancia = tolerancia;
            RaszterMeret = raszterMeret;
            Gyarto = gyarto;
            GyartoMegnevezes = gyartoMegnevezes;
            XMeret = xMeret;
            YMeret = yMeret;
            ZMeret = zMeret;
            Radiusz = radiusz;
            SzerelesTipusa = szerelesTipusa;
            TokozasTipusa = tokozasTipusa;
            UzemiHomerseklet = uzemiHomerseklet;

            
        }



        #endregion

        #region Metodusok
        public override string ToString()
        {
            throw new NotImplementedException();
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
