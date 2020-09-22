using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenThiPhuongUyen_2001170230_doAn.Models;
namespace NguyenThiPhuongUyen_2001170230_doAn.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection c, KHACH_HANG kh)
        {
            var usr = c["TaiKhoan"];
            var pass1 = c["MK1"];
            var diachi = c["DiaChi"];
            var dienThoai = c["Sdt"];
            var ten = c["HoTen"];
            var pass2 = c["MK2"];

            if (String.IsNullOrEmpty(usr))
                ViewData["Loi1"] = "Tên đăng nhập không được để trống.";
            else if (String.IsNullOrEmpty(pass1))
                ViewData["Loi2"] = "Mật khẩu không được để trống.";
            else if (string.IsNullOrEmpty(pass2))
                ViewData["Loi3"] = "Người dùng phải xác nhận lại mật khẩu.";
            else if (String.Compare(pass1, pass2, true) != 0)
                ViewData["Loi4"] = "Mật khẩu và xác nhận mật khẩu không trùng khớp.";
            else
            {
                if (data.KHACH_HANGs.Where(t => t.TaiKhoan == usr).Count() == 0)
                {
                    kh.TaiKhoan = usr;
                    kh.Pass = pass1;
                    kh.DiaChi = diachi;
                    kh.SDT = dienThoai;
                    kh.TenKH = ten;
                    data.KHACH_HANGs.InsertOnSubmit(kh);
                    data.SubmitChanges();
                    return RedirectToAction("DangNhap");
                }
                else
                    ViewData["Loi1"] = "Tên đăng nhập đã tồn tại. Vui lòng đặt lại tên.";
            }
            return this.DangKy();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection c)
        {
            var usr = c["usr"];
            var pass = c["pass"];
            if (String.IsNullOrEmpty(usr))
                ViewData["Loi1"] = "Tên đăng nhập không được để trống.";
            else if (String.IsNullOrEmpty(pass))
                ViewData["Loi1"] = "Mật khẩu không được để trống.";
            else
            {
                KHACH_HANG kh = data.KHACH_HANGs.SingleOrDefault(n => n.TaiKhoan == usr && n.Pass == pass);
                if (kh != null)
                {
                    Session["TaiKhoan"] = kh;
                    return RedirectToAction("DatHang", "GioHang");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }
            return View();
        }
    }
}
