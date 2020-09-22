using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

using NguyenThiPhuongUyen_2001170230_doAn.Models;
namespace NguyenThiPhuongUyen_2001170230_doAn.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var s = LaySanPham(21);
            return View(s.ToPagedList(pageNum, pageSize));
        }
        public List<SAN_PHAM> LaySanPham(int count)
        {
            return data.SAN_PHAMs.OrderByDescending(n => n.MaLoaiSP).Take(count).ToList();
        }
        public List<THUONG_HIEU> LayThuongHieu(int count)
        {
            return data.THUONG_HIEUs.OrderByDescending(n => n.MaTH).Take(count).ToList();
        }
        public ActionResult ThuongHieuPartial()
        {
            var t = LayThuongHieu(8);
            return PartialView(t);
        }
        public ActionResult lienHe()
        {
            return View();
        }
    }
}
