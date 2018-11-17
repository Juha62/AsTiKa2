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
    public class Asiakkaan_henkilötiedotController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Asiakkaan_henkilötiedot
        public ActionResult Index()
        {
            return View(db.Asiakkaan_henkilötiedot.ToList());
        }

        // GET: Asiakkaan_henkilötiedot/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_henkilötiedot asiakkaan_henkilötiedot = db.Asiakkaan_henkilötiedot.Find(id);
            if (asiakkaan_henkilötiedot == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_henkilötiedot);
        }

        // GET: Asiakkaan_henkilötiedot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asiakkaan_henkilötiedot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Asiakkaan_lähiomaiset,Laskutustiedot,Yleinen_edunvalvoja,Muuttotiedot,Muut_tiedot,Perustiedot")] Asiakkaan_henkilötiedot asiakkaan_henkilötiedot)
        {
            if (ModelState.IsValid)
            {
                db.Asiakkaan_henkilötiedot.Add(asiakkaan_henkilötiedot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asiakkaan_henkilötiedot);
        }

        // GET: Asiakkaan_henkilötiedot/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_henkilötiedot asiakkaan_henkilötiedot = db.Asiakkaan_henkilötiedot.Find(id);
            if (asiakkaan_henkilötiedot == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_henkilötiedot);
        }

        // POST: Asiakkaan_henkilötiedot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Asiakkaan_lähiomaiset,Laskutustiedot,Yleinen_edunvalvoja,Muuttotiedot,Muut_tiedot,Perustiedot")] Asiakkaan_henkilötiedot asiakkaan_henkilötiedot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakkaan_henkilötiedot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asiakkaan_henkilötiedot);
        }

        // GET: Asiakkaan_henkilötiedot/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_henkilötiedot asiakkaan_henkilötiedot = db.Asiakkaan_henkilötiedot.Find(id);
            if (asiakkaan_henkilötiedot == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_henkilötiedot);
        }

        // POST: Asiakkaan_henkilötiedot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Asiakkaan_henkilötiedot asiakkaan_henkilötiedot = db.Asiakkaan_henkilötiedot.Find(id);
            db.Asiakkaan_henkilötiedot.Remove(asiakkaan_henkilötiedot);
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
