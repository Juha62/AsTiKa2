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
    public class Infektion_seuranta_ja_hoitoController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Infektion_seuranta_ja_hoito
        public ActionResult Index()
        {
            return View(db.Infektion_seuranta_ja_hoitoes.ToList());
        }

        // GET: Infektion_seuranta_ja_hoito/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infektion_seuranta_ja_hoito infektion_seuranta_ja_hoito = db.Infektion_seuranta_ja_hoitoes.Find(id);
            if (infektion_seuranta_ja_hoito == null)
            {
                return HttpNotFound();
            }
            return View(infektion_seuranta_ja_hoito);
        }

        // GET: Infektion_seuranta_ja_hoito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Infektion_seuranta_ja_hoito/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Milloin_infektio_todettu,Infektion_tyyppi,Oireet,Hoito,Mahdolliset_kontrollit")] Infektion_seuranta_ja_hoito infektion_seuranta_ja_hoito)
        {
            if (ModelState.IsValid)
            {
                db.Infektion_seuranta_ja_hoitoes.Add(infektion_seuranta_ja_hoito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(infektion_seuranta_ja_hoito);
        }

        // GET: Infektion_seuranta_ja_hoito/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infektion_seuranta_ja_hoito infektion_seuranta_ja_hoito = db.Infektion_seuranta_ja_hoitoes.Find(id);
            if (infektion_seuranta_ja_hoito == null)
            {
                return HttpNotFound();
            }
            return View(infektion_seuranta_ja_hoito);
        }

        // POST: Infektion_seuranta_ja_hoito/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Milloin_infektio_todettu,Infektion_tyyppi,Oireet,Hoito,Mahdolliset_kontrollit")] Infektion_seuranta_ja_hoito infektion_seuranta_ja_hoito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infektion_seuranta_ja_hoito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(infektion_seuranta_ja_hoito);
        }

        // GET: Infektion_seuranta_ja_hoito/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infektion_seuranta_ja_hoito infektion_seuranta_ja_hoito = db.Infektion_seuranta_ja_hoitoes.Find(id);
            if (infektion_seuranta_ja_hoito == null)
            {
                return HttpNotFound();
            }
            return View(infektion_seuranta_ja_hoito);
        }

        // POST: Infektion_seuranta_ja_hoito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Infektion_seuranta_ja_hoito infektion_seuranta_ja_hoito = db.Infektion_seuranta_ja_hoitoes.Find(id);
            db.Infektion_seuranta_ja_hoitoes.Remove(infektion_seuranta_ja_hoito);
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
