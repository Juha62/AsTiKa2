using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AsTiKa.Models;

namespace AsTiKa.Controllers
{
    public class RokotuslistasController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Rokotuslistas
        public ActionResult Index()
        {
            return View(db.Rokotuslistas.ToList());
        }

        // GET: Rokotuslistas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rokotuslista rokotuslista = db.Rokotuslistas.Find(id);
            if (rokotuslista == null)
            {
                return HttpNotFound();
            }
            return View(rokotuslista);
        }

        // GET: Rokotuslistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rokotuslistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Rokotteen_nimi,Anto_päivämäärä,Tehosterokotuksen_antopäivä,Mahdolliset_sivuoireet_rokotuksista")] Rokotuslista rokotuslista)
        {
            if (ModelState.IsValid)
            {
                db.Rokotuslistas.Add(rokotuslista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rokotuslista);
        }

        // GET: Rokotuslistas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rokotuslista rokotuslista = db.Rokotuslistas.Find(id);
            if (rokotuslista == null)
            {
                return HttpNotFound();
            }
            return View(rokotuslista);
        }

        // POST: Rokotuslistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Rokotteen_nimi,Anto_päivämäärä,Tehosterokotuksen_antopäivä,Mahdolliset_sivuoireet_rokotuksista")] Rokotuslista rokotuslista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rokotuslista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rokotuslista);
        }

        // GET: Rokotuslistas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rokotuslista rokotuslista = db.Rokotuslistas.Find(id);
            if (rokotuslista == null)
            {
                return HttpNotFound();
            }
            return View(rokotuslista);
        }

        // POST: Rokotuslistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Rokotuslista rokotuslista = db.Rokotuslistas.Find(id);
            db.Rokotuslistas.Remove(rokotuslista);
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
