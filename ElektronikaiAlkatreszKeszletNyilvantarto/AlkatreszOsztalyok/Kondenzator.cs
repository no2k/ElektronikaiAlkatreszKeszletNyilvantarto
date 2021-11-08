using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    enum KondenzatorTipus
    {
        Elektrolit,
        Tantál,
        Fólia,
        Kerámia,
        Poliészter,
        Polipropén,
        X2
    }
    enum KapacitasMertekEgyseg
    {
        F,
        µF,
        nF,
        pf
    }

    class Kondenzator : PasszivAlkatresz
    {
        float kapacitasErtek;
        KapacitasMertekEgyseg kapacitasMertekEgyseg;
        float uzemiFeszultseg;
        KondenzatorTipus tipus;

        public float KapacitasErtek
        {
            get => kapacitasErtek;
            private set
            {
                if (value > 0)
                {
                    kapacitasErtek = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("A kapacitás értéke nem lehet kissebb mint 0!");
                }
            }

        }
        public float UzemiFeszultseg
        {
            get => uzemiFeszultseg;
            private set
            {
                if (value > 0)
                {
                    uzemiFeszultseg = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Az üzemi feszültség értéke nem lehet kissebb mint 0!");
                }
            }
        }
        internal KapacitasMertekEgyseg KapacitasMertekEgyseg { get => kapacitasMertekEgyseg; /*set => kapacitasMertekEgyseg = value;*/ }
        internal KondenzatorTipus Tipus { get => tipus; /*set => tipus = value;*/ }

        public Kondenzator(float kapacitasErtek, KapacitasMertekEgyseg kapacitasMertekEgyseg,
        float uzemiFeszultseg, KondenzatorTipus tipus, string megnevezes, int darabSzam, int darabAr, Kategoria kategoria, PasszivTokozas tokozas, float tolerancia, float raszterMeret, string megjegyzes) : base(megnevezes, darabSzam, darabAr, kategoria, tokozas, tolerancia, raszterMeret, megjegyzes)
        {
            KapacitasErtek = kapacitasErtek;
            this.kapacitasMertekEgyseg = kapacitasMertekEgyseg;
            UzemiFeszultseg = uzemiFeszultseg;
            this.tipus = tipus;
        }

        public override string ToString()
        {
            return $"{Kategoria}:{Tipus} {KapacitasErtek}{KapacitasMertekEgyseg} {UzemiFeszultseg}V Készleten:{DarabSzam} ({DarabAr}Ft)";
        }

        /*public int CompareTo(Kondenzator other)
        {
            throw new NotImplementedException();
        }*/

        public override bool Equals(Alkatresz osszeHasonlitandoAlkatresz)
        {
            if (osszeHasonlitandoAlkatresz is Kondenzator kondi)
            {
                if (this.tipus == kondi.Tipus &&
                    this.kapacitasErtek == kondi.KapacitasErtek &&
                    this.kapacitasMertekEgyseg == kondi.KapacitasMertekEgyseg &&
                    this.uzemiFeszultseg == kondi.UzemiFeszultseg &&
                    this.Tokozas == kondi.Tokozas &&
                    this.RaszterMeret == kondi.RaszterMeret &&
                    this.Tolerancia == kondi.Tolerancia
                   )
                {
                    return true;
                }
            }
            return false;
        }

        public override int CompareTo(object obj)
        {
            if (obj is Kondenzator ellen)
            {
                return ToString().CompareTo(ellen.ToString());

            }
            return 0;
        }
    }
}
