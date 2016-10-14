using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreCell.EntityFramework;
using StoreCell.Models;

namespace StoreCell.Controllers
{
    public class ProviProductsController : Controller
    {
        private StoreCellContext db = new StoreCellContext();

        // GET: ProviProducts
        public ActionResult Index()
        {
            return View(db.ProviProducts.ToList());
        }

        // GET: ProviProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviProduct proviProduct = db.ProviProducts.Find(id);
            if (proviProduct == null)
            {
                return HttpNotFound();
            }
            return View(proviProduct);
        }

        // GET: ProviProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProviProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPP,IDProvider,IDProduct,Date,Amount")] ProviProduct proviProduct)
        {
            if (ModelState.IsValid)
            {
                db.ProviProducts.Add(proviProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proviProduct);
        }

        // GET: ProviProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviProduct proviProduct = db.ProviProducts.Find(id);
            if (proviProduct == null)
            {
                return HttpNotFound();
            }
            return View(proviProduct);
        }

        // POST: ProviProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPP,IDProvider,IDProduct,Date,Amount")] ProviProduct proviProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proviProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proviProduct);
        }

        // GET: ProviProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviProduct proviProduct = db.ProviProducts.Find(id);
            if (proviProduct == null)
            {
                return HttpNotFound();
            }
            return View(proviProduct);
        }

        // POST: ProviProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProviProduct proviProduct = db.ProviProducts.Find(id);
            db.ProviProducts.Remove(proviProduct);
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
