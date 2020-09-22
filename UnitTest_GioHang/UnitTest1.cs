using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NguyenThiPhuongUyen_2001170230_doAn;
using System.Web;
//using System.Web.Mvc;
using System.Collections.Generic;
using NguyenThiPhuongUyen_2001170230_doAn.Models;
using NguyenThiPhuongUyen_2001170230_doAn.Controllers;

namespace UnitTest_GioHang
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TC_CapNhatGioHangDong()
        {
            Random r = new Random();
            int a=r.Next(1,10);
            GioHangController g = new GioHangController();
            
        }

        [TestMethod]
        public void testTC1_ThemGioHangDong()
        {
            GioHangController gc = new GioHangController();
            List<GioHang> ds = new List<GioHang>();
            for (int i = 0; i < 5; i++)
            {
                Random r = new Random();
                int a = r.Next(1, 10);
                GioHang g = new GioHang("SP" + a);

                gc.ThemGioHang("SP" + a, "http://localhost:12742/");
                ds.Add(g);
            }
            Assert.AreEqual(5, ds.Count);
            Assert.AreEqual(ds.Count, gc.TongSl());
        }
    }
}
