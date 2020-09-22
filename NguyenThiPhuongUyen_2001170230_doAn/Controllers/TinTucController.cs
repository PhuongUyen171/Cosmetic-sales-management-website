using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenThiPhuongUyen_2001170230_doAn.Models;
using System.IO;
namespace NguyenThiPhuongUyen_2001170230_doAn.Controllers
{
    public class TinTucController : Controller
    {
        //
        // GET: /TinTuc/

        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<TIN> LayTinTuc(int count)
        {
            var ds = data.TINs.Take(count).ToList();
            return ds;
        }
        public ActionResult TinTucPartial()
        {
            var ds = data.TINs.Take(3).ToList();
            return PartialView(ds);
        }
        public ActionResult Index()
        {
            var tatca = LayTinTuc(6);
            if (tatca == null)
                return RedirectToAction("ThemTinTuc", "TinTuc");
            return View(tatca);
        }

        public ActionResult ChiTiet(int id)
        {
            TIN chiTiet = data.TINs.Where(m => m.MaTin == id).First();
            return View(chiTiet);
        }
        
    }
}
      
