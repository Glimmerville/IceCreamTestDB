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
    public class FlavorsModelsController : Controller
    {
        private IceCreamContext db = new IceCreamContext();

        // GET: FlavorsModels
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "flavor_desc" : "";
           // ViewBag.NutSortParm = sortOrder == "Limited" ? "LimtedEd" : "Limited";
            var flavors = from s in db.FlavorsModels
                          select s;
            switch (sortOrder)
            {
                case "flavor_desc":
                    flavors = flavors.OrderByDescending(s => s.Flavor);
                    break;
                //case "Limited":
                //    flavors = flavors.OrderBy(s => s.LimtedEd);
                //    break;
                default:
                    flavors = flavors.OrderBy(s => s.BestSeller);
                    break;

            }
            return View(flavors.ToList());
        }
        //{
        //    return View(db.FlavorsModels.ToList());
        //}

        // GET: FlavorsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlavorsModel flavorsModel = db.FlavorsModels.Find(id);
            if (flavorsModel == null)
            {
                return HttpNotFound();
            }
            return View(flavorsModel);
        }

        // GET: FlavorsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlavorsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlavorID,Flavor,FlavorDesc,LimtedEd,CurrentlyAvail,BestSeller,ContainsNuts")] FlavorsModel flavorsModel)
        {
            if (ModelState.IsValid)
            {
                db.FlavorsModels.Add(flavorsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flavorsModel);
        }

        // GET: FlavorsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlavorsModel flavorsModel = db.FlavorsModels.Find(id);
            if (flavorsModel == null)
            {
                return HttpNotFound();
            }
            return View(flavorsModel);
        }

        // POST: FlavorsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlavorID,Flavor,FlavorDesc,LimtedEd,CurrentlyAvail,BestSeller,ContainsNuts")] FlavorsModel flavorsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flavorsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flavorsModel);
        }

        // GET: FlavorsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlavorsModel flavorsModel = db.FlavorsModels.Find(id);
            if (flavorsModel == null)
            {
                return HttpNotFound();
            }
            return View(flavorsModel);
        }

        // POST: FlavorsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlavorsModel flavorsModel = db.FlavorsModels.Find(id);
            db.FlavorsModels.Remove(flavorsModel);
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
