using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek
{
    enum EllMertekEgyseg
    {
        mΩ,
        Ω,
        kΩ,
        MΩ
    }

    internal class Ellenallas : PrimitivAlkatreszCsoport
    {
        #region Fieldek
        EllMertekEgyseg mertekEgyseg;
        float teljesitmeny;
        #endregion
        #region Propertyk
        float Teljesitmeny { get => teljesitmeny; set => teljesitmeny = value; }
        EllMertekEgyseg MertekEgyseg { get => mertekEgyseg; set => mertekEgyseg = value; }
        public Ellenallas(string alkatreszTipus,
                          float alkatreszErtek,
                          EllMertekEgyseg mertekEgyseg,
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
        public override string ToString()
        {
            return $"[{AlkatreszTipus}]\r\n  -{AlkatreszErtek}{MertekEgyseg} {Tolerancia}% {Teljesitmeny}W\r\n  -{Tokozas}.";
        }


        public override string AzonositoGenerator()
        {
            return base.AzonositoGenerator() + $"_{AlkatreszErtek}{MertekEgyseg}_{Teljesitmeny}W_{base.Tokozas.ToString().Substring(0, 3)}";
        }

        
        #endregion



    }
}
