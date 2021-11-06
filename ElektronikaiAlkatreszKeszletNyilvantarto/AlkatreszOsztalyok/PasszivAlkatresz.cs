using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    enum PasszivTokozas
    {
        THT,
        SMD1210,
        SMD1206,
        SMD0805,
        SMD0603,
        SMD0402
    }
    abstract class PasszivAlkatresz : Alkatresz
    {
        PasszivTokozas tokozas;
        float tolerancia;
        float raszterMeret;

        public float Tolerancia { get => tolerancia; /*set => tolerancia = value; */ }
        public float RaszterMeret { get => raszterMeret; /*set => raszterMeret = value; */}
        internal PasszivTokozas Tokozas { get => tokozas; /*set => tokozas = value;*/ }

        public PasszivAlkatresz(string megnevezes, int darabSzam, int darabAr, Kategoria kategoria, PasszivTokozas tokozas, float tolerancia, float raszterMeret, string megjegyzes) : base(megnevezes, darabSzam, darabAr, kategoria, megjegyzes)
        {
            this.tokozas = tokozas;
            this.tolerancia = tolerancia;
            this.raszterMeret = raszterMeret;
        }

       /* public override string ToString()
        {
            return base.ToString();
        }*/
    }
}
