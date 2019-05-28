using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvaGroupSoftware.Dao;
using ProvaGroupSoftware.Models;

namespace ProvaGroupSoftware.Controllers
{
    public class MoradoresController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Moradores
        public ActionResult Index()
        {
            var moradors = db.Moradors.Include(m => m.Unidade);
            return View(moradors.ToList());
        }

        // GET: Moradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morador = db.Moradors.Find(id);
            if (morador == null)
            {
                return HttpNotFound();
            }
            return View(morador);
        }

        // GET: Moradores/Create
        public ActionResult Create()
        {
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Numero");
            return View();
        }

        // POST: Moradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoradorId,Nome,Sobrenome,UnidadeId")] Morador morador)
        {
            if (ModelState.IsValid)
            {
                db.Moradors.Add(morador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Numero", morador.UnidadeId);
            return View(morador);
        }

        // GET: Moradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morador = db.Moradors.Find(id);
            if (morador == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Numero", morador.UnidadeId);
            return View(morador);
        }

        // POST: Moradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MoradorId,Nome,Sobrenome,UnidadeId")] Morador morador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(morador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Numero", morador.UnidadeId);
            return View(morador);
        }

        // GET: Moradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morador = db.Moradors.Find(id);
            if (morador == null)
            {
                return HttpNotFound();
            }
            return View(morador);
        }

        // POST: Moradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Morador morador = db.Moradors.Find(id);
            db.Moradors.Remove(morador);
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
