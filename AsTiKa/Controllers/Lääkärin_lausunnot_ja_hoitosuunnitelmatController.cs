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
    public class Lääkärin_lausunnot_ja_hoitosuunnitelmatController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Lääkärin_lausunnot_ja_hoitosuunnitelmat
        public ActionResult Index()
        {
            return View(db.Lääkärin_lausunnot_ja_hoitosuunnitelmat.ToList());
        }

        // GET: Lääkärin_lausunnot_ja_hoitosuunnitelmat/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lääkärin_lausunnot_ja_hoitosuunnitelmat lääkärin_lausunnot_ja_hoitosuunnitelmat = db.Lääkärin_lausunnot_ja_hoitosuunnitelmat.Find(id);
            if (lääkärin_lausunnot_ja_hoitosuunnitelmat == null)
            {
                return HttpNotFound();
            }
            return View(lääkärin_lausunnot_ja_hoitosuunnitelmat);
        }

        // GET: Lääkärin_lausunnot_ja_hoitosuunnitelmat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lääkärin_lausunnot_ja_hoitosuunnitelmat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Psykiatrian_lausunnot_ja_hoitosuunnitelmat,Neurologian_lausunnot_ja_hoitosuunnitelmat,Yleislääketied_lausunnot_ja_hoitosuunnitelmat")] Lääkärin_lausunnot_ja_hoitosuunnitelmat lääkärin_lausunnot_ja_hoitosuunnitelmat)
        {
            if (ModelState.IsValid)
            {
                db.Lääkärin_lausunnot_ja_hoitosuunnitelmat.Add(lääkärin_lausunnot_ja_hoitosuunnitelmat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lääkärin_lausunnot_ja_hoitosuunnitelmat);
        }

        // GET: Lääkärin_lausunnot_ja_hoitosuunnitelmat/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lääkärin_lausunnot_ja_hoitosuunnitelmat lääkärin_lausunnot_ja_hoitosuunnitelmat = db.Lääkärin_lausunnot_ja_hoitosuunnitelmat.Find(id);
            if (lääkärin_lausunnot_ja_hoitosuunnitelmat == null)
            {
                return HttpNotFound();
            }
            return View(lääkärin_lausunnot_ja_hoitosuunnitelmat);
        }

        // POST: Lääkärin_lausunnot_ja_hoitosuunnitelmat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Psykiatrian_lausunnot_ja_hoitosuunnitelmat,Neurologian_lausunnot_ja_hoitosuunnitelmat,Yleislääketied_lausunnot_ja_hoitosuunnitelmat")] Lääkärin_lausunnot_ja_hoitosuunnitelmat lääkärin_lausunnot_ja_hoitosuunnitelmat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lääkärin_lausunnot_ja_hoitosuunnitelmat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lääkärin_lausunnot_ja_hoitosuunnitelmat);
        }

        // GET: Lääkärin_lausunnot_ja_hoitosuunnitelmat/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lääkärin_lausunnot_ja_hoitosuunnitelmat lääkärin_lausunnot_ja_hoitosuunnitelmat = db.Lääkärin_lausunnot_ja_hoitosuunnitelmat.Find(id);
            if (lääkärin_lausunnot_ja_hoitosuunnitelmat == null)
            {
                return HttpNotFound();
            }
            return View(lääkärin_lausunnot_ja_hoitosuunnitelmat);
        }

        // POST: Lääkärin_lausunnot_ja_hoitosuunnitelmat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Lääkärin_lausunnot_ja_hoitosuunnitelmat lääkärin_lausunnot_ja_hoitosuunnitelmat = db.Lääkärin_lausunnot_ja_hoitosuunnitelmat.Find(id);
            db.Lääkärin_lausunnot_ja_hoitosuunnitelmat.Remove(lääkärin_lausunnot_ja_hoitosuunnitelmat);
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
