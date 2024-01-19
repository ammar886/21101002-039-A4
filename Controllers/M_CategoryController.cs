using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using e_commerce.Models;

namespace e_commerce.Controllers
{
    public class M_CategoryController : Controller
    {
        private Model1 db = new Model1();

        // GET: M_Category
        public ActionResult Index()
        {
            return View(db.M_Category.ToList());
        }

        // GET: M_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Category m_Category = db.M_Category.Find(id);
            if (m_Category == null)
            {
                return HttpNotFound();
            }
            return View(m_Category);
        }

        // GET: M_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: M_Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category_ID,Category_Name")] M_Category m_Category)
        {
            if (ModelState.IsValid)
            {
                db.M_Category.Add(m_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(m_Category);
        }

        // GET: M_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Category m_Category = db.M_Category.Find(id);
            if (m_Category == null)
            {
                return HttpNotFound();
            }
            return View(m_Category);
        }

        // POST: M_Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_ID,Category_Name")] M_Category m_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m_Category);
        }

        // GET: M_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Category m_Category = db.M_Category.Find(id);
            if (m_Category == null)
            {
                return HttpNotFound();
            }
            return View(m_Category);
        }

        // POST: M_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            M_Category m_Category = db.M_Category.Find(id);
            db.M_Category.Remove(m_Category);
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
