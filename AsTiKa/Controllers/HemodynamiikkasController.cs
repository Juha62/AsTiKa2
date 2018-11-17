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
    public class HemodynamiikkasController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Hemodynamiikkas
        public ActionResult Index()
        {
            return View(db.Hemodynamiikkas.ToList());
        }

        // GET: Hemodynamiikkas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hemodynamiikka hemodynamiikka = db.Hemodynamiikkas.Find(id);
            if (hemodynamiikka == null)
            {
                return HttpNotFound();
            }
            return View(hemodynamiikka);
        }

        // GET: Hemodynamiikkas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hemodynamiikkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Verenpaine,Paino,Lämmön_seuranta,Nestelista,Vatsantoiminta,EKG,Verensokeri")] Hemodynamiikka hemodynamiikka)
        {
            if (ModelState.IsValid)
            {
                db.Hemodynamiikkas.Add(hemodynamiikka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hemodynamiikka);
        }

        // GET: Hemodynamiikkas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hemodynamiikka hemodynamiikka = db.Hemodynamiikkas.Find(id);
            if (hemodynamiikka == null)
            {
                return HttpNotFound();
            }
            return View(hemodynamiikka);
        }

        // POST: Hemodynamiikkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Verenpaine,Paino,Lämmön_seuranta,Nestelista,Vatsantoiminta,EKG,Verensokeri")] Hemodynamiikka hemodynamiikka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hemodynamiikka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hemodynamiikka);
        }

        // GET: Hemodynamiikkas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hemodynamiikka hemodynamiikka = db.Hemodynamiikkas.Find(id);
            if (hemodynamiikka == null)
            {
                return HttpNotFound();
            }
            return View(hemodynamiikka);
        }

        // POST: Hemodynamiikkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hemodynamiikka hemodynamiikka = db.Hemodynamiikkas.Find(id);
            db.Hemodynamiikkas.Remove(hemodynamiikka);
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
