using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok
{
    public class ParameterLista : IComparable, IEnumerable, IEquatable<ParameterLista>
    {
        #region Fieldek

        Kategoria kategoria;
        List<Parameter> parameterek = new List<Parameter>();
        #endregion

        #region Propertyk
        public Kategoria Kategoria
        {
            get => kategoria;
            set
            {
                if (value != null)
                {
                    kategoria = value;
                }
                else
                {
                    throw new ArgumentNullException("A kategória nem lehet üres");
                }
            }

        }
        public List<Parameter> Parameterek
        {
            get => parameterek;
            set
            {
                if (value != null)
                {
                    parameterek = value;
                }
                else
                {
                    throw new ArgumentNullException("A megadott paraméter lista legalább 1 elemet kell tartalmazzon!");
                }
            }
        }
        #endregion

        #region Konstruktorok

        public ParameterLista(Kategoria kategoria, List<Parameter> parameterek)
        {
            Kategoria = kategoria;
            Parameterek = parameterek;
        }
        #endregion

        #region Metódusok

        public void UjParameter(Parameter parameter)
        {
            if (parameter != null && parameterek != null)
            {
                parameterek.Add(parameter);
            }
            else
            {
                throw new ArgumentNullException("A Hozzáadni kívánt paraméter vagy paraméter lista üres!");
            }
        }
        public override string ToString()
        {
            return $"[{Kategoria}]=>{parameterek.Select(x => x.ToString())})";
        }
        public int CompareTo(object obj)
        {
            return ToString().CompareTo(obj.ToString());
        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)parameterek).GetEnumerator();
        }
        public bool Equals(ParameterLista other)
        {
            if (this.Parameterek.Count == other.Parameterek.Count)
            {
                int ugyanaz = 0;
                for (int i = 0; i < this.Parameterek.Count; i++)
                {
                    if (this.parameterek[i].Equals(other.Parameterek[i]))
                    {
                        ugyanaz++;
                    }
                }
                if (ugyanaz==parameterek.Count)
                {
                    return true;
                }
            }
            return false;
        }
    }

    #endregion



}


