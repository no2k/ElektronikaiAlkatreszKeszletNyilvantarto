using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek
{
    #region Enum listák


    enum KondenzatorTipus
    {
        Elektrolit,
        Tantál,
        Fólia,
        Kerámia,
        Poliészter,
        Polipropilén,
        X2
    }
    enum KondMertEgyseg
    {
        F,
        μF,
        nF,
        pF
    }
    #endregion
   
    internal class Kondenzator : PrimitivAlkatreszCsoport
    {

        #region Fieldek
        KondenzatorTipus kondenzatorTipus;
        KondMertEgyseg mertekEgyseg;
        float uzemiFeszultseg;


        #endregion

        #region Property-k

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
        internal KondenzatorTipus KondenzatorTipus
        {
            get => kondenzatorTipus;
            set => kondenzatorTipus = value;
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
        internal KondMertEgyseg MertekEgyseg
        {
            get => mertekEgyseg;
            set => mertekEgyseg = value;
        }

        #endregion

        #region Konstruktorok
        public Kondenzator(KondenzatorTipus kondenzatorTipus,
                           float alkatreszErtek,
                           KondMertEgyseg mertEgyseg,
                           float uzemiFeszultseg,
                           Tokozas tokozas,
                           float tolerancia,
                           float raszterMeret,
                           string megjegyzes,
                           string alkatreszTipus,
                           int darabszam,
                           int darabAr) : base(alkatreszErtek,
                                               tokozas,
                                               tolerancia,
                                               raszterMeret,
                                               megjegyzes,
                                               alkatreszTipus,
                                               darabszam,
                                               darabAr)
        {
            if (this.Tokozas==0)
            {
                raszterMeret = 0;
            }
        }
        #endregion

        #region Metodusok
        public override string ToString()
        {
            return $"[{AlkatreszTipus}]\r\n  -{KondenzatorTipus}; {base.AlkatreszErtek} {mertekEgyseg}\r\n  -{uzemiFeszultseg}V; {Tokozas}.";
        }
        public override string AzonositoGenerator()
        {
            return base.AzonositoGenerator() + $"{int.Parse(AlkatreszTipus)}_{AlkatreszErtek}{mertekEgyseg}_{base.Tokozas.ToString().Substring(0,3)}";
        }

        public override double AlkatreszenkentiOsszAr(double alkatreszAr, int alkatreszDarabszam)
        {
            return base.AlkatreszenkentiOsszAr(alkatreszAr, alkatreszDarabszam);
        }

        #endregion
    }
}
