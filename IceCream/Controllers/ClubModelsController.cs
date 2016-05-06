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
    public class ClubModelsController : Controller
    {
        private IceCreamContext db = new IceCreamContext();

        // GET: ClubModels
        public ActionResult Index()
        {
            return View(db.ClubModels.ToList());
        }

        // GET: ClubModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubModel clubModel = db.ClubModels.Find(id);
            if (clubModel == null)
            {
                return HttpNotFound();
            }
            return View(clubModel);
        }

        // GET: ClubModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClubModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClubID")] ClubModel clubModel)
        {
            if (ModelState.IsValid)
            {
                db.ClubModels.Add(clubModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clubModel);
        }

        // GET: ClubModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubModel clubModel = db.ClubModels.Find(id);
            if (clubModel == null)
            {
                return HttpNotFound();
            }
            return View(clubModel);
        }

        // POST: ClubModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClubID")] ClubModel clubModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubModel);
        }

        // GET: ClubModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubModel clubModel = db.ClubModels.Find(id);
            if (clubModel == null)
            {
                return HttpNotFound();
            }
            return View(clubModel);
        }

        // POST: ClubModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubModel clubModel = db.ClubModels.Find(id);
            db.ClubModels.Remove(clubModel);
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
