using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Paivystyslista.Models;

namespace Paivystyslista.Controllers
{
    public class PaivystysController : Controller
    {
        private PaivystysEntities db = new PaivystysEntities();

        // GET: Paivystys
        public ActionResult Index()
        {
            return View(db.Paivystys.ToList());
        }

        // GET: Paivystys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paivystys paivystys = db.Paivystys.Find(id);
            if (paivystys == null)
            {
                return HttpNotFound();
            }
            return View(paivystys);
        }

        // GET: Paivystys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paivystys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Paivystys_id,Pvm,Paiva,Alku,Loppu,Kesto,EiKva,Huom,Paivystaja,Lomat")] Paivystys paivystys)
        {
            if (ModelState.IsValid)
            {
                db.Paivystys.Add(paivystys);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paivystys);
        }

        // GET: Paivystys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paivystys paivystys = db.Paivystys.Find(id);
            if (paivystys == null)
            {
                return HttpNotFound();
            }
            return View(paivystys);
        }

        // POST: Paivystys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Paivystys_id,Pvm,Paiva,Alku,Loppu,Kesto,EiKva,Huom,Paivystaja,Lomat")] Paivystys paivystys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paivystys).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paivystys);
        }

        // GET: Paivystys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paivystys paivystys = db.Paivystys.Find(id);
            if (paivystys == null)
            {
                return HttpNotFound();
            }
            return View(paivystys);
        }

        // POST: Paivystys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paivystys paivystys = db.Paivystys.Find(id);
            db.Paivystys.Remove(paivystys);
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
