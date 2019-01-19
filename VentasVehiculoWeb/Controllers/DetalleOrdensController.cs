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
    public class DetalleOrdensController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: DetalleOrdens
        public ActionResult Index()
        {
            var detalleOrdens = db.DetalleOrdens.Include(d => d.Orden).Include(d => d.Vehiculo);
            return View(detalleOrdens.ToList());
        }

        // GET: DetalleOrdens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleOrden detalleOrden = db.DetalleOrdens.Find(id);
            if (detalleOrden == null)
            {
                return HttpNotFound();
            }
            return View(detalleOrden);
        }

        // GET: DetalleOrdens/Create
        public ActionResult Create()
        {
            ViewBag.Id_Orden = new SelectList(db.Ordens, "ID", "ID");
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color");
            return View();
        }

        // POST: DetalleOrdens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cantidad,TotalDetalle,Id_Orden,Id_Vehiculo")] DetalleOrden detalleOrden)
        {
            if (ModelState.IsValid)
            {
                db.DetalleOrdens.Add(detalleOrden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Orden = new SelectList(db.Ordens, "ID", "ID", detalleOrden.Id_Orden);
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color", detalleOrden.Id_Vehiculo);
            return View(detalleOrden);
        }

        // GET: DetalleOrdens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleOrden detalleOrden = db.DetalleOrdens.Find(id);
            if (detalleOrden == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Orden = new SelectList(db.Ordens, "ID", "ID", detalleOrden.Id_Orden);
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color", detalleOrden.Id_Vehiculo);
            return View(detalleOrden);
        }

        // POST: DetalleOrdens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cantidad,TotalDetalle,Id_Orden,Id_Vehiculo")] DetalleOrden detalleOrden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleOrden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Orden = new SelectList(db.Ordens, "ID", "ID", detalleOrden.Id_Orden);
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color", detalleOrden.Id_Vehiculo);
            return View(detalleOrden);
        }

        // GET: DetalleOrdens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleOrden detalleOrden = db.DetalleOrdens.Find(id);
            if (detalleOrden == null)
            {
                return HttpNotFound();
            }
            return View(detalleOrden);
        }

        // POST: DetalleOrdens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleOrden detalleOrden = db.DetalleOrdens.Find(id);
            db.DetalleOrdens.Remove(detalleOrden);
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
