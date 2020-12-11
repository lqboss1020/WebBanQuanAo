using System;
using System.Collections.Generic;
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
            return View();
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
            int maDH = donHang.MaDH;
            ViewBag.maDH = maDH;
            luuChiTietDonHang(maDH);
        }

        private void luuChiTietDonHang(int maDH)
        {
            foreach (var item in (List<Cart>)Session["Cart"])
            {
                ChiTietDonHang chiTietDon = new ChiTietDonHang()
                {
                    MaSP = item.SanPham.MaSP,
                    MaDonHang = maDH,
                    SoLuong = item.Quantity,
                    TongTien = item.Quantity * item.SanPham.GiaSP
                };
                db.ChiTietDonHangs.Add(chiTietDon);
                db.SaveChanges();
            }
        }
        public ActionResult HoaDonPayPal()
        {
            luuDonHangPayPal();
            return RedirectToAction("ThanhCong","DonHangs");
        }

        private void luuDonHangPayPal()
        {
            DateTime date = DateTime.Now;
            string id = date.ToString();
            DonHang donHang = new DonHang();
            donHang.TenNguoiNhan = "Paypal" + " " + id;
            donHang.NgayDat = DateTime.Now;
            db.DonHangs.Add(donHang);
            db.SaveChanges();
            int maDH = donHang.MaDH;
            ViewBag.maDH = maDH;
            luuChiTietDonHang(maDH);
        }
    }
}