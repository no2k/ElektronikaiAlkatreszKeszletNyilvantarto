using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek
{
    enum AnyagTipus
    {
        Elektrolit,
        Tantál,
        Fólia,
        Kerámia,
        Poliészter,
        Polipropilén,
        X2
    }

    enum Mertekegyseg
    {
        F,
        uF,
        nF,
        pF
    }

    internal class Kondenzator : PasszivAlkatresz
    {

        #region Fieldek
        
        float kapacitas;
        float uzemiFeszultseg;
        AnyagTipus kondenzatorAnyagTipus;  //bipoláris csak elektrolit!
        Mertekegyseg mertekEgyseg;

        #endregion

        #region Property-k
        public float Kapacitas
        {
            get => kapacitas;
            set
            {
                if (value != 0)
                {
                    kapacitas = value;
                }
                else
                {
                    throw new ArgumentNullException("A kapacitás nem lehet 0");
                }
            }
        }
        public float UzemiFeszultseg
        {
            get => uzemiFeszultseg;
            set
            {
                if (value > 0)
                {
                    uzemiFeszultseg = value;
                }
                else
                {
                    throw new ArgumentNullException("Az üzemi feszültség nem lehet kissebb mint 0V!");
                }

            }
        }
        internal AnyagTipus KondenzatorAnyagTipus
        {
            get => kondenzatorAnyagTipus;
            set => kondenzatorAnyagTipus = value;
            /*  {
                  if (Enum.IsDefined(typeof(AnyagTipus),value))
                  {
                       kondenzatorTipus = value;
                  }
                  else
                  {
                      throw new ArgumentOutOfRangeException("A megadott kondenzátor típusa hibás!");
                  }
              }*/
        }
        internal Mertekegyseg MertekEgyseg
        {
            get => mertekEgyseg;
            set => mertekEgyseg = value;
        }
        #endregion

        #region Konstruktorok
        public Kondenzator(float kapacitas,
                           float uzemiFeszultseg,
                           AnyagTipus kondenzatorAnyagTipus,
                           Mertekegyseg mertekEgyseg,
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
                           string AlkatreszAlTipus,
                           string AlkatreszAzonosito,
                           //string AlkatreszMegnevezes,
                           uint Darabszam,
                           int DarabAr) : base(
                               AlkatreszAlTipus,
                               AlkatreszTipus,
                               AlkatreszParameter,
                               Tolerancia,
                               RaszterMeret,
                               Gyarto,
                               GyartoMegnevezes,
                               XMeret,
                               YMeret,
                               ZMeret,
                               Radiusz,
                               SzerelesTipusa,
                               TokozasTipusa,
                               UzemiHomerseklet,
                               AlkatreszAzonosito,
                               Darabszam,
                               DarabAr)
        {
            Kapacitas = kapacitas;
            UzemiFeszultseg = uzemiFeszultseg;
            KondenzatorAnyagTipus = kondenzatorAnyagTipus;
            MertekEgyseg = mertekEgyseg;
           // AlkatreszAzonosito = 
        }
        #endregion

        #region Metodusok
        public override string ToString()
        {
            throw new NotImplementedException();
        }
        public override string AzonositoGenerator()
        {
            return $"{base.AzonositoGenerator()}";
        }
        #endregion
    }
}
