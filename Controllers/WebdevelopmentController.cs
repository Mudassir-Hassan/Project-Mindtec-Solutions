using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mindtek.Models;

namespace Mindtek.Controllers
{
    public class WebdevelopmentController : Controller
    {
        private Webdevelopmentdbcontext db = new Webdevelopmentdbcontext();

        // GET: /Webdevelopment/
        public ActionResult Index()
        {
            return View(db.Webdesigns.ToList());
        }

        // GET: /Webdevelopment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webdevelopment webdevelopment = db.Webdesigns.Find(id);
            if (webdevelopment == null)
            {
                return HttpNotFound();
            }
            return View(webdevelopment);
        }

        // GET: /Webdevelopment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Webdevelopment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,OrderDate,Description,OrderCompletion")] Webdevelopment webdevelopment)
        {
            if (ModelState.IsValid)
            {
                db.Webdesigns.Add(webdevelopment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webdevelopment);
        }

        // GET: /Webdevelopment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webdevelopment webdevelopment = db.Webdesigns.Find(id);
            if (webdevelopment == null)
            {
                return HttpNotFound();
            }
            return View(webdevelopment);
        }

        // POST: /Webdevelopment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,OrderDate,Description,OrderCompletion")] Webdevelopment webdevelopment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webdevelopment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webdevelopment);
        }

        // GET: /Webdevelopment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webdevelopment webdevelopment = db.Webdesigns.Find(id);
            if (webdevelopment == null)
            {
                return HttpNotFound();
            }
            return View(webdevelopment);
        }

        // POST: /Webdevelopment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Webdevelopment webdevelopment = db.Webdesigns.Find(id);
            db.Webdesigns.Remove(webdevelopment);
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
