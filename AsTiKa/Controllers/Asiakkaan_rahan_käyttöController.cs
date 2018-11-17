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
    public class Asiakkaan_rahan_käyttöController : Controller
    {
        private AsTiKaEntities db = new AsTiKaEntities();

        // GET: Asiakkaan_rahan_käyttö
        public ActionResult Index()
        {
            return View(db.Asiakkaan_rahan_käyttö.ToList());
        }

        // GET: Asiakkaan_rahan_käyttö/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_rahan_käyttö asiakkaan_rahan_käyttö = db.Asiakkaan_rahan_käyttö.Find(id);
            if (asiakkaan_rahan_käyttö == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_rahan_käyttö);
        }

        // GET: Asiakkaan_rahan_käyttö/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asiakkaan_rahan_käyttö/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakkaan_nimi,Saldo,Nostot,Päiväys,Määrä,Käyttötarkoitus,Kuittaaja")] Asiakkaan_rahan_käyttö asiakkaan_rahan_käyttö)
        {
            if (ModelState.IsValid)
            {
                db.Asiakkaan_rahan_käyttö.Add(asiakkaan_rahan_käyttö);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asiakkaan_rahan_käyttö);
        }

        // GET: Asiakkaan_rahan_käyttö/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_rahan_käyttö asiakkaan_rahan_käyttö = db.Asiakkaan_rahan_käyttö.Find(id);
            if (asiakkaan_rahan_käyttö == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_rahan_käyttö);
        }

        // POST: Asiakkaan_rahan_käyttö/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakkaan_nimi,Saldo,Nostot,Päiväys,Määrä,Käyttötarkoitus,Kuittaaja")] Asiakkaan_rahan_käyttö asiakkaan_rahan_käyttö)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakkaan_rahan_käyttö).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asiakkaan_rahan_käyttö);
        }

        // GET: Asiakkaan_rahan_käyttö/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakkaan_rahan_käyttö asiakkaan_rahan_käyttö = db.Asiakkaan_rahan_käyttö.Find(id);
            if (asiakkaan_rahan_käyttö == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaan_rahan_käyttö);
        }

        // POST: Asiakkaan_rahan_käyttö/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Asiakkaan_rahan_käyttö asiakkaan_rahan_käyttö = db.Asiakkaan_rahan_käyttö.Find(id);
            db.Asiakkaan_rahan_käyttö.Remove(asiakkaan_rahan_käyttö);
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
