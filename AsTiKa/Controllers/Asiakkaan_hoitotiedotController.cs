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
    public class Asiakkaan_hoitotiedotController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Asiakkaan_hoitotiedot
        public ActionResult Index()
        {
            return View(db.Asiakkaan_hoitotiedots.ToList());
        }

        // GET: Asiakkaan_hoitotiedot/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_hoitotiedot asiakkaan_hoitotiedot = db.Asiakkaan_hoitotiedots.Find(id);
            if (asiakkaan_hoitotiedot == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_hoitotiedot);
        }

        // GET: Asiakkaan_hoitotiedot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asiakkaan_hoitotiedot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Asukkaan_perustiedot,Edunvalvojan_yhteystiedot,Omahoitajan_yhteystiedot,Hoitavan_lääkärin_yhteystiedot,Omaisten_yhteystiedot,Diagnoosit,Allergiat,Kontrolloitavat_laboratoriokokeet,Sovitut_ja_suunnitellut_kontrollikäynnit,Syöminen_erityisruokavalio,Liikkuminen__hygienia,Ihon_kunto,Erityishoidot,Kommunikointi,Psyykkinen_vointi,Hoitoon_hakeutumisen_syy")] Asiakkaan_hoitotiedot asiakkaan_hoitotiedot)
        {
            if (ModelState.IsValid)
            {
                db.Asiakkaan_hoitotiedots.Add(asiakkaan_hoitotiedot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asiakkaan_hoitotiedot);
        }

        // GET: Asiakkaan_hoitotiedot/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_hoitotiedot asiakkaan_hoitotiedot = db.Asiakkaan_hoitotiedots.Find(id);
            if (asiakkaan_hoitotiedot == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_hoitotiedot);
        }

        // POST: Asiakkaan_hoitotiedot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Asukkaan_perustiedot,Edunvalvojan_yhteystiedot,Omahoitajan_yhteystiedot,Hoitavan_lääkärin_yhteystiedot,Omaisten_yhteystiedot,Diagnoosit,Allergiat,Kontrolloitavat_laboratoriokokeet,Sovitut_ja_suunnitellut_kontrollikäynnit,Syöminen_erityisruokavalio,Liikkuminen__hygienia,Ihon_kunto,Erityishoidot,Kommunikointi,Psyykkinen_vointi,Hoitoon_hakeutumisen_syy")] Asiakkaan_hoitotiedot asiakkaan_hoitotiedot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakkaan_hoitotiedot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asiakkaan_hoitotiedot);
        }

        // GET: Asiakkaan_hoitotiedot/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_hoitotiedot asiakkaan_hoitotiedot = db.Asiakkaan_hoitotiedots.Find(id);
            if (asiakkaan_hoitotiedot == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_hoitotiedot);
        }

        // POST: Asiakkaan_hoitotiedot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Asiakkaan_hoitotiedot asiakkaan_hoitotiedot = db.Asiakkaan_hoitotiedots.Find(id);
            db.Asiakkaan_hoitotiedots.Remove(asiakkaan_hoitotiedot);
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
