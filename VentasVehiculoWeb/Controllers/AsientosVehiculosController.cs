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
    public class AsientosVehiculosController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: AsientosVehiculos
        public ActionResult Index()
        {
            return View(db.AsientosVehiculos.ToList());
        }

        // GET: AsientosVehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientosVehiculo asientosVehiculo = db.AsientosVehiculos.Find(id);
            if (asientosVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(asientosVehiculo);
        }

        // GET: AsientosVehiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsientosVehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CantidadAsiento")] AsientosVehiculo asientosVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.AsientosVehiculos.Add(asientosVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asientosVehiculo);
        }

        // GET: AsientosVehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientosVehiculo asientosVehiculo = db.AsientosVehiculos.Find(id);
            if (asientosVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(asientosVehiculo);
        }

        // POST: AsientosVehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CantidadAsiento")] AsientosVehiculo asientosVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asientosVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asientosVehiculo);
        }

        // GET: AsientosVehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientosVehiculo asientosVehiculo = db.AsientosVehiculos.Find(id);
            if (asientosVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(asientosVehiculo);
        }

        // POST: AsientosVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsientosVehiculo asientosVehiculo = db.AsientosVehiculos.Find(id);
            db.AsientosVehiculos.Remove(asientosVehiculo);
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
