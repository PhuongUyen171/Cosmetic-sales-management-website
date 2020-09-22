using System.Web;
using System.Web.Mvc;

namespace NguyenThiPhuongUyen_2001170230_doAn
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}