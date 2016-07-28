using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class DemoClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DemoClasses
        public ActionResult Index()
        {
            return View(db.DemoClass.ToList());
        }

        // GET: DemoClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoClass demoClass = db.DemoClass.Find(id);
            if (demoClass == null)
            {
                return HttpNotFound();
            }
            return View(demoClass);
        }

        // GET: DemoClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DemoClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Date,IsTrue")] DemoClass demoClass)
        {
            if (ModelState.IsValid)
            {
                db.DemoClass.Add(demoClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demoClass);
        }

        // GET: DemoClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoClass demoClass = db.DemoClass.Find(id);
            if (demoClass == null)
            {
                return HttpNotFound();
            }
            return View(demoClass);
        }

        // POST: DemoClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Date,IsTrue")] DemoClass demoClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demoClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demoClass);
        }

        // GET: DemoClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoClass demoClass = db.DemoClass.Find(id);
            if (demoClass == null)
            {
                return HttpNotFound();
            }
            return View(demoClass);
        }

        // POST: DemoClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemoClass demoClass = db.DemoClass.Find(id);
            db.DemoClass.Remove(demoClass);
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
