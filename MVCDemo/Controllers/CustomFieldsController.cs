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
    public class CustomFieldsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomFields
        public ActionResult Index()
        {
            var customField = db.CustomField.Include(c => c.DemoClass);
            return View(customField.ToList());
        }

        // GET: CustomFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomField customField = db.CustomField.Find(id);
            if (customField == null)
            {
                return HttpNotFound();
            }
            return View(customField);
        }

        // GET: CustomFields/Create
        public ActionResult Create()
        {
            ViewBag.DemoClassId = new SelectList(db.DemoClass, "Id", "FirstName");
            return View();
        }

        // POST: CustomFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FieldName,DemoClassId,IsCheckBox,IsTextBox,IsInt")] CustomField customField)
        {
            if (ModelState.IsValid)
            {
                db.CustomField.Add(customField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DemoClassId = new SelectList(db.DemoClass, "Id", "FirstName", customField.DemoClassId);
            return View(customField);
        }

        // GET: CustomFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomField customField = db.CustomField.Find(id);
            if (customField == null)
            {
                return HttpNotFound();
            }
            ViewBag.DemoClassId = new SelectList(db.DemoClass, "Id", "FirstName", customField.DemoClassId);
            return View(customField);
        }

        // POST: CustomFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FieldName,DemoClassId,IsCheckBox,IsTextBox,IsInt")] CustomField customField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DemoClassId = new SelectList(db.DemoClass, "Id", "FirstName", customField.DemoClassId);
            return View(customField);
        }

        // GET: CustomFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomField customField = db.CustomField.Find(id);
            if (customField == null)
            {
                return HttpNotFound();
            }
            return View(customField);
        }

        // POST: CustomFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomField customField = db.CustomField.Find(id);
            db.CustomField.Remove(customField);
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
