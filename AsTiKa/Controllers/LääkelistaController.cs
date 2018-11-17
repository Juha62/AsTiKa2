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
    public class LääkelistaController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Lääkelista
        public ActionResult Index()
        {
            return View(db.Lääkelista.ToList());
        }

        // GET: Lääkelista/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lääkelista lääkelista = db.Lääkelista.Find(id);
            if (lääkelista == null)
            {
                return HttpNotFound();
            }
            return View(lääkelista);
        }

        // GET: Lääkelista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lääkelista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Nykyhetken_lääkitys,Lääkitys_historia")] Lääkelista lääkelista)
        {
            if (ModelState.IsValid)
            {
                db.Lääkelista.Add(lääkelista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lääkelista);
        }

        // GET: Lääkelista/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lääkelista lääkelista = db.Lääkelista.Find(id);
            if (lääkelista == null)
            {
                return HttpNotFound();
            }
            return View(lääkelista);
        }

        // POST: Lääkelista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Nykyhetken_lääkitys,Lääkitys_historia")] Lääkelista lääkelista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lääkelista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lääkelista);
        }

        // GET: Lääkelista/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lääkelista lääkelista = db.Lääkelista.Find(id);
            if (lääkelista == null)
            {
                return HttpNotFound();
            }
            return View(lääkelista);
        }

        // POST: Lääkelista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Lääkelista lääkelista = db.Lääkelista.Find(id);
            db.Lääkelista.Remove(lääkelista);
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
