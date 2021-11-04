using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    static class Fajlkezelo
    {
        public static void ListaFajlbaMentes(string fajlNev, List<string> adat)
        {
            StreamWriter writer;
            try
            {
                using (writer = new StreamWriter(fajlNev, true, Encoding.Default))
                {
                    foreach (string item in adat)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> ListaFajlbolBeolvasas(string fajlNev)
        {
            List<string> adatok = new List<string>();
            if (File.Exists(fajlNev))
            {
                using (StreamReader reader = new StreamReader(fajlNev, Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        adatok.Add(reader.ReadLine());
                    }
                    reader.Close();
                }
                return adatok;
            }
            else
            {
                throw new FileNotFoundException($"A \"{fajlNev}\" nem létezik!");
            }
        }

        public static void StringFajlbaMentes(string fajlNev, string[] adat)
        {
            StreamWriter writer;
            try
            {
                using (writer = new StreamWriter(fajlNev, true, Encoding.Default))
                {
                    foreach (string item in adat)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> StringFajlbolBeolvasas(string fajlNev)
        {
            //string[] adattomb = null;
            if (File.Exists(fajlNev))
            {
                using (StreamReader reader = new StreamReader(fajlNev, Encoding.Default))
                {
                    List<string> lista = new List<string>();
                  //  int i = 0;
                    while (!reader.EndOfStream)
                    {
                         lista.Add(reader.ReadLine());
                       // i++;
                    }
                    reader.Close();
                    return lista;
                }
            }
            else
            {
                throw new FileNotFoundException($"A \"{fajlNev}\" nem létezik!");
            }
        }

    }

}
