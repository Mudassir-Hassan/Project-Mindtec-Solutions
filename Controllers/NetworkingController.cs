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
    public class NetworkingController : Controller
    {
        private Networkingdbcontext db = new Networkingdbcontext();

        // GET: /Networking/
        public ActionResult Index()
        {
            return View(db.Networkings.ToList());
        }

        // GET: /Networking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Networking networking = db.Networkings.Find(id);
            if (networking == null)
            {
                return HttpNotFound();
            }
            return View(networking);
        }

        // GET: /Networking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Networking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,OrderDate,Description,OrderCompletion")] Networking networking)
        {
            if (ModelState.IsValid)
            {
                db.Networkings.Add(networking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(networking);
        }

        // GET: /Networking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Networking networking = db.Networkings.Find(id);
            if (networking == null)
            {
                return HttpNotFound();
            }
            return View(networking);
        }

        // POST: /Networking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,OrderDate,Description,OrderCompletion")] Networking networking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(networking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(networking);
        }

        // GET: /Networking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Networking networking = db.Networkings.Find(id);
            if (networking == null)
            {
                return HttpNotFound();
            }
            return View(networking);
        }

        // POST: /Networking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Networking networking = db.Networkings.Find(id);
            db.Networkings.Remove(networking);
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
