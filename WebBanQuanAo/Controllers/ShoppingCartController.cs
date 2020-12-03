using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class ShoppingCartController : Controller
    {
        private WebQA2Entities db = new WebQA2Entities();
        string sChiTietDonHang = "ChiTietDonHang";
        // GET: ShoppingChiTietDonHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Del(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int check = isExistingCheck(id);
            var ChiTietDonHangs = (List<ChiTietDonHang>)Session[sChiTietDonHang];
            ChiTietDonHangs.RemoveAt(check);
            return View("index");
        }
        public ActionResult Clear()
        {
            Session.Remove(sChiTietDonHang);
            return RedirectToAction("list", "SanPhams");
        }
        public ActionResult Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                if (Session[sChiTietDonHang] == null)
                {
                    List<ChiTietDonHang> ChiTietDonHangs = new List<ChiTietDonHang>
                    {
                       new ChiTietDonHang(db.SanPhams.Find(id),1)
                    };
                    Session[sChiTietDonHang] = ChiTietDonHangs;
                }
                else
                {
                    var ChiTietDonHang = (List<ChiTietDonHang>)Session[sChiTietDonHang];
                    int check = isExistingCheck(id);
                    if (check == -1)
                    {
                        ChiTietDonHang.Add(new ChiTietDonHang(db.SanPhams.Find(id), 1));
                    }
                    else
                    {
                        ChiTietDonHang[check].SoLuong++;
                    }
                    Session[sChiTietDonHang] = ChiTietDonHang;
                }
                return RedirectToAction("index");
            }
        }
        private int isExistingCheck(int? id)
        {
            List<ChiTietDonHang> ChiTietDonHangs = Session[sChiTietDonHang] as List<ChiTietDonHang>;
            for (int i = 0; i < ChiTietDonHangs.Count; i++)
            {
                if (ChiTietDonHangs[i].SanPham.MaSP == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}