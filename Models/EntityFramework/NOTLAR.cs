//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciNotMVC.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class NOTLAR
    {
        public int NOTID { get; set; }
        public Nullable<byte> DERSID { get; set; }
        public Nullable<int> OGRID { get; set; }
        public Nullable<byte> SINAV1 { get; set; }
        public Nullable<byte> SINAV2 { get; set; }
        public Nullable<byte> SINAV3 { get; set; }
        public Nullable<byte> PROJE { get; set; }
        public Nullable<decimal> ORTALAMA { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        public virtual DERSLER DERSLER { get; set; }
        public virtual OGRENCILER OGRENCILER { get; set; }
    }
}
