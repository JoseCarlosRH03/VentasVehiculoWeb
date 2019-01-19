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
    public class InvetarioVehiculosController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: InvetarioVehiculos
        public ActionResult Index()
        {
            var invetarioVehiculoes = db.InvetarioVehiculoes.Include(i => i.Vehiculo);
            return View(invetarioVehiculoes.ToList());
        }

        // GET: InvetarioVehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvetarioVehiculo invetarioVehiculo = db.InvetarioVehiculoes.Find(id);
            if (invetarioVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(invetarioVehiculo);
        }

        // GET: InvetarioVehiculos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color");
            return View();
        }

        // POST: InvetarioVehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cantidad,Id_Vehiculo")] InvetarioVehiculo invetarioVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.InvetarioVehiculoes.Add(invetarioVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color", invetarioVehiculo.Id_Vehiculo);
            return View(invetarioVehiculo);
        }

        // GET: InvetarioVehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvetarioVehiculo invetarioVehiculo = db.InvetarioVehiculoes.Find(id);
            if (invetarioVehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color", invetarioVehiculo.Id_Vehiculo);
            return View(invetarioVehiculo);
        }

        // POST: InvetarioVehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cantidad,Id_Vehiculo")] InvetarioVehiculo invetarioVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invetarioVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color", invetarioVehiculo.Id_Vehiculo);
            return View(invetarioVehiculo);
        }

        // GET: InvetarioVehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvetarioVehiculo invetarioVehiculo = db.InvetarioVehiculoes.Find(id);
            if (invetarioVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(invetarioVehiculo);
        }

        // POST: InvetarioVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvetarioVehiculo invetarioVehiculo = db.InvetarioVehiculoes.Find(id);
            db.InvetarioVehiculoes.Remove(invetarioVehiculo);
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
