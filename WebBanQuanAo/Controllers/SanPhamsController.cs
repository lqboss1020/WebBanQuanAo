using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class SanPhamsController : Controller
    {
        private WebQA2Entities db = new WebQA2Entities();

        // GET: SanPhams
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.DanhMuc).Include(s => s.NhaCungCap);
            return View(sanPhams.ToList());
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,MaNCC,TenSP,MauSac,HinhSP,GiaSP,MoTa,MaDM")] SanPham sanPham, HttpPostedFileBase HinhSP)
        {
            if (ModelState.IsValid)
            {
                if (HinhSP != null)
                {
                    var filename = Path.GetFileName(HinhSP.FileName);
                    sanPham.HinhSP = filename;
                    string path = Path.Combine(Server.MapPath("~/Images"), filename);
                    HinhSP.SaveAs(path);

                }
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM", sanPham.MaDM);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPham.MaNCC);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM", sanPham.MaDM);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPham.MaNCC);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,MaNCC,TenSP,MauSac,HinhSP,GiaSP,MoTa,MaDM")] SanPham sanPham, HttpPostedFileBase HinhSP)
        {
            if (ModelState.IsValid)
            {
                if (HinhSP != null)
                {
                    var filename = Path.GetFileName(HinhSP.FileName);
                    sanPham.HinhSP = filename;
                    string path = Path.Combine(Server.MapPath("~/Images"), filename);
                    HinhSP.SaveAs(path);

                }
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM", sanPham.MaDM);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPham.MaNCC);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
        public ActionResult List(string TenSP, string TenDM)
        {
            var sanPham = db.SanPhams.Include(s => s.DanhMuc).Include(s => s.NhaCungCap);
            if (!String.IsNullOrEmpty(TenSP))
            {
                sanPham = sanPham.Where(s => s.TenSP.Contains(TenSP));
            }
            if (!string.IsNullOrEmpty(TenDM))
            {
                sanPham = sanPham.Where(s => s.DanhMuc.TenDM.Contains(TenDM));
            }
            return View(sanPham.ToList());
        }
    }
}
