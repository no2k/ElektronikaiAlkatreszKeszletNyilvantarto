using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek
{
    enum IndEllMertEgyseg
    {
        mΩ,
        Ω,
        kΩ,
        MΩ
    }

    internal class Ellenallas : PrimitivAlkatreszCsoport
    {
        #region Fieldek
        IndEllMertEgyseg mertekEgyseg;
        float teljesitmeny;


        #endregion
        #region Propertyk
        float Teljesitmeny { get => teljesitmeny; set => teljesitmeny = value; }
        IndEllMertEgyseg MertekEgyseg { get => mertekEgyseg; set => mertekEgyseg = value; }
        public Ellenallas(string alkatreszTipus,
                          float alkatreszErtek,
                          IndEllMertEgyseg mertekEgyseg,
                          float teljesitmeny,
                          float tolerancia,
                          Tokozas tokozas,
                          float raszterMeret,
                          string megjegyzes,
                          int darabszam,
                          int darabAr
                          ) : base( alkatreszErtek,
                                   tokozas,
                                   tolerancia,
                                   raszterMeret,
                                   megjegyzes,
                                   alkatreszTipus,
                                   darabszam,
                                   darabAr)
        {
            Teljesitmeny = teljesitmeny;
            MertekEgyseg = mertekEgyseg;
        }


        #endregion

        #region Konstruktorok



        #endregion

        #region Metódusok
        public override double AlkatreszenkentiOsszAr(double alkatreszAr, int alkatreszDarabszam)
        {
            return base.AlkatreszenkentiOsszAr(alkatreszAr, alkatreszDarabszam);
        }

        public override string AzonositoGenerator()
        {
            return base.AzonositoGenerator() + $"{mertekEgyseg}{base.Tokozas}";
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion



    }
}
