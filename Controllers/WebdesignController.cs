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
    public class WebdesignController : Controller
    {
        private Webdesigndbcontext db = new Webdesigndbcontext();

        // GET: /Webdesign/
        public ActionResult Index(string searchstring)

        {
            var Webdesign = from d in db.Webdesigns
                            select d;
            if(!String.IsNullOrEmpty(searchstring))
            {
                Webdesign = Webdesign.Where(s => s.Name.Contains(searchstring));
            }
            return View("Index",Webdesign);
        }

        // GET: /Webdesign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webdesign webdesign = db.Webdesigns.Find(id);
            if (webdesign == null)
            {
                return HttpNotFound();
            }
            return View(webdesign);
        }

        // GET: /Webdesign/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Webdesign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,OrderDate,Description,OrderCompletion")] Webdesign webdesign)
        {
            if (ModelState.IsValid)
            {
                db.Webdesigns.Add(webdesign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webdesign);
        }

        // GET: /Webdesign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webdesign webdesign = db.Webdesigns.Find(id);
            if (webdesign == null)
            {
                return HttpNotFound();
            }
            return View(webdesign);
        }

        // POST: /Webdesign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,OrderDate,Description,OrderCompletion")] Webdesign webdesign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webdesign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webdesign);
        }

        // GET: /Webdesign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webdesign webdesign = db.Webdesigns.Find(id);
            if (webdesign == null)
            {
                return HttpNotFound();
            }
            return View(webdesign);
        }

        // POST: /Webdesign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Webdesign webdesign = db.Webdesigns.Find(id);
            db.Webdesigns.Remove(webdesign);
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
