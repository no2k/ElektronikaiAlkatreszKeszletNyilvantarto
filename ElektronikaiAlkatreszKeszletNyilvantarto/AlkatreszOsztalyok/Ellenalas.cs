using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    enum EllenallasMertekEgyseg
    {
        mΩ,
        Ω,
        kΩ,
        MΩ
    }

    class Ellenalas : PasszivAlkatresz

    {
        float ellenallasErtek;
        EllenallasMertekEgyseg ellenallasMertekEgyseg;
        float teljesitmeny;


        public float EllenallasErtek
        {
            get => ellenallasErtek;
            private set
            {
                if (value > 0)
                {
                    ellenallasErtek = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Az ellenállás értéke csak negyobb lehet mint 0");
                }
            }

        }
        public float Teljesitmeny
        {
            get => teljesitmeny;
            private set
            {
                if (value > 0)
                {
                    teljesitmeny = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Az ellenállás teljesítménye csak negyobb lehet mint 0");
                }
            }
        }
        internal EllenallasMertekEgyseg EllenallasMertekEgyseg
        {
            get => ellenallasMertekEgyseg;
            /* set => ellenallasMertekEgyseg = value;*/
        }

        public Ellenalas(
             float ellenallasErtek,
        EllenallasMertekEgyseg ellenallasMertekEgyseg,
        float teljesitmeny, string megnevezes, int darabSzam, int darabAr, Kategoria kategoria, PasszivTokozas tokozas, float tolerancia, float raszterMeret, string megjegyzes) : base(megnevezes, darabSzam, darabAr, kategoria, tokozas, tolerancia, raszterMeret, megjegyzes)
        {
            EllenallasErtek = ellenallasErtek;
            this.ellenallasMertekEgyseg = ellenallasMertekEgyseg;
            Teljesitmeny = teljesitmeny;
        }

        public override string ToString()
        {
            return $"{Kategoria}:{EllenallasErtek}{EllenallasMertekEgyseg} {Teljesitmeny}W  Készleten:{DarabSzam} ({DarabAr}Ft)";
        }

        public override bool Equals(Alkatresz osszeHasonlitandoAlkatresz)
        {
            if (osszeHasonlitandoAlkatresz is Ellenalas ellen)
            {
                if (this.ellenallasErtek == ellen.EllenallasErtek &&
                    this.ellenallasMertekEgyseg == ellen.EllenallasMertekEgyseg &&
                    this.teljesitmeny == ellen.Teljesitmeny &&
                    this.Tokozas == ellen.Tokozas &&
                    this.RaszterMeret == ellen.RaszterMeret &&
                    this.Tolerancia == ellen.Tolerancia
                   )
                {
                    return true;
                }
            }
            return false;
        }

        public override int CompareTo(object obj)
        {
            if (obj is Ellenalas ellen)
            {
             return ToString().CompareTo(ellen.ToString());

            }
            return 0;
        }
    }
}
