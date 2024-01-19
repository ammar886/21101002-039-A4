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
    public class M_AdminController : Controller
    {
        private Model1 db = new Model1();

        // GET: M_Admin
        public ActionResult Index()
        {
            return View(db.M_Admin.ToList());
        }

        // GET: M_Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Admin m_Admin = db.M_Admin.Find(id);
            if (m_Admin == null)
            {
                return HttpNotFound();
            }
            return View(m_Admin);
        }

        // GET: M_Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: M_Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Admin_ID,Admin_Name,Admin_Email,Admin_Password,Admin_Contact,Admin_Address")] M_Admin m_Admin)
        {
            if (ModelState.IsValid)
            {
                db.M_Admin.Add(m_Admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(m_Admin);
        }

        // GET: M_Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Admin m_Admin = db.M_Admin.Find(id);
            if (m_Admin == null)
            {
                return HttpNotFound();
            }
            return View(m_Admin);
        }

        // POST: M_Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Admin_ID,Admin_Name,Admin_Email,Admin_Password,Admin_Contact,Admin_Address")] M_Admin m_Admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_Admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m_Admin);
        }

        // GET: M_Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Admin m_Admin = db.M_Admin.Find(id);
            if (m_Admin == null)
            {
                return HttpNotFound();
            }
            return View(m_Admin);
        }

        // POST: M_Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            M_Admin m_Admin = db.M_Admin.Find(id);
            db.M_Admin.Remove(m_Admin);
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
