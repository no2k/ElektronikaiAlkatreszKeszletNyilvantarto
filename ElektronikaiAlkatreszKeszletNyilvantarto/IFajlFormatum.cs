using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    interface IFajlFormatum
    {
        List<T> CSVFormatum<T>(string elvalaszoKarakter);
        List<T> AdatFormatum<T>(List<string> stringLista, char elvalaszto); 


    }
}
