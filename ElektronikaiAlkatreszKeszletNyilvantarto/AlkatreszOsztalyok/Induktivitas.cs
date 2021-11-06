using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    enum InduktivMertekEgyseg
    {
        nH,
        µH,
        mH,
    }
    enum InduktivEllenallasMertekegyseg
    {
        mΩ,
        Ω
    }
    enum InduktivUzemiAramMertekEgyseg
    {
        mA,
        A
    }
    class Induktivitas : PasszivAlkatresz
    {
        float induktivitasErtek;
        float induktivEllenallasErtek;
        float uzemiAram;
        InduktivEllenallasMertekegyseg induktivEllenallasMertekegyseg;
        InduktivMertekEgyseg induktivMertekEgyseg;
        InduktivUzemiAramMertekEgyseg induktivUzemiAramMertekEgyseg;

        public float InduktivitasErtek 
        {
            get => induktivitasErtek;
            private set
            {
                if (value > 0)
                {
                    induktivitasErtek = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Az induktivitás értéke nem lehet kissebb mint 0!");
                }
            }
        }
        public float InduktivEllenallasErtek
        { 
            get => induktivEllenallasErtek;
            private set
            {
                if (value > 0)
                {
                    induktivEllenallasErtek = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Az induktív ellenállás értéke nem lehet kissebb mint 0!");
                }
            }
        }
        public float UzemiAram 
        {
            get => uzemiAram;
            private set
            {
                if (value >=0)
                {
                    uzemiAram = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Az üzemi áram értéke nem lehet kissebb mint 0!");
                }
            }
        }
        internal InduktivEllenallasMertekegyseg InduktivEllenallasMertekegyseg { get => induktivEllenallasMertekegyseg; /*set => induktivEllenallasMertekegyseg = value;*/ }
        internal InduktivMertekEgyseg InduktivMertekEgyseg { get => induktivMertekEgyseg; /*set => induktivMertekEgyseg = value; */}
        internal InduktivUzemiAramMertekEgyseg InduktivUzemiAramMertekEgyseg { get => induktivUzemiAramMertekEgyseg; /*set => induktivUzemiAramMertekEgyseg = value;*/ }

        public Induktivitas(float induktivitasErtek, float induktivEllenallasErtek, float uzemiAram, InduktivEllenallasMertekegyseg induktivEllenallasMertekegyseg, InduktivMertekEgyseg induktivMertekEgyseg, InduktivUzemiAramMertekEgyseg induktivUzemiAramMertekEgyseg, string megnevezes, int darabSzam, int darabAr, Kategoria kategoria, PasszivTokozas tokozas, float tolerancia, float raszterMeret, string megjegyzes) : base(megnevezes, darabSzam, darabAr, kategoria, tokozas, tolerancia, raszterMeret, megjegyzes)
        {
            InduktivitasErtek=induktivitasErtek;
            InduktivEllenallasErtek=induktivEllenallasErtek;
            UzemiAram=uzemiAram;
            this.induktivEllenallasMertekegyseg=induktivEllenallasMertekegyseg;
            this.induktivMertekEgyseg=induktivMertekEgyseg;
            this.induktivUzemiAramMertekEgyseg=induktivUzemiAramMertekEgyseg;
        }

        public override string ToString()
        {
            return $"{Kategoria}:{induktivitasErtek}{InduktivMertekEgyseg} {InduktivEllenallasErtek}{InduktivEllenallasMertekegyseg} {UzemiAram}{InduktivUzemiAramMertekEgyseg} Készleten:{DarabSzam} ({DarabAr}Ft)";
        }
    }
}
