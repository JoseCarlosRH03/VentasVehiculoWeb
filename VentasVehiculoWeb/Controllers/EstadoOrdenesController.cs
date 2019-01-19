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
    public class EstadoOrdenesController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: EstadoOrdenes
        public ActionResult Index()
        {
            return View(db.EstadoOrdens.ToList());
        }

        // GET: EstadoOrdenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoOrden estadoOrden = db.EstadoOrdens.Find(id);
            if (estadoOrden == null)
            {
                return HttpNotFound();
            }
            return View(estadoOrden);
        }

        // GET: EstadoOrdenes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoOrdenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre")] EstadoOrden estadoOrden)
        {
            if (ModelState.IsValid)
            {
                db.EstadoOrdens.Add(estadoOrden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoOrden);
        }

        // GET: EstadoOrdenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoOrden estadoOrden = db.EstadoOrdens.Find(id);
            if (estadoOrden == null)
            {
                return HttpNotFound();
            }
            return View(estadoOrden);
        }

        // POST: EstadoOrdenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre")] EstadoOrden estadoOrden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoOrden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoOrden);
        }

        // GET: EstadoOrdenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoOrden estadoOrden = db.EstadoOrdens.Find(id);
            if (estadoOrden == null)
            {
                return HttpNotFound();
            }
            return View(estadoOrden);
        }

        // POST: EstadoOrdenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoOrden estadoOrden = db.EstadoOrdens.Find(id);
            db.EstadoOrdens.Remove(estadoOrden);
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
