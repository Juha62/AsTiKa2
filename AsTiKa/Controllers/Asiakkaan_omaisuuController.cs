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
    public class Asiakkaan_omaisuuController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Asiakkaan_omaisuu
        public ActionResult Index()
        {
            return View(db.Asiakkaan_omaisuus.ToList());
        }

        // GET: Asiakkaan_omaisuu/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_omaisuu asiakkaan_omaisuu = db.Asiakkaan_omaisuus.Find(id);
            if (asiakkaan_omaisuu == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_omaisuu);
        }

        // GET: Asiakkaan_omaisuu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asiakkaan_omaisuu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Henkilökohtaiset_tavarat,Huonekalut,Tekstiilit,Vuode_ja_liinavaatteet")] Asiakkaan_omaisuu asiakkaan_omaisuu)
        {
            if (ModelState.IsValid)
            {
                db.Asiakkaan_omaisuus.Add(asiakkaan_omaisuu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asiakkaan_omaisuu);
        }

        // GET: Asiakkaan_omaisuu/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_omaisuu asiakkaan_omaisuu = db.Asiakkaan_omaisuus.Find(id);
            if (asiakkaan_omaisuu == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_omaisuu);
        }

        // POST: Asiakkaan_omaisuu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Henkilökohtaiset_tavarat,Huonekalut,Tekstiilit,Vuode_ja_liinavaatteet")] Asiakkaan_omaisuu asiakkaan_omaisuu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakkaan_omaisuu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asiakkaan_omaisuu);
        }

        // GET: Asiakkaan_omaisuu/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_omaisuu asiakkaan_omaisuu = db.Asiakkaan_omaisuus.Find(id);
            if (asiakkaan_omaisuu == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_omaisuu);
        }

        // POST: Asiakkaan_omaisuu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Asiakkaan_omaisuu asiakkaan_omaisuu = db.Asiakkaan_omaisuus.Find(id);
            db.Asiakkaan_omaisuus.Remove(asiakkaan_omaisuu);
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
