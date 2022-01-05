using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElektronikaiAlkatreszKeszletNyilvantarto.Interfacek;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    class Alkatresz : IEquatable<Alkatresz>
    {
        Kategoria kategoria;
        string megnevezes;
        List<AlkatreszParameter> parameterek = new List<AlkatreszParameter>();

        public Kategoria Kategoria { get => kategoria; /*set => kategoria = value;*/ }
        public List<AlkatreszParameter> Parameterek { 
            get => parameterek;
            set
            {
                if (value!=null)
                {
                    parameterek=value;
                }
            } 
            
        }
        public string Megnevezes 
        { 
            get => megnevezes;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    megnevezes = value;
                }
                else
                {
                    throw new ArgumentNullException("A megnevezés nem lehet üres!");
                }
            }
        }

        public Alkatresz(Kategoria kategoria,string megnevezes, List<AlkatreszParameter> parameterek)
        {
            this.kategoria = kategoria;
            this.megnevezes = megnevezes;
            this.parameterek = parameterek;
        }

        public override string ToString()
        {
            return $"{megnevezes} {parameterek.Select(x=>x.ParameterErtek + x.ParameterMertekegyseg)}";
        }
        public bool Equals(Alkatresz other)
        {
            if (parameterek.Equals(other))
            {
                return true;
            }
            return false;
        }

      
    }
}
