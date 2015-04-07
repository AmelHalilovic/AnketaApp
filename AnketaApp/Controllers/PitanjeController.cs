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
    [Authorize]
    public class PitanjeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pitanje
        [AllowAnonymous]
        public ActionResult Index()
        {
            TempData["Sifra"] = null;
            return View(db.Pitanjes.ToList());
        }

        // GET: Pitanje/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pitanje pitanje = db.Pitanjes.Find(id);
            if (pitanje == null)
            {
                return HttpNotFound();
            }
            return View(pitanje);
        }

        // GET: Pitanje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pitanje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pit_brj,pit_sadrz,pit_anktbrj,odg1,odg1_glas,odg2,odg2_glas,odg3,odg3_glas,odg4,odg4_glas,pit_datumpost")] Pitanje pitanje)
        {
            if (ModelState.IsValid)
            {
                db.Pitanjes.Add(pitanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pitanje);
        }

        // GET: Pitanje/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pitanje pitanje = db.Pitanjes.Find(id);
            if (pitanje == null)
            {
                return HttpNotFound();
            }
            return View(pitanje);
        }

        // POST: Pitanje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pit_brj,pit_sadrz,pit_anktbrj,odg1,odg1_glas,odg2,odg2_glas,odg3,odg3_glas,odg4,odg4_glas,pit_datumpost")] Pitanje pitanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pitanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pitanje);
        }

        // GET: Pitanje/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pitanje pitanje = db.Pitanjes.Find(id);
            if (pitanje == null)
            {
                return HttpNotFound();
            }
            return View(pitanje);
        }

        // POST: Pitanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Pitanje pitanje = db.Pitanjes.Find(id);
            db.Pitanjes.Remove(pitanje);
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

        public ActionResult obrisipitanja()
        {
            ApplicationDbContext con = new ApplicationDbContext();
            con.Database.ExecuteSqlCommand("TRUNCATE TABLE [Pitanje]");
            Anketa anketa = db.Anketas.First();
            anketa.ankt_brjpit = 0;
            db.Entry(anketa).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
