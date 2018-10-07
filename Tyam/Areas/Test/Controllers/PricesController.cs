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
    public class PricesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Test/Prices
        public ActionResult Index()
        {
            var prices = db.Prices.Include(p => p.Products);
            return View(prices.ToList());
        }

        // GET: Test/Prices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prices prices = db.Prices.Find(id);
            if (prices == null)
            {
                return HttpNotFound();
            }
            return View(prices);
        }

        // GET: Test/Prices/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title");
            return View();
        }

        // POST: Test/Prices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductID,Date,Price")] Prices prices)
        {
            if (ModelState.IsValid)
            {
                db.Prices.Add(prices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title", prices.ProductID);
            return View(prices);
        }

        // GET: Test/Prices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prices prices = db.Prices.Find(id);
            if (prices == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title", prices.ProductID);
            return View(prices);
        }

        // POST: Test/Prices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductID,Date,Price")] Prices prices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title", prices.ProductID);
            return View(prices);
        }

        // GET: Test/Prices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prices prices = db.Prices.Find(id);
            if (prices == null)
            {
                return HttpNotFound();
            }
            return View(prices);
        }

        // POST: Test/Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prices prices = db.Prices.Find(id);
            db.Prices.Remove(prices);
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
