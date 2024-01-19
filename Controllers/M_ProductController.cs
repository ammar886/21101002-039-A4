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
    public class M_ProductController : Controller
    {
        private Model1 db = new Model1();

        // GET: M_Product
        public ActionResult Index()
        {
            var m_Product = db.M_Product.Include(m => m.M_Category);
            return View(m_Product.ToList());
        }

        // GET: M_Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Product m_Product = db.M_Product.Find(id);
            if (m_Product == null)
            {
                return HttpNotFound();
            }
            return View(m_Product);
        }

        // GET: M_Product/Create
        public ActionResult Create()
        {
            ViewBag.Product_Category_FID = new SelectList(db.M_Category, "Category_ID", "Category_Name");
            return View();
        }

        // POST: M_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(M_Product m_Product)
        {
            if (ModelState.IsValid)
            {
                m_Product.A_img.SaveAs(Server.MapPath("~/P_Images/" + m_Product.A_img.FileName));
                m_Product.Product_Picture = "~/P_Images/"+m_Product.A_img.FileName;
                db.M_Product.Add(m_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_Category_FID = new SelectList(db.M_Category, "Category_ID", "Category_Name", m_Product.Product_Category_FID);
            return View(m_Product);
        }

        // GET: M_Product/Edit/5
        public ActionResult Edit(int? id)
        {
           
            M_Product m_Product = db.M_Product.Find(id);
            ViewBag.Product_Category_FID = new SelectList(db.M_Category, "Category_ID", "Category_Name", m_Product.Product_Category_FID);
            return View(m_Product);
        }

        // POST: M_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(M_Product m_Product)
        {
            if (ModelState.IsValid)
            {
                if (m_Product.A_img != null)
                {
                    m_Product.A_img.SaveAs(Server.MapPath("~/P_Images/" + m_Product.A_img.FileName));
                    m_Product.Product_Picture = "~/P_Images/" + m_Product.A_img.FileName;
                }

                db.Entry(m_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_Category_FID = new SelectList(db.M_Category, "Category_ID", "Category_Name", m_Product.Product_Category_FID);
            return View(m_Product);
        }

        // GET: M_Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Product m_Product = db.M_Product.Find(id);
            if (m_Product == null)
            {
                return HttpNotFound();
            }
            return View(m_Product);
        }

        // POST: M_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            M_Product m_Product = db.M_Product.Find(id);
            db.M_Product.Remove(m_Product);
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
