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
    public class AnketaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Anketa
        public ActionResult Index()
        {
            return RedirectToAction("pitanje");
            //return View(db.Anketas.ToList());
        }

        // GET: Anketa/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                Sifra sif = TempData["sifra"] as Sifra;
               
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               
            }
            Anketa anketa = db.Anketas.Find(id);
            if (anketa == null)
            {
                return HttpNotFound();
            }
            return View(anketa);
           // TempData["sifra"] = null;
        }

        // GET: Anketa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anketa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ankt_brj,ankt_naslov,ankt_brjpit,ankt_brjotvaranja,ankt_datumotv,ankt_datposljotv")] Anketa anketa)
        {
            anketa.ankt_brjotvaranja = 0;
            anketa.ankt_datumotv = DateTime.Now;
            anketa.ankt_datposljotv = DateTime.Now;
            anketa.ankt_brjpit = 0;
            if (ModelState.IsValid)
            {
                
                db.Anketas.Add(anketa);
                db.SaveChanges();
                Sifra sifra = new Sifra();
                sifra.sifra = anketa.ankt_brj;
                System.Diagnostics.Debug.WriteLine(anketa.ankt_brj);
                TempData["sifra"] = sifra;
            //    return RedirectToAction("Index");
                
                return RedirectToAction("dodajPitanje");

            //return RedirectToAction("novoPitanje", new { sifra = anketa.ankt_brj });
            }

            return View(anketa);
            //return RedirectToRoute("/pitanje/create");
        }

        // GET: Anketa/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anketa anketa = db.Anketas.Find(id);
            if (anketa == null)
            {
                return HttpNotFound();
            }
            return View(anketa);
        }

        // POST: Anketa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ankt_brj,ankt_naslov,ankt_brjpit,ankt_brjotvaranja,ankt_datumotv,ankt_datposljotv")] Anketa anketa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anketa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anketa);
        }

        // GET: Anketa/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anketa anketa = db.Anketas.Find(id);
            if (anketa == null)
            {
                return HttpNotFound();
            }
            return View(anketa);
        }

        // POST: Anketa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Anketa anketa = db.Anketas.Find(id);
            db.Anketas.Remove(anketa);
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

        public ActionResult dodajPitanje() {
           
        return View();
        }

        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult dodajPitanje([Bind(Include = "pit_brj,pit_sadrz,pit_anktbrj,pit_datumpost,odg1,odg2,odg3,odg4")] Pitanje pitanje)
        {
            TempData["Sifra"] = null;
            pitanje.odg1_glas = 0;
            pitanje.odg2_glas = 0;
            pitanje.odg3_glas = 0;
            pitanje.odg4_glas = 0;
            pitanje.brojotvaranja = 0;
            pitanje.pit_anktbrj = db.Anketas.First().ankt_brj;
            Sifra sif = TempData["sifra"] as Sifra;
           // if (db.Anketas.First().ankt_brj != null)
           //     pitanje.pit_anktbrj = db.Anketas.First().ankt_brj;
           // else
            
            pitanje.pit_datumpost = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Pitanjes.Add(pitanje);
                db.SaveChanges();
                Anketa anketa = db.Anketas.First();
                anketa.ankt_brjpit++;
                db.Entry(anketa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("dodajPitanje");
            }

            return View(pitanje);

        }

        public ActionResult Anketa() {
            return View(db.Pitanjes.ToList());
        }

        [AllowAnonymous]
        public ActionResult pitanje()
        {
            if (db.Anketas.Count() == 0) return RedirectToAction("Create");
            if (db.Anketas.First().ankt_brjpit == 0) return RedirectToAction("dodajPitanje");
            ViewBag.rednibroj = 0;
            Sifra sifra = TempData["Sifra"] as Sifra;
            if (sifra == null)
            {
                System.Diagnostics.Debug.WriteLine("sifra je null");
                ViewBag.ident = db.Pitanjes.First().pit_brj;
                ViewBag.procent = 0;
                Sifra sifra2 = new Sifra
                {
                    sifra = db.Pitanjes.First().pit_brj,
                    redbrj = 2
                };
                //sifra.sifra = db.Pitanjes.First().pit_brj;
                //sifra.redbrj = 2;
                ViewBag.rednibroj = sifra2.redbrj-1;
                TempData["Sifra"] = sifra2;
                return View(db.Pitanjes.First());
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("id pitanja je " + sifra.sifra.ToString());
                var procent1 = ((double)(sifra.redbrj-1) / (double)db.Anketas.First().ankt_brjpit) * 100;
                ViewBag.procent = procent1.ToString() + "%";
                System.Diagnostics.Debug.WriteLine("progres je " + procent1 + " " + sifra.redbrj + " " + db.Anketas.First().ankt_brjpit);
               
                Pitanje pitanjce = db.Pitanjes.Find(sifra.sifra);
                sifra.redbrj++;
                System.Diagnostics.Debug.WriteLine(" redbrj " + sifra.redbrj);
                TempData["Sifra"] = sifra;
                ViewBag.ident = db.Pitanjes.Find(sifra.sifra).pit_brj;
                //ViewBag.procent = (sifra.redbrj/db.Anketas.First().ankt_brjpit) * 100;
                
                //ViewBag.procent = "50%";
                 ViewBag.rednibroj = sifra.redbrj - 1;
                return View(db.Pitanjes.Find(sifra.sifra));
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult pitanje( int broj)
        {

            //if(brojPitanja == db.Pitanjes.Last().pit_brj) RedirectToAction("kraj");
           // Pitanje pitanje = db.Pitanjes.Last();
            //long idPitanja = int.Parse(Request["brojPitanja"]);
            Sifra sifra1 = TempData["Sifra"] as Sifra;
            long idPitanja = sifra1.sifra;
            System.Diagnostics.Debug.WriteLine(" sifra " + sifra1.redbrj);
            Pitanje pitanje = db.Pitanjes.Find(idPitanja);
            pitanje.brojotvaranja++;
            if (broj == 1) pitanje.odg1_glas++;
            if (broj == 2) pitanje.odg2_glas++;
            if (broj == 3) pitanje.odg3_glas++;
            if (broj == 4) pitanje.odg4_glas++;
            db.Entry(pitanje).State = EntityState.Modified;
            db.SaveChanges();

            if (db.Anketas.First().ankt_brjpit < sifra1.redbrj)
            {
                System.Diagnostics.Debug.WriteLine("kraj price");
                return RedirectToAction("kraj");
            }
            else
            {
                var next = db.Pitanjes.Where(item => item.pit_brj > idPitanja)
                    .OrderBy(item => item.pit_brj)
                    .FirstOrDefault();
                System.Diagnostics.Debug.WriteLine(next.pit_brj);
                idPitanja = next.pit_brj;
                sifra1.sifra = next.pit_brj;
                ViewBag.ident = next.pit_brj;
                System.Diagnostics.Debug.WriteLine("broj je " + Request["broj"].ToString() + " " + Request["brojPitanja"]);
                //return View();
                Sifra sifra = new Sifra
                {
                    sifra = idPitanja
                };

                TempData["Sifra"] = sifra1;
                return RedirectToAction("pitanje");
            }
            
            
        }
        [AllowAnonymous]
        public ActionResult kraj()
        {
            TempData["Sifra"] = null;
            return View();
        }
    }

     
}
