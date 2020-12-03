using System;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class PayPalController : Controller
    {
        WebQA2Entities db = new WebQA2Entities();
        // GET: PayPal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThongBao(FormCollection f)
        {
            luuDonHang(f);
            luuChiTietDonHang();
            return View();
        }

        private void luuChiTietDonHang()
        {
            throw new NotImplementedException();
        }

        private void luuDonHang(FormCollection f)
        {
            DonHang donHang = new DonHang();
            donHang.TenNguoiNhan = f["PayerID"];
            donHang.NgayDat = DateTime.Now;
            donHang.DiaChi = f["DiaChi"];
            donHang.SoDT = f["SoDT"];
            db.DonHangs.Add(donHang);
            db.SaveChanges();
        }
    }
}