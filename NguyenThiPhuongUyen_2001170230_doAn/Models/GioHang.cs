using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenThiPhuongUyen_2001170230_doAn.Models
{
    public class GioHang
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public int ma { set; get; }
        public string ten { set; get; }
        public string anh { set; get; }
        public int sl { set; get; }
        public double donGia { set; get; }
        public double thanhTien { get { return sl * donGia; } }
        public GioHang(int ma)
        {
            this.ma = ma;
            SAN_PHAM s = data.SAN_PHAMs.Single(n => n.MaSP == ma);
            ten = s.TenSP;
            anh = s.HinhAnh;
            donGia = double.Parse(s.GiaBan.ToString());
            sl = 1;
        }
    }
}