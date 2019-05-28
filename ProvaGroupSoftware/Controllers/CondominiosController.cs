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
    public class CondominiosController : Controller
    {
        private EFContext db = new EFContext();

    // GET: Condominios
    public ActionResult Index(string sortOrder, string searchString)
    {
      if (string.IsNullOrEmpty(sortOrder))
      {
        ViewBag.NomeSortParm = "nome_desc";
        ViewBag.EndSortParm = "endereco_desc";
      }
        var retorno = from cond in db.Condominios select cond;
      
      if (!string.IsNullOrEmpty(searchString))
      {
        retorno = db.Condominios.Where(find => find.Endereco == searchString);
      }
      switch(sortOrder)
      {
        case "nome_desc": retorno = retorno.OrderBy(nome => nome.Nome);break;
        case "endereco_desc": retorno = retorno.OrderByDescending(end => end.Endereco);break;
        default: retorno = retorno.OrderBy(order => order.Cidade); break;
      }
      
      return View(db.Condominios.ToList());
    }

    // GET: Condominios/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio condominio = db.Condominios.Find(id);
            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        // GET: Condominios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Condominios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CondominioId,Nome,Endereco,Cidade,UF,Cep")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                db.Condominios.Add(condominio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condominio);
        }

        // GET: Condominios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio condominio = db.Condominios.Find(id);
            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        // POST: Condominios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CondominioId,Nome,Endereco,Cidade,UF,Cep")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condominio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condominio);
        }

        // GET: Condominios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio condominio = db.Condominios.Find(id);
            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        // POST: Condominios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Condominio condominio = db.Condominios.Find(id);
            db.Condominios.Remove(condominio);
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
