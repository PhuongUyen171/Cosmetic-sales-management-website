using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenThiPhuongUyen_2001170230_doAn.Models;
using PagedList.Mvc;
using PagedList;
using Microsoft.CSharp;

namespace NguyenThiPhuongUyen_2001170230_doAn.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        DataClasses1DataContext data = new DataClasses1DataContext();

        public ActionResult Index(string tim, string ma = "Tất cả")
        {
            ViewBag.ma = new SelectList(data.THE_LOAI_SAN_PHAMs.ToList().OrderBy(n => n.TenLoaiSP), "MaLoaiSP", "TenLoaiSP");
            var sp = from s in data.SAN_PHAMs select s;
            if (!String.IsNullOrEmpty(tim))
            {
                sp = sp.Where(s => s.TenSP.Contains(tim));
            }
            if (ma != "")
            {
                sp = sp.Where(s => s.MaLoaiSP == ma);
            }
            List<SAN_PHAM> ds = new List<SAN_PHAM>();
            foreach (var item in sp)
            {
                SAN_PHAM t = new SAN_PHAM();
                t.MaSP = item.MaSP;
                t.TenSP = item.TenSP;               
                t.HinhAnh = item.HinhAnh;
                t.MoTa = item.MoTa;
                t.MaTH = item.MaTH;
                t.MaLoaiSP = item.MaLoaiSP;
                t.GiaBan = item.GiaBan;
                ds.Add(t);
            }
            return View(ds);
        }
        [HttpPost]
        public ActionResult TimKiem(FormCollection c)
        {
            var tim = c["tim"];
            var bg = data.SAN_PHAMs.Where(m => m.TenSP.Contains(tim) == true).ToList();
            return View(bg);
        }
        //Mục lục dọc
        public ActionResult ThuongHieu()
        {
            var t = from th in data.THUONG_HIEUs select th;
            return PartialView(t);
        }

        public ActionResult DanhMuc()
        {
            var dm = from tl in data.THE_LOAI_SAN_PHAMs select tl;
            return PartialView(dm);
        }
        
        //Phân loại sản phẩm
        public ActionResult SanPhamTheoDM(string id)
        {
            var sp = data.SAN_PHAMs.Where(m=>m.MaLoaiSP==id);
            return View(sp);
        }

        public ActionResult SanPhamTheoThuongHieu(string id)
        {
            var sp = data.SAN_PHAMs.Where(m => m.MaTH == id);
            return View(sp);
        }

        public ActionResult ChiTiet(int id)
        {
            //try
            //{
                var tin = data.SAN_PHAMs.FirstOrDefault(m => m.MaSP == id);
                return View(tin);
            //}
            //catch (Exception)
            //{
            //    return View();
            //}
            
        }

        public ActionResult SanPhamTheoThuongHieu3(string id)
        {
            var sp = data.SAN_PHAMs.Where(m => m.MaTH == id).Take(3).ToList();
            return PartialView(sp);
        }
    }
}
