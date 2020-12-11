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
    public class ChiTietDonHangsController : Controller
    {
        private WebQA2Entities db = new WebQA2Entities();

        // GET: ChiTietDonHangs
        public ActionResult Index()
        {
            var chiTietDonHangs = db.ChiTietDonHangs.Include(c => c.DonHang).Include(c => c.SanPham);
            return View(chiTietDonHangs.ToList());
        }

        // GET: ChiTietDonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaDonHang = new SelectList(db.DonHangs, "MaDH", "TenNguoiNhan");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            return View();
        }

        // POST: ChiTietDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,MaDonHang,SoLuong,TongTien")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDonHangs.Add(chiTietDonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDonHang = new SelectList(db.DonHangs, "MaDH", "TenNguoiNhan", chiTietDonHang.MaDonHang);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", chiTietDonHang.MaSP);
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDonHang = new SelectList(db.DonHangs, "MaDH", "TenNguoiNhan", chiTietDonHang.MaDonHang);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", chiTietDonHang.MaSP);
            return View(chiTietDonHang);
        }

        // POST: ChiTietDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,MaDonHang,SoLuong,TongTien")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDonHang = new SelectList(db.DonHangs, "MaDH", "TenNguoiNhan", chiTietDonHang.MaDonHang);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", chiTietDonHang.MaSP);
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // POST: ChiTietDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            db.ChiTietDonHangs.Remove(chiTietDonHang);
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
    }
}
