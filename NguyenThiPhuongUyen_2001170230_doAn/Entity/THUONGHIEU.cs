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
    
    public partial class THUONGHIEU
    {
        public THUONGHIEU()
        {
            this.SANPHAMs = new HashSet<SANPHAM>();
        }
    
        public string MATH { get; set; }
        public string TENTH { get; set; }
        public string PHOTOTH { get; set; }
    
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
