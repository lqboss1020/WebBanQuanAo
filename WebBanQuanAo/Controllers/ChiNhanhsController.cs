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
    public class ChiNhanhsController : Controller
    {
        private WebQA2Entities db = new WebQA2Entities();

        // GET: ChiNhanhs
        public ActionResult Index()
        {
            return View(db.ChiNhanhs.ToList());
        }

        // GET: ChiNhanhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiNhanh chiNhanh = db.ChiNhanhs.Find(id);
            if (chiNhanh == null)
            {
                return HttpNotFound();
            }
            return View(chiNhanh);
        }

        // GET: ChiNhanhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiNhanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCN,TenCN,DiaChi,SoDT")] ChiNhanh chiNhanh)
        {
            if (ModelState.IsValid)
            {
                db.ChiNhanhs.Add(chiNhanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chiNhanh);
        }

        // GET: ChiNhanhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiNhanh chiNhanh = db.ChiNhanhs.Find(id);
            if (chiNhanh == null)
            {
                return HttpNotFound();
            }
            return View(chiNhanh);
        }

        // POST: ChiNhanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCN,TenCN,DiaChi,SoDT")] ChiNhanh chiNhanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiNhanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiNhanh);
        }

        // GET: ChiNhanhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiNhanh chiNhanh = db.ChiNhanhs.Find(id);
            if (chiNhanh == null)
            {
                return HttpNotFound();
            }
            return View(chiNhanh);
        }

        // POST: ChiNhanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiNhanh chiNhanh = db.ChiNhanhs.Find(id);
            db.ChiNhanhs.Remove(chiNhanh);
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
