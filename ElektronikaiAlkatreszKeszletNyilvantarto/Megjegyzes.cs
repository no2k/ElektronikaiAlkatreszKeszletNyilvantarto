//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    using System;
    using System.Collections.Generic;
    
    public partial class Megjegyzes
    {
        public int Id { get; set; }
        public string Megjegyzes1 { get; set; }
    
        public virtual Alkatresz Alkatresz { get; set; }
    }
}