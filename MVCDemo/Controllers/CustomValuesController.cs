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
    public class CustomValuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomValues
        public ActionResult Index()
        {
            var customValue = db.CustomValue.Include(c => c.CustomField);
            return View(customValue.ToList());
        }

        // GET: CustomValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomValue customValue = db.CustomValue.Find(id);
            if (customValue == null)
            {
                return HttpNotFound();
            }
            return View(customValue);
        }

        // GET: CustomValues/Create
        public ActionResult Create()
        {
            ViewBag.CustomFieldId = new SelectList(db.CustomField, "Id", "FieldName");
            return View();
        }

        // POST: CustomValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value,CustomFieldId")] CustomValue customValue)
        {
            if (ModelState.IsValid)
            {
                db.CustomValue.Add(customValue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomFieldId = new SelectList(db.CustomField, "Id", "FieldName", customValue.CustomFieldId);
            return View(customValue);
        }

        // GET: CustomValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomValue customValue = db.CustomValue.Find(id);
            if (customValue == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomFieldId = new SelectList(db.CustomField, "Id", "FieldName", customValue.CustomFieldId);
            return View(customValue);
        }

        // POST: CustomValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value,CustomFieldId")] CustomValue customValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customValue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomFieldId = new SelectList(db.CustomField, "Id", "FieldName", customValue.CustomFieldId);
            return View(customValue);
        }

        // GET: CustomValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomValue customValue = db.CustomValue.Find(id);
            if (customValue == null)
            {
                return HttpNotFound();
            }
            return View(customValue);
        }

        // POST: CustomValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomValue customValue = db.CustomValue.Find(id);
            db.CustomValue.Remove(customValue);
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
