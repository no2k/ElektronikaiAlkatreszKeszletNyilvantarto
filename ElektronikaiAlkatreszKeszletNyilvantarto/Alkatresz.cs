﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    abstract class Alkatresz
    {
        string alkatreszAzonosito;
        string alkatreszMegnevezes;
        uint darabszam;

        public string AlkatreszAzonosito
        {
            get => alkatreszAzonosito; //az alkatrészek generálják
           /* set
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
            }*/
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
                if (value>=0)
                {
                    darabszam = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("A darabszám 0, vagy nagyobb lehet"); //hibás érték msgbox
                }
            }
        }

        protected Alkatresz(string alkatreszAzonosito, string alkatreszMegnevezes, uint darabszam)
        {
            this.alkatreszAzonosito = alkatreszAzonosito;
            this.AlkatreszMegnevezes = alkatreszMegnevezes;
            Darabszam = darabszam;
        }

        public abstract override string ToString();

       // public abstract ICSVExport();
       
        //public abstract CSVImport();
              

    }
}
