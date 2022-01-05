using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesafioCaleb.Models;

namespace DesafioCaleb.Controllers
{
    public class pessoasController : Controller
    {
        private contexto db = new contexto();

        // GET: pessoas
        public ActionResult Index()
        {
            return View(db.Pessoas.ToList());
        }

        // GET: pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // GET: pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nome,Email,Idade")] pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoas);
        }

        // GET: pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nome,Email,Idade")] pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoas);
        }

        // GET: pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // POST: pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pessoas pessoas = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoas);
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
