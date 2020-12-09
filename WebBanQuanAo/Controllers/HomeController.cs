using System.Linq;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class HomeController : Controller
    {
        WebQA2Entities db = new WebQA2Entities();
        public ActionResult Index()
        {
            //if (Session["Admin"]==null)
            //{
            //    return RedirectToAction("Login","Admins");
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetData()
        {
            var ds = db.ChiTietDonHangs
                   .GroupBy(p => p.SanPham.TenSP)
                   .Select(s => new { name = s.Key, y = s.Sum(w => w.SoLuong) }).ToList();
            return Json(ds, JsonRequestBehavior.AllowGet);
        }
    }
}