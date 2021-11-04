using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    interface IKoltsegSzamito
    {
        double AlkatreszenkentiOsszAr(double alkatreszAr,int alkatreszDarabszam);
        double TeljesAr(List<Alkatresz> alkatreszekSzama);
        
    }
}
