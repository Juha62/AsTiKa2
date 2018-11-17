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
    public class Muistihoitajan_sivuController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Muistihoitajan_sivu
        public ActionResult Index()
        {
            return View(db.Muistihoitajan_sivus.ToList());
        }

        // GET: Muistihoitajan_sivu/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muistihoitajan_sivu muistihoitajan_sivu = db.Muistihoitajan_sivus.Find(id);
            if (muistihoitajan_sivu == null)
            {
                return HttpNotFound();
            }
            return View(muistihoitajan_sivu);
        }

        // GET: Muistihoitajan_sivu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Muistihoitajan_sivu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Tehtyjen_testien_tulokset,Käyntikirjaukset_ja_havainnot")] Muistihoitajan_sivu muistihoitajan_sivu)
        {
            if (ModelState.IsValid)
            {
                db.Muistihoitajan_sivus.Add(muistihoitajan_sivu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(muistihoitajan_sivu);
        }

        // GET: Muistihoitajan_sivu/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muistihoitajan_sivu muistihoitajan_sivu = db.Muistihoitajan_sivus.Find(id);
            if (muistihoitajan_sivu == null)
            {
                return HttpNotFound();
            }
            return View(muistihoitajan_sivu);
        }

        // POST: Muistihoitajan_sivu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Tehtyjen_testien_tulokset,Käyntikirjaukset_ja_havainnot")] Muistihoitajan_sivu muistihoitajan_sivu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muistihoitajan_sivu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(muistihoitajan_sivu);
        }

        // GET: Muistihoitajan_sivu/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muistihoitajan_sivu muistihoitajan_sivu = db.Muistihoitajan_sivus.Find(id);
            if (muistihoitajan_sivu == null)
            {
                return HttpNotFound();
            }
            return View(muistihoitajan_sivu);
        }

        // POST: Muistihoitajan_sivu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Muistihoitajan_sivu muistihoitajan_sivu = db.Muistihoitajan_sivus.Find(id);
            db.Muistihoitajan_sivus.Remove(muistihoitajan_sivu);
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
