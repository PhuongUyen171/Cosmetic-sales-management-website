using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenThiPhuongUyen_2001170230_doAn.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
namespace NguyenThiPhuongUyen_2001170230_doAn.Controllers
{
    public class AdminController : Controller
    {
        public FormCollection f { get; set; }
        public AdminController() { }
        DataClasses1DataContext data = new DataClasses1DataContext();

        public ActionResult Index()
        {
            if (Session["TKAdmin"] == null)
                return RedirectToAction("DangNhap", "Admin");
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            Session["TKAdmin"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            var usr = f["TenDN"];
            var pass = f["MatKhau"];
            if (String.IsNullOrEmpty(usr))
                ViewData["Loi1"] = "Tên đăng nhập không được để trống.";
            else if (String.IsNullOrEmpty(pass))
                ViewData["Loi2"] = "Mật khẩu không được để trống.";
            else
            {
                DANG_NHAP ad = data.DANG_NHAPs.SingleOrDefault(n => n.TaiKhoan == usr && n.MatKhau == pass);
                if (ad != null)
                {
                    Session["TKAdmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }



        //-------------------------------SẢN PHẨM------------------------------------
        public ActionResult SanPham(int? page)
        {
            if (Session["TKAdmin"] == null)
                return RedirectToAction("DangNhap", "Admin");
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(data.SAN_PHAMs.ToList().OrderBy(n => n.MaSP).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ThemSanPham()
        {
            ViewBag.Matheloai = new SelectList(data.THE_LOAI_SAN_PHAMs.ToList().OrderBy(n => n.TenLoaiSP), "MaLoaiSP", "TenLoaiSP");
            ViewBag.Mathuonghieu = new SelectList(data.THUONG_HIEUs.ToList().OrderBy(n => n.TenTH), "MATH", "TENTH");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemSanPham(SAN_PHAM sp, HttpPostedFileBase fileUpload, FormCollection c)
        {
            ViewBag.Matheloai = new SelectList(data.THE_LOAI_SAN_PHAMs.ToList().OrderBy(n => n.TenLoaiSP), "MaLoaiSP", "TenLoaiSP");
            ViewBag.Mathuonghieu = new SelectList(data.THUONG_HIEUs.ToList().OrderBy(n => n.TenTH), "MaTH", "TenTH");

            if (string.IsNullOrEmpty(c["TenSP"]))
            {
                ViewData["Loi1"] = "Tên sản phẩm không được để trống.";
                return View();
            }
            if (string.IsNullOrEmpty(c["GiaBan"]))
            {
                ViewData["Loi1"] = "Giá sản phẩm không được để trống.";
                return View();
            }
            if (string.IsNullOrEmpty(c["SoLuong"]))
            {
                ViewData["Loi1"] = "Vui lòng nhập số lượng tồn.";
                return View();
            }
            if (fileUpload == null)
            {
                ViewData["Loi1"] = "Vui lòng chọn ảnh sản phẩm";
                //ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else if (!fileUpload.FileName.Contains(".jpg") && !fileUpload.FileName.Contains(".png") && !fileUpload.FileName.Contains(".img"))
            {
                ViewData["Loi1"] = "Vui lòng chèn đúng tệp hình";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);

                    var path = Path.Combine(Server.MapPath("~/Content/HinhAnh/SanPham"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewData["Loi1"] = "Hình ảnh đã tồn tại";
                    else
                        fileUpload.SaveAs(path);
                    //sp.MaSP = "MH" + data.SAN_PHAMs.Count(m => m.MaSP != null);
                    data.SAN_PHAMs.InsertOnSubmit(sp);
                    data.SubmitChanges();
                }
                return RedirectToAction("SanPham");
            }
            return View();
        }
        public ActionResult ChiTietSanPham(int id)
        {
            SAN_PHAM sp = data.SAN_PHAMs.SingleOrDefault(n => n.MaSP == id);
            ViewBag.Masanpham = sp.MaSP;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        public ActionResult XoaSanPham(int id)
        {
            SAN_PHAM sp = data.SAN_PHAMs.SingleOrDefault(n => n.MaSP == id);
            ViewBag.Masanpham = sp.MaSP;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        [HttpPost, ActionName("XoaSanPham")]
        public ActionResult XacNhanXoa(int id)
        {
            SAN_PHAM sp = data.SAN_PHAMs.SingleOrDefault(n => n.MaSP == id);
            ViewBag.Masanpham = sp.MaSP;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.SAN_PHAMs.DeleteOnSubmit(sp);
            data.SubmitChanges();
            return RedirectToAction("SanPham");
        }
        [HttpGet]
        public ActionResult SuaSanPham(int id)
        {
            SAN_PHAM sp = data.SAN_PHAMs.SingleOrDefault(n => n.MaSP == id);
            ViewBag.Masanpham = sp.MaSP;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.Matheloai = new SelectList(data.THE_LOAI_SAN_PHAMs.ToList().OrderBy(n => n.TenLoaiSP), "MaLoaiSP", "TenLoaiSP", sp.MaLoaiSP);
            ViewBag.Mathuonghieu = new SelectList(data.THUONG_HIEUs.ToList().OrderBy(n => n.TenTH), "MaTH", "TenTH", sp.MaTH);
            return View(sp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaSanPham(SAN_PHAM sp, HttpPostedFileBase file)
        {
            ViewBag.Matheloai = new SelectList(data.THE_LOAI_SAN_PHAMs.ToList().OrderBy(n => n.TenLoaiSP), "MaLoaiSP", "TenLoaiSP");
            ViewBag.Mathuonghieu = new SelectList(data.THUONG_HIEUs.ToList().OrderBy(n => n.TenTH), "MaTH", "TenTH");
            if (file == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnh/SanPham"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                        file.SaveAs(path);
                    sp.HinhAnh = fileName;
                    UpdateModel(sp);
                    data.SubmitChanges();
                }
                return RedirectToAction("SanPham");
            }
        }



        //--------------------------DANH MỤC--------------------------
        #region
        public ActionResult DanhMuc(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(data.THE_LOAI_SAN_PHAMs.ToList().OrderBy(n => n.MaLoaiSP).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ThemDanhMuc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemDanhMuc(THE_LOAI_SAN_PHAM tl, FormCollection c)
        {
            var ten = c["TenLoaiSP"];
            if (string.IsNullOrEmpty(ten))
                ViewData["Loi"] = "Tên danh mục không được để trống";
            else
            {
                tl.MaLoaiSP = data.THE_LOAI_SAN_PHAMs.Count() + 1 + "";
                tl.TenLoaiSP = ten;
                if (data.THE_LOAI_SAN_PHAMs.Where(t => t.TenLoaiSP == ten).Count() != 0)
                {
                    ViewData["Loi"] = "Tên danh mục đã bị trùng. Vui lòng nhập tên khác.";
                    return this.ThemDanhMuc();
                }
                data.THE_LOAI_SAN_PHAMs.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("DanhMuc");
            }
            return this.ThemDanhMuc();
        }
        public ActionResult SuaDanhMuc(string id)
        {
            var sua = data.THE_LOAI_SAN_PHAMs.First(m => m.MaLoaiSP == id);
            return View(sua);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaDanhMuc(string id, FormCollection c)
        {
            var sua = data.THE_LOAI_SAN_PHAMs.First(m => m.MaLoaiSP == id);
            var ten = c["TenLoaiSP"];
            sua.MaLoaiSP = id;
            if (string.IsNullOrEmpty(ten))
                ViewData["Loi"] = "Tên danh mục không được để trống.";
            else
            {
                sua.TenLoaiSP = ten;
                if (data.THE_LOAI_SAN_PHAMs.Where(t => t.TenLoaiSP == ten).Count() != 0)
                {
                    ViewData["Loi"] = "Tên danh mục đã bị trùng. Vui lòng nhập tên khác.";
                    return this.SuaDanhMuc(id);
                }
                UpdateModel(sua);
                data.SubmitChanges();
                return RedirectToAction("DanhMuc", "Admin");
            }
            return this.SuaDanhMuc(id);
        }
        public ActionResult ChiTietDanhMuc(string id)
        {
            var chitiet = data.THE_LOAI_SAN_PHAMs.Where(m => m.MaLoaiSP == id).First();
            return View(chitiet);
        }
        public ActionResult XoaDanhMuc(string id)
        {
            var xoa = data.THE_LOAI_SAN_PHAMs.First(m => m.MaLoaiSP == id);
            return View(xoa);
        }
        [HttpPost, ActionName("XoaDanhMuc")]
        public ActionResult XoaDanhMuc(string id, FormCollection c)
        {
            var sp = data.SAN_PHAMs.Where(t => t.MaLoaiSP == id).Count();
            if (sp == 0)
            {
                THE_LOAI_SAN_PHAM xoa = data.THE_LOAI_SAN_PHAMs.Where(m => m.MaLoaiSP == id).FirstOrDefault();
                data.THE_LOAI_SAN_PHAMs.DeleteOnSubmit(xoa);
                data.SubmitChanges();
                return RedirectToAction("DanhMuc");
            }
            else
            {
                return RedirectToAction("KhongTheXoa", "Admin");
            }
        }
        public ActionResult KhongTheXoa() 
        {
            return View();
        }
        #endregion

        //------------------------THƯƠNG HIỆU-------------------------
        #region
        public ActionResult ThuongHieu(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(data.THUONG_HIEUs.ToList().OrderBy(n => n.MaTH).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ThemThuongHieu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemThuongHieu(THUONG_HIEU th, FormCollection c,HttpPostedFileBase fileUpload)
        {
            var ten = c["TenTH"];
            var ma = c["MaTH"];
            //var hinh = c["fileUpload"];
            if (string.IsNullOrEmpty(ma))
            {
                ViewData["Loi"] = "Mã thương hiệu không được để trống";
                return View();
            }
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Loi"] = "Tên thương hiệu không được để trống";
                return View();
            }
            if (fileUpload == null || fileUpload.ContentLength == 0)
            {
                ViewData["Loi"] = "Vui lòng chọn ảnh bìa";
                return View();
            }
            //
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnh/ThuongHieu/"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewData["Loi"] = "Hình ảnh đã tồn tại";
                        return View();
                    }
                    else

                        fileUpload.SaveAs(path);
                    try
                    {
                        th.MaTH = ma;
                        th.TenTH = ten;
                        th.Images = fileName;
                        data.THUONG_HIEUs.InsertOnSubmit(th);
                        data.SubmitChanges();
                    }
                    catch (Exception)
                    {
                        ViewData["Loi"] = "Mã thương hiệu đã tồn tại.";
                        return View();
                    }
                    
                }
                return RedirectToAction("ThuongHieu");
            }
        }
        public ActionResult SuaThuongHieu(string id)
        {
            THUONG_HIEU sua = data.THUONG_HIEUs.First(m => m.MaTH == id);
            return View(sua);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaThuongHieu(string id,FormCollection c,HttpPostedFileBase file)
        {
           
            THUONG_HIEU sua = data.THUONG_HIEUs.First(m => m.MaTH == id);
            var ten = c["TenTH"];
            if (string.IsNullOrEmpty(ten))
                ViewData["Loi"] = "Tên thương hiệu không được để trống";
            if (file == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnh/ThuongHieu"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                        file.SaveAs(path);
                    sua.TenTH = ten;
                    sua.Images = fileName;
                    UpdateModel(sua);
                    data.SubmitChanges();
                    return RedirectToAction("ThuongHieu","Admin");
                }
                return this.SuaThuongHieu(id);
            }
        }
        public ActionResult ChiTietThuongHieu(string id)
        {
            var chitiet = data.THUONG_HIEUs.Where(m => m.MaTH == id).First();
            return View(chitiet);
            
        }
        public ActionResult XoaThuongHieu(string id)
        {
            var xoa = data.THUONG_HIEUs.First(m => m.MaTH == id);
            return View(xoa);
        }
        [HttpPost]
        public ActionResult XoaThuongHieu(string id, FormCollection c)
        {
            var kt = data.SAN_PHAMs.Where(t=>t.MaTH==id).Count();
            if(kt==0)
            {
                THUONG_HIEU xoa = data.THUONG_HIEUs.Where(t => t.MaTH == id).FirstOrDefault();
                data.THUONG_HIEUs.DeleteOnSubmit(xoa);
                data.SubmitChanges();
                return RedirectToAction("ThuongHieu");
            }
            else
            {
                return RedirectToAction("KhongTheXoa", "Admin");
            }
            
        }
        #endregion


        //------------------TIN TỨC----------------------
        public ActionResult TinTuc(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(data.TINs.ToList().OrderBy(n => n.MaTin).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ChiTietTinTuc(int id)
        {
            var chitiet = data.TINs.Where(m => m.MaTin == id).First();
            return View(chitiet);
        }
        [HttpGet]
        public ActionResult ThemTinTuc()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemTinTuc(FormCollection c, TIN t, HttpPostedFileBase file)
        {

            var tieude = c["TieuDe"];
            var hinh = c["Hinh"];
            var tt = c["TomTat"];
            var ngay = c["Ngay"];
            if (String.IsNullOrEmpty(tieude))
            {
                ViewData["Loi"] = "Tiêu đề tin không được để trống.";
            }
            else if (String.IsNullOrEmpty(tt))
            {
                ViewData["Loi1"] = "Bạn hãy nhập nội dung cho tin.";
            }
            else 
            if (file==null)
            {
                ViewData["Loi2"] = "Bạn hãy chọn hình tiêu biểu.";
            }
            else if (String.IsNullOrEmpty(ngay))
            {
                ViewData["Loi3"] = "Bạn hãy nhập ngày cập nhật.";
            }
            else if (!file.FileName.Contains(".jpg") && !file.FileName.Contains(".png") && !file.FileName.Contains(".img"))
            {
                ViewData["Loi2"] = "Vui lòng chèn đúng tệp hình";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/HinhAnh/Tin"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewData["Loi2"] = "Hình ảnh đã tồn tại";
                    else
                        file.SaveAs(path);
                    t.Hinh = file.FileName;
                    t.Ngay = DateTime.Parse(ngay);
                    t.TieuDe = tieude;
                    t.TomTat = tt;
                    t.MaTin = data.TINs.Count(m => m.MaTin != null);
                    data.TINs.InsertOnSubmit(t);
                    data.SubmitChanges();
                    /*sp.MASP = "MH" + data.SANPHAMs.Count(m => m.MASP != null);
                    data.SANPHAMs.InsertOnSubmit(sp);
                    data.SubmitChanges();*/
                }
                return RedirectToAction("TinTuc");
            }
            return this.ThemTinTuc();
        }

        public ActionResult SuaTinTuc(int id)
        {
            var ma = data.TINs.First(m => m.MaTin == id);
            return View(ma);
        }
        [HttpPost]
        public ActionResult SuaTinTuc(int id, FormCollection c)
        {
            var tieude = c["TieuDe"];
            var hinh = c["Hinh"];
            var tt = c["TomTat"];
            var ngay = c["Ngay"];
            var ma = data.TINs.First(m => m.MaTin == id);
            if (String.IsNullOrEmpty(tieude))
            {
                ViewData["Loi"] = "Tiêu đề tin không được để trống.";
            }
            else if (String.IsNullOrEmpty(tt))
            {
                ViewData["Loi1"] = "Bạn hãy nhập nội dung cho tin.";
            }
            else if (String.IsNullOrEmpty(hinh))
            {
                ViewData["Loi2"] = "Bạn hãy chọn hình tiêu biểu.";
            }
            else if (String.IsNullOrEmpty(ngay))
            {
                ViewData["Loi3"] = "Bạn hãy nhập ngày cập nhật.";
            }
            else
            {
                ma.Hinh = hinh;
                ma.Ngay = DateTime.Parse(ngay);
                ma.TieuDe = tieude;
                ma.TomTat = tt;
                UpdateModel(ma);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.SuaTinTuc(id);
        }

        public ActionResult XoaTinTuc(int id)
        {
            var t = data.TINs.First(m => m.MaTin == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult XoaTinTuc(int id, FormCollection c)
        {
            var tin = data.TINs.Where(m => m.MaTin == id).First();
            data.TINs.DeleteOnSubmit(tin);
            data.SubmitChanges();
            return RedirectToAction("TinTuc");
        }
    }
}
