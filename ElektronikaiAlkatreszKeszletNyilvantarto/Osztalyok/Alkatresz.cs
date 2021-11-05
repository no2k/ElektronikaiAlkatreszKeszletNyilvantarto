using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    enum Kategoria
    {
        Ellenállás,
    }

    abstract class Alkatresz : IAzonositoGenerator//, IKoltsegSzamito
    {
        #region Field-ek
        string alkatreszAzonosito; //auto generalt
        string alkatreszTipus; //alkatresz neve
        int darabszam;             //alkatresz raktari darabszam
        int darabAr;                //alkatreszenkenti ar
        #endregion

        #region Property-k
        public string AlkatreszAzonosito
        {
            get => alkatreszAzonosito; //az alkatrészek generálják
            private set
             {
                 if (!string.IsNullOrWhiteSpace(value))
                 {
                     alkatreszAzonosito = value;
                 }
                 else
                 {
                     throw new ArgumentNullException("Az azonosítót meg kell adni!");
                     // elvileg nem feltétlen kell mivel majd a leszármazottak generálják!
                 }
             }
        }
        public string AlkatreszTipus 
        {
            get => alkatreszTipus;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    alkatreszTipus = value;
                }
                else
                {
                    throw new ArgumentNullException("A megnevezés kitöltése kötelező!");
                }
            }
        } 
        public int Darabszam
        {
            get => darabszam;
            private set
            {
                if (value >= 0)
                {
                    darabszam = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("A darabszám 0, vagy nagyobb lehet"); //hibás érték msgbox
                }
            }
        }
        public int DarabAr
        {
            get => darabAr;
            set
            {
                if (value >= 0)
                {
                    darabAr = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Az alkatrész darab ára nem lehet kissebb mint 0"); //hibás érték msgbox
                }
            }
        }
        #endregion

        #region Konstruktor
        protected Alkatresz(string alkatreszTipus, 
                            int darabszam,
                            int darabAr)
        {
           
            AlkatreszTipus = alkatreszTipus;
            Darabszam = darabszam;
            DarabAr = darabAr; 
            AlkatreszAzonosito = AzonositoGenerator();
        }
        #endregion

        #region Metodusok
        public abstract override string ToString();
        public virtual string AzonositoGenerator()
       {
            return $"{alkatreszTipus.Substring(0, 3)}";
        }
        

        public abstract double AlkatreszenkentiOsszAr(double alkatreszAr, int alkatreszDarabszam);
       

        double TeljesAr( List<Alkatresz> alkatreszekSzama)
        {
            //  return alkatreszekSzama.Where(i=>i.)
            return 0;        
        }


        // public abstract ICSVExport();

        //public abstract CSVImport();
        #endregion

    }
}
