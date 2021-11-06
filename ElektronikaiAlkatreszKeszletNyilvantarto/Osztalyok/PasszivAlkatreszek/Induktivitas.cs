using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.Osztalyok.PasszivAlkatreszek
{
    enum AramMertekEgyseg
    {
        μA,
        mA,
        A
    }
    enum IndukciosMertekEgyseg
    {
        mH,
        μH,
        nH
    }

    internal class Induktivitas : PrimitivAlkatreszCsoport
    {
        #region Fieldek
        IndukciosMertekEgyseg mertekEgyseg;
        EllMertekEgyseg indEllMertEgyseg;
        float indukciosEllenallasErtek;
        float uzemiAram;
        AramMertekEgyseg uzemiAMertEgyseg;
        #endregion

        #region Propertyk
        public float IndEllErtek
        {
            get => indukciosEllenallasErtek;
            set
            {
                if (value > 0)
                {
                    indukciosEllenallasErtek = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Az ellenállás értéke nem lehet 0, vagy ettől kissebb!");
                }
            }
        }
        public float UzemiAram
        {
            get => uzemiAram;
            set
            {
                if (value > 0)
                {
                    uzemiAram = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Az üzemi áram érteke nem lehet 0, vagy ettől kissebb!");
                }
            }
        }
        internal IndukciosMertekEgyseg MertekEgyseg
        {
            get => mertekEgyseg;
            set => mertekEgyseg = value;
        }
        internal EllMertekEgyseg IndEllMertEgyseg
        {
            get => indEllMertEgyseg;
            set => indEllMertEgyseg = value;
        }
        internal AramMertekEgyseg UzemiAMertEgyseg 
        { 
            get => uzemiAMertEgyseg;
            set => uzemiAMertEgyseg = value; 
        }

        #endregion

        #region Konstruktor

        public Induktivitas(string alkatreszTipus,
                             float ellenallasErtek,
                             float uzemiAram,
                             AramMertekEgyseg uzemiAMertEgyseg,
                             IndukciosMertekEgyseg mertekEgyseg,
                             EllMertekEgyseg elenallasMertekegyseg,
                             float alkatreszErtek,
                             Tokozas tokozas,
                             float tolerancia,
                             float raszterMeret,
                             string megjegyzes,
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
            IndEllErtek = ellenallasErtek;
            UzemiAram = uzemiAram;
            UzemiAMertEgyseg = uzemiAMertEgyseg;
            MertekEgyseg = mertekEgyseg;
            IndEllMertEgyseg = elenallasMertekegyseg;
        }
        #endregion

        #region Metódusok

        public override string ToString()
        {
            return $"[{AlkatreszTipus}]\r\n  -{AlkatreszErtek}{MertekEgyseg}; {IndEllErtek}{IndEllMertEgyseg}\r\n  -{UzemiAram}{UzemiAMertEgyseg}\r\n  -{Tokozas}.";
        }

        public override string AzonositoGenerator()
        {
            return $"-{(float)AlkatreszErtek}{(IndukciosMertekEgyseg)MertekEgyseg}_{Tokozas.ToString().Substring(0,3)}";
        }

       
        #endregion


    }
}
