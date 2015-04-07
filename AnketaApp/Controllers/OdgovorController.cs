using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnketaApp.Models;

namespace AnketaApp.Controllers
{
    public class OdgovorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Odgovor
        public ActionResult Index()
        {
            return View(db.Odgovors.ToList());
        }

        // GET: Odgovor/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odgovor odgovor = db.Odgovors.Find(id);
            if (odgovor == null)
            {
                return HttpNotFound();
            }
            return View(odgovor);
        }

        // GET: Odgovor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Odgovor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "odg_brj,odg_sadr,odg_pitbrj,odg_datumpost,odg_brojodabira")] Odgovor odgovor)
        {
            if (ModelState.IsValid)
            {
                db.Odgovors.Add(odgovor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(odgovor);
        }

        // GET: Odgovor/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odgovor odgovor = db.Odgovors.Find(id);
            if (odgovor == null)
            {
                return HttpNotFound();
            }
            return View(odgovor);
        }

        // POST: Odgovor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "odg_brj,odg_sadr,odg_pitbrj,odg_datumpost,odg_brojodabira")] Odgovor odgovor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odgovor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(odgovor);
        }

        // GET: Odgovor/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odgovor odgovor = db.Odgovors.Find(id);
            if (odgovor == null)
            {
                return HttpNotFound();
            }
            return View(odgovor);
        }

        // POST: Odgovor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Odgovor odgovor = db.Odgovors.Find(id);
            db.Odgovors.Remove(odgovor);
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
