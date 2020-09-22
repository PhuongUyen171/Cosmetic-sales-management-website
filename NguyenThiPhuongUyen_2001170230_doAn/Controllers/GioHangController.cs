using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using NguyenThiPhuongUyen_2001170230_doAn.Models;
namespace NguyenThiPhuongUyen_2001170230_doAn.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lst = Session["Giohang"] as List<GioHang>;
            if (lst == null)
            {
                lst = new List<GioHang>();
                Session["Giohang"] = lst;
            }
            return lst;
        }
        public ActionResult ThemGioHang(int ma, string ur)
        {
            List<GioHang> lst = LayGioHang();
            GioHang sp = lst.Find(n => n.ma == ma);
            if (sp == null)
            {
                sp = new GioHang(ma);
                lst.Add(sp);
                return Redirect(ur);
            }
            else
            {
                sp.sl++;
                return Redirect(ur);
            }
            return RedirectToAction("GioHang","GioHang");
        }
        public int TongSl()
        {
            int s = 0;
            List<GioHang> lst = Session["Giohang"] as List<GioHang>;
            if (lst != null)
                s = lst.Sum(n => n.sl);
            return s;
        }
        public double TongTien()
        {
            double s = 0;
            List<GioHang> lst = Session["Giohang"] as List<GioHang>;
            if (lst != null)
                s = lst.Sum(n => n.thanhTien);
            return s;
        }
        public ActionResult GioHang()
        {
            List<GioHang> lst = LayGioHang();
            if (lst.Count == 0)
                return RedirectToAction("Index", "Home");
            ViewBag.Tongsolg = TongSl();
            ViewBag.Tongtien = TongTien();
            return View(lst);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.Tongsolg = TongSl();
            ViewBag.Tongtien = TongTien();
            return PartialView();
        }
        public ActionResult XoaGioHang(int id)
        {
            List<GioHang> lst = LayGioHang();
            GioHang sp = lst.SingleOrDefault(n=>n.ma == id);
            if (sp != null)
            {
                lst.RemoveAll(n => n.ma == id);
                return RedirectToAction("GioHang");
            }
            if (lst.Count == 0)
                return RedirectToAction("Index","Home");
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<GioHang> lst = LayGioHang();
            lst.Clear();
            return RedirectToAction("Index","Home");
        }
        public ActionResult CapNhatGioHang(int id, FormCollection f)
        {
            List<GioHang> lst = LayGioHang();
            GioHang sp = lst.SingleOrDefault(n => n.ma == id);
            sp.sl = int.Parse(f["txtSl"].ToString());
            return RedirectToAction("GioHang","GioHang");
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
                return RedirectToAction("DangNhap","NguoiDung");
            if(Session["Giohang"] == null)
                return RedirectToAction("Index", "Home");
            List<GioHang> lst = LayGioHang();
            ViewBag.Tongsolg = TongSl();
            ViewBag.Tongtien = TongTien();
            return View(lst);
        }
        public ActionResult DatHang(FormCollection collection)
        {
            HOA_DON hd = new HOA_DON();
            KHACH_HANG kh = (KHACH_HANG)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            //hd.MaHD = "HD" + data.HOA_DONs.Count();
            //hd.TaiKhoan = kh.TaiKhoan;
            hd.ThoiGian = DateTime.Now;
            //var NgayGiao = String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);
            //dh.NGAYGIAO = DateTime.Parse(NgayGiao);
            //hd.NGAYGIAO = DateTime.Now.AddDays(2);
            //hd.TINHTRANGGIAOHANG = "Đang tiếp nhận";
           // hd.TINHTRANGTHANHTOAN = "Chưa thanh toán";
            data.HOA_DONs.InsertOnSubmit(hd);
            data.SubmitChanges();

            foreach (var item in gh)
            {
                CHI_TIET_HOA_DON CTDH = new CHI_TIET_HOA_DON();
                CTDH.MaHD = hd.MaHD;
                CTDH.MaSP = Convert.ToInt32( item.ma);
                CTDH.SoLuong = item.sl;
                //Chú ý chỗ này chưa sửa donGia
                CTDH.GiaBan = (decimal)item.donGia;
                data.CHI_TIET_HOA_DONs.InsertOnSubmit(CTDH);
            }
            data.SubmitChanges();
            Session["Giohang"] = null;
            return RedirectToAction("XacNhanDonHang", "GioHang");
        }
        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}
