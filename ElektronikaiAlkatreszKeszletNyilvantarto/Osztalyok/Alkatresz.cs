using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    abstract class Alkatresz
    {
        #region Field-ek
        string alkatreszAzonosito; //auto generalt
        string alkatreszMegnevezes; //alkatresz neve
        uint darabszam;             //alkatresz raktari darabszam
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
        public string AlkatreszMegnevezes 
        {
            get => alkatreszMegnevezes;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    alkatreszMegnevezes = value;
                }
                else
                {
                    throw new ArgumentNullException("A megnevezés kitöltése kötelező!");
                }
            }
        } 
        public uint Darabszam
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
                if (value <= 0)
                {
                    darabAr = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Az allkatrész darabára nem lehet kissebb mint 0"); //hibás érték msgbox
                }
            }
        }
        #endregion

        #region Konstruktor
        protected Alkatresz(string AlkatreszAzonosito, string AlkatreszMegnevezes, uint Darabszam, int DarabAr)
        {
            AlkatreszAzonosito = alkatreszAzonosito;
            AlkatreszMegnevezes = alkatreszMegnevezes;
            Darabszam = darabszam;
            DarabAr = darabAr;
        }
        #endregion

        #region Metodusok
        public abstract override string ToString();

        // public abstract ICSVExport();

        //public abstract CSVImport();
        #endregion

    }
}
