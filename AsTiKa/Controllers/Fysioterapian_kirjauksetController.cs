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
    public class Fysioterapian_kirjauksetController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Fysioterapian_kirjaukset
        public ActionResult Index()
        {
            return View(db.Fysioterapian_kirjauksets.ToList());
        }

        // GET: Fysioterapian_kirjaukset/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fysioterapian_kirjaukset fysioterapian_kirjaukset = db.Fysioterapian_kirjauksets.Find(id);
            if (fysioterapian_kirjaukset == null)
            {
                return HttpNotFound();
            }
            return View(fysioterapian_kirjaukset);
        }

        // GET: Fysioterapian_kirjaukset/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fysioterapian_kirjaukset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Apuvälineiden_käyttö_ja_ohjaus,Ohjeet_toiminnan_ylläpitämiseksi")] Fysioterapian_kirjaukset fysioterapian_kirjaukset)
        {
            if (ModelState.IsValid)
            {
                db.Fysioterapian_kirjauksets.Add(fysioterapian_kirjaukset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fysioterapian_kirjaukset);
        }

        // GET: Fysioterapian_kirjaukset/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fysioterapian_kirjaukset fysioterapian_kirjaukset = db.Fysioterapian_kirjauksets.Find(id);
            if (fysioterapian_kirjaukset == null)
            {
                return HttpNotFound();
            }
            return View(fysioterapian_kirjaukset);
        }

        // POST: Fysioterapian_kirjaukset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Apuvälineiden_käyttö_ja_ohjaus,Ohjeet_toiminnan_ylläpitämiseksi")] Fysioterapian_kirjaukset fysioterapian_kirjaukset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fysioterapian_kirjaukset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fysioterapian_kirjaukset);
        }

        // GET: Fysioterapian_kirjaukset/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fysioterapian_kirjaukset fysioterapian_kirjaukset = db.Fysioterapian_kirjauksets.Find(id);
            if (fysioterapian_kirjaukset == null)
            {
                return HttpNotFound();
            }
            return View(fysioterapian_kirjaukset);
        }

        // POST: Fysioterapian_kirjaukset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Fysioterapian_kirjaukset fysioterapian_kirjaukset = db.Fysioterapian_kirjauksets.Find(id);
            db.Fysioterapian_kirjauksets.Remove(fysioterapian_kirjaukset);
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
