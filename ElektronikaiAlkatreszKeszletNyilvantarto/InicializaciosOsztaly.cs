using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    static class InicializaciosOsztaly
    {
        internal static void AdatokBetoltese()
        {
            throw new NotImplementedException();
        }

       public static List<string> FoKategoriaBetoltes()
        {
            throw new NotImplementedException();
        }

        public static List<string> AlKategoriaBetoltes() 
        {
           
           return Fajlkezelo.StringFajlbolBeolvasas(@"alkategoria.txt");
            
        }
    } 
}
