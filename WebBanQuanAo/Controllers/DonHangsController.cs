using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class DonHangsController : Controller
    {
        private WebQA2Entities db = new WebQA2Entities();

        // GET: DonHangs
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Include(d => d.KhachHang).Include(d => d.NhanVien);
            return View(donHangs.ToList());
        }

        // GET: DonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // GET: DonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,MaKH,MaNV,TenNguoiNhan,SoDT,DiaChi,NgayDat,TinhTrang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", donHang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", donHang.MaNV);
            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", donHang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", donHang.MaNV);
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,MaKH,MaNV,TenNguoiNhan,SoDT,DiaChi,NgayDat,TinhTrang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", donHang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", donHang.MaNV);
            return View(donHang);
        }

        // GET: DonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult HoaDon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HoaDon(FormCollection f)
        {
            luuDonHang(f);
            return View("ThanhCong");
        }
        private void luuDonHang(FormCollection f)
        {
            DonHang donHang = new DonHang();
            if (Session["MaKH"] !=null)
            {
                donHang.MaKH = (int)Session["MaKH"];
            }
            donHang.TenNguoiNhan = f["TenNguoiNhan"];
            donHang.NgayDat = DateTime.Now;
            donHang.DiaChi = f["DiaChi"];
            donHang.SoDT = f["SoDT"];
            donHang.TinhTrang = "Xác Nhận";
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

        public ActionResult ThanhCong()
        {
            
            return View();
        }
    }
}
