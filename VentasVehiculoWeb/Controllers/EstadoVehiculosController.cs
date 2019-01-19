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
    public class EstadoVehiculosController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: EstadoVehiculos
        public ActionResult Index()
        {
            return View(db.EstadoVehiculos.ToList());
        }

        // GET: EstadoVehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoVehiculo estadoVehiculo = db.EstadoVehiculos.Find(id);
            if (estadoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(estadoVehiculo);
        }

        // GET: EstadoVehiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoVehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Estado")] EstadoVehiculo estadoVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.EstadoVehiculos.Add(estadoVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoVehiculo);
        }

        // GET: EstadoVehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoVehiculo estadoVehiculo = db.EstadoVehiculos.Find(id);
            if (estadoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(estadoVehiculo);
        }

        // POST: EstadoVehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Estado")] EstadoVehiculo estadoVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoVehiculo);
        }

        // GET: EstadoVehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoVehiculo estadoVehiculo = db.EstadoVehiculos.Find(id);
            if (estadoVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(estadoVehiculo);
        }

        // POST: EstadoVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoVehiculo estadoVehiculo = db.EstadoVehiculos.Find(id);
            db.EstadoVehiculos.Remove(estadoVehiculo);
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
