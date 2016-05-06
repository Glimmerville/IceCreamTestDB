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
    public class ConeModelsController : Controller
    {
        private IceCreamContext db = new IceCreamContext();

        // GET: ConeModels
        public ActionResult Index()
        {
            return View(db.ConeModels.ToList());
        }

        // GET: ConeModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConeModel coneModel = db.ConeModels.Find(id);
            if (coneModel == null)
            {
                return HttpNotFound();
            }
            return View(coneModel);
        }

        // GET: ConeModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConeID,ConeStyleList")] ConeModel coneModel)
        {
            if (ModelState.IsValid)
            {
                db.ConeModels.Add(coneModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coneModel);
        }

        // GET: ConeModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConeModel coneModel = db.ConeModels.Find(id);
            if (coneModel == null)
            {
                return HttpNotFound();
            }
            return View(coneModel);
        }

        // POST: ConeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConeID,ConeStyleList")] ConeModel coneModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coneModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coneModel);
        }

        // GET: ConeModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConeModel coneModel = db.ConeModels.Find(id);
            if (coneModel == null)
            {
                return HttpNotFound();
            }
            return View(coneModel);
        }

        // POST: ConeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ConeModel coneModel = db.ConeModels.Find(id);
            db.ConeModels.Remove(coneModel);
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
