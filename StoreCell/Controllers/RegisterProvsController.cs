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
    public class RegisterProvsController : Controller
    {
        private StoreCellContext db = new StoreCellContext();

        // GET: RegisterProvs
        public ActionResult Index()
        {
            return View(db.RegisterProvs.ToList());
        }

        // GET: RegisterProvs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterProv registerProv = db.RegisterProvs.Find(id);
            if (registerProv == null)
            {
                return HttpNotFound();
            }
            return View(registerProv);
        }

        // GET: RegisterProvs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterProvs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvID,ProvName,ProvEmail,ProvPhone")] RegisterProv registerProv)
        {
            if (ModelState.IsValid)
            {
                db.RegisterProvs.Add(registerProv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registerProv);
        }

        // GET: RegisterProvs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterProv registerProv = db.RegisterProvs.Find(id);
            if (registerProv == null)
            {
                return HttpNotFound();
            }
            return View(registerProv);
        }

        // POST: RegisterProvs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvID,ProvName,ProvEmail,ProvPhone")] RegisterProv registerProv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerProv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerProv);
        }

        // GET: RegisterProvs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterProv registerProv = db.RegisterProvs.Find(id);
            if (registerProv == null)
            {
                return HttpNotFound();
            }
            return View(registerProv);
        }

        // POST: RegisterProvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterProv registerProv = db.RegisterProvs.Find(id);
            db.RegisterProvs.Remove(registerProv);
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
