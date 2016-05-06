using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IceCream.Models;

namespace IceCream.Controllers
{
    public class FlavorToCustomerLinksController : Controller
    {
        private IceCreamContext db = new IceCreamContext();

        // GET: FlavorToCustomerLinks
        public ActionResult Index()
        {
            var flavorToCustomerLinks = db.FlavorToCustomerLinks.Include(f => f.CustomerLink).Include(f => f.FlavorLink);
            return View(flavorToCustomerLinks.ToList());
        }

        // GET: FlavorToCustomerLinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlavorToCustomerLink flavorToCustomerLink = db.FlavorToCustomerLinks.Find(id);
            if (flavorToCustomerLink == null)
            {
                return HttpNotFound();
            }
            return View(flavorToCustomerLink);
        }

        // GET: FlavorToCustomerLinks/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.CustomerModels, "CustomerId", "FirstName");
            ViewBag.FlavorID = new SelectList(db.FlavorsModels, "FlavorID", "Flavor");
            return View();
        }

        // POST: FlavorToCustomerLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlavorToCustomerLinkID,CustomerID,FlavorID,Sprinkles,ToGo,ConeID")] FlavorToCustomerLink flavorToCustomerLink)
        {
            if (ModelState.IsValid)
            {
                db.FlavorToCustomerLinks.Add(flavorToCustomerLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.CustomerModels, "CustomerId", "FirstName", flavorToCustomerLink.CustomerID);
            ViewBag.FlavorID = new SelectList(db.FlavorsModels, "FlavorID", "Flavor", flavorToCustomerLink.FlavorID);
            return View(flavorToCustomerLink);
        }

        // GET: FlavorToCustomerLinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlavorToCustomerLink flavorToCustomerLink = db.FlavorToCustomerLinks.Find(id);
            if (flavorToCustomerLink == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.CustomerModels, "CustomerId", "FirstName", flavorToCustomerLink.CustomerID);
            ViewBag.FlavorID = new SelectList(db.FlavorsModels, "FlavorID", "Flavor", flavorToCustomerLink.FlavorID);
            return View(flavorToCustomerLink);
        }

        // POST: FlavorToCustomerLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlavorToCustomerLinkID,CustomerID,FlavorID,Sprinkles,ToGo,ConeID")] FlavorToCustomerLink flavorToCustomerLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flavorToCustomerLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.CustomerModels, "CustomerId", "FirstName", flavorToCustomerLink.CustomerID);
            ViewBag.FlavorID = new SelectList(db.FlavorsModels, "FlavorID", "Flavor", flavorToCustomerLink.FlavorID);
            return View(flavorToCustomerLink);
        }

        // GET: FlavorToCustomerLinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlavorToCustomerLink flavorToCustomerLink = db.FlavorToCustomerLinks.Find(id);
            if (flavorToCustomerLink == null)
            {
                return HttpNotFound();
            }
            return View(flavorToCustomerLink);
        }

        // POST: FlavorToCustomerLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlavorToCustomerLink flavorToCustomerLink = db.FlavorToCustomerLinks.Find(id);
            db.FlavorToCustomerLinks.Remove(flavorToCustomerLink);
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
