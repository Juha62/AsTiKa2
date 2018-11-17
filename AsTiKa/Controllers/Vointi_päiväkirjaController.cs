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
    public class Vointi_päiväkirjaController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Vointi_päiväkirja
        public ActionResult Index()
        {
            return View(db.Vointi_päiväkirja.ToList());
        }

        // GET: Vointi_päiväkirja/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vointi_päiväkirja vointi_päiväkirja = db.Vointi_päiväkirja.Find(id);
            if (vointi_päiväkirja == null)
            {
                return HttpNotFound();
            }
            return View(vointi_päiväkirja);
        }

        // GET: Vointi_päiväkirja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vointi_päiväkirja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Hoidon_tarpeen_kirjaaminen,Hoidon_tavoitteiden_kirjaaminen,Hoidon_suunnittelun_kirjaaminen,Hoidon_toteutuksen_kirjaaminen")] Vointi_päiväkirja vointi_päiväkirja)
        {
            if (ModelState.IsValid)
            {
                db.Vointi_päiväkirja.Add(vointi_päiväkirja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vointi_päiväkirja);
        }

        // GET: Vointi_päiväkirja/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vointi_päiväkirja vointi_päiväkirja = db.Vointi_päiväkirja.Find(id);
            if (vointi_päiväkirja == null)
            {
                return HttpNotFound();
            }
            return View(vointi_päiväkirja);
        }

        // POST: Vointi_päiväkirja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Hoidon_tarpeen_kirjaaminen,Hoidon_tavoitteiden_kirjaaminen,Hoidon_suunnittelun_kirjaaminen,Hoidon_toteutuksen_kirjaaminen")] Vointi_päiväkirja vointi_päiväkirja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vointi_päiväkirja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vointi_päiväkirja);
        }

        // GET: Vointi_päiväkirja/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vointi_päiväkirja vointi_päiväkirja = db.Vointi_päiväkirja.Find(id);
            if (vointi_päiväkirja == null)
            {
                return HttpNotFound();
            }
            return View(vointi_päiväkirja);
        }

        // POST: Vointi_päiväkirja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vointi_päiväkirja vointi_päiväkirja = db.Vointi_päiväkirja.Find(id);
            db.Vointi_päiväkirja.Remove(vointi_päiväkirja);
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
