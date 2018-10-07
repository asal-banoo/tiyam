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
    public class ImagesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Test/Images
        public ActionResult Index()
        {
            var image = db.Image.Include(i => i.Products).Include(i => i.Server);
            return View(image.ToList());
        }

        // GET: Test/Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Image.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Test/Images/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title");
            ViewBag.ServerID = new SelectList(db.Servers, "ID", "Title");
            return View();
        }

        // POST: Test/Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ServerID,ProductID,Title,FileName,Alt")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Image.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title", image.ProductID);
            ViewBag.ServerID = new SelectList(db.Servers, "ID", "Title", image.ServerID);
            return View(image);
        }

        // GET: Test/Images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Image.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title", image.ProductID);
            ViewBag.ServerID = new SelectList(db.Servers, "ID", "Title", image.ServerID);
            return View(image);
        }

        // POST: Test/Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ServerID,ProductID,Title,FileName,Alt")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title", image.ProductID);
            ViewBag.ServerID = new SelectList(db.Servers, "ID", "Title", image.ServerID);
            return View(image);
        }

        // GET: Test/Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Image.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Test/Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Image.Find(id);
            db.Image.Remove(image);
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
