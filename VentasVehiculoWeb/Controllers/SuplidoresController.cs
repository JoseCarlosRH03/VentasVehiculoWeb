using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaVehiculoModelDB.Models;

namespace VentasVehiculoWeb.Controllers
{
    public class SuplidoresController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: Suplidores
        public ActionResult Index()
        {
            return View(db.Suplidores.ToList());
        }

        // GET: Suplidores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suplidore suplidore = db.Suplidores.Find(id);
            if (suplidore == null)
            {
                return HttpNotFound();
            }
            return View(suplidore);
        }

        // GET: Suplidores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suplidores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NombreEmpresa,Direccion,Telefono")] Suplidore suplidore)
        {
            if (ModelState.IsValid)
            {
                db.Suplidores.Add(suplidore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suplidore);
        }

        // GET: Suplidores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suplidore suplidore = db.Suplidores.Find(id);
            if (suplidore == null)
            {
                return HttpNotFound();
            }
            return View(suplidore);
        }

        // POST: Suplidores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NombreEmpresa,Direccion,Telefono")] Suplidore suplidore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suplidore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suplidore);
        }

        // GET: Suplidores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suplidore suplidore = db.Suplidores.Find(id);
            if (suplidore == null)
            {
                return HttpNotFound();
            }
            return View(suplidore);
        }

        // POST: Suplidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suplidore suplidore = db.Suplidores.Find(id);
            db.Suplidores.Remove(suplidore);
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
