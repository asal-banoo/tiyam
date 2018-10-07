using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Tyam.Areas.Test.Controllers
{
    public class ServersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Test/Servers
        public ActionResult Index()
        {
            return View(db.Servers.ToList());
        }

        // GET: Test/Servers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servers servers = db.Servers.Find(id);
            if (servers == null)
            {
                return HttpNotFound();
            }
            return View(servers);
        }

        // GET: Test/Servers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Servers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Path")] Servers servers)
        {
            if (ModelState.IsValid)
            {
                db.Servers.Add(servers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servers);
        }

        // GET: Test/Servers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servers servers = db.Servers.Find(id);
            if (servers == null)
            {
                return HttpNotFound();
            }
            return View(servers);
        }

        // POST: Test/Servers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Path")] Servers servers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servers);
        }

        // GET: Test/Servers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servers servers = db.Servers.Find(id);
            if (servers == null)
            {
                return HttpNotFound();
            }
            return View(servers);
        }

        // POST: Test/Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servers servers = db.Servers.Find(id);
            db.Servers.Remove(servers);
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
