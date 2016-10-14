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
    public class RegisterProductsController : Controller
    {
        private StoreCellContext db = new StoreCellContext();

        // GET: RegisterProducts
        public ActionResult Index()
        {
            return View(db.RegiisterProducts.ToList());
        }

        // GET: RegisterProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterProduct registerProduct = db.RegiisterProducts.Find(id);
            if (registerProduct == null)
            {
                return HttpNotFound();
            }
            return View(registerProduct);
        }

        // GET: RegisterProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Brand,Version")] RegisterProduct registerProduct)
        {
            if (ModelState.IsValid)
            {
                db.RegiisterProducts.Add(registerProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registerProduct);
        }

        // GET: RegisterProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterProduct registerProduct = db.RegiisterProducts.Find(id);
            if (registerProduct == null)
            {
                return HttpNotFound();
            }
            return View(registerProduct);
        }

        // POST: RegisterProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Brand,Version")] RegisterProduct registerProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerProduct);
        }

        // GET: RegisterProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterProduct registerProduct = db.RegiisterProducts.Find(id);
            if (registerProduct == null)
            {
                return HttpNotFound();
            }
            return View(registerProduct);
        }

        // POST: RegisterProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterProduct registerProduct = db.RegiisterProducts.Find(id);
            db.RegiisterProducts.Remove(registerProduct);
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
