//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NguyenThiPhuongUyen_2001170230_doAn.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TIN
    {
        public TIN()
        {
            this.BINHLUANs = new HashSet<BINHLUAN>();
        }
    
        public int MATIN { get; set; }
        public string TIEUDE { get; set; }
        public string HINH { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public string TOMTAT { get; set; }
    
        public virtual ICollection<BINHLUAN> BINHLUANs { get; set; }
    }
}