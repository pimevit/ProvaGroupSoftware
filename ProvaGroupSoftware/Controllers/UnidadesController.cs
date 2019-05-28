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
    public class UnidadesController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Unidades
        public ActionResult Index()
        {
            var unidades = db.Unidades.Include(u => u.Condominio);
            return View(unidades.ToList());
        }

        // GET: Unidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidade unidade = db.Unidades.Find(id);
            if (unidade == null)
            {
                return HttpNotFound();
            }
            return View(unidade);
        }

        // GET: Unidades/Create
        public ActionResult Create()
        {
            ViewBag.CondominioId = new SelectList(db.Condominios, "CondominioId", "Nome");
            return View();
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnidadeId,Numero,ValorUnidade,CondominioId")] Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                db.Unidades.Add(unidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CondominioId = new SelectList(db.Condominios, "CondominioId", "Nome", unidade.CondominioId);
            return View(unidade);
        }

        // GET: Unidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidade unidade = db.Unidades.Find(id);
            if (unidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondominioId = new SelectList(db.Condominios, "CondominioId", "Nome", unidade.CondominioId);
            return View(unidade);
        }

        // POST: Unidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnidadeId,Numero,ValorUnidade,CondominioId")] Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CondominioId = new SelectList(db.Condominios, "CondominioId", "Nome", unidade.CondominioId);
            return View(unidade);
        }

        // GET: Unidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidade unidade = db.Unidades.Find(id);
            if (unidade == null)
            {
                return HttpNotFound();
            }
            return View(unidade);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unidade unidade = db.Unidades.Find(id);
            db.Unidades.Remove(unidade);
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
