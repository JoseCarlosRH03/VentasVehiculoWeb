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
    public class TraccionVehiculoesController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: TraccionVehiculoes
        public ActionResult Index()
        {
            return View(db.TraccionVehiculos.ToList());
        }

        // GET: TraccionVehiculoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraccionVehiculo traccionVehiculo = db.TraccionVehiculos.Find(id);
            if (traccionVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(traccionVehiculo);
        }

        // GET: TraccionVehiculoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TraccionVehiculoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Traccion")] TraccionVehiculo traccionVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.TraccionVehiculos.Add(traccionVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(traccionVehiculo);
        }

        // GET: TraccionVehiculoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraccionVehiculo traccionVehiculo = db.TraccionVehiculos.Find(id);
            if (traccionVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(traccionVehiculo);
        }

        // POST: TraccionVehiculoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Traccion")] TraccionVehiculo traccionVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traccionVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traccionVehiculo);
        }

        // GET: TraccionVehiculoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraccionVehiculo traccionVehiculo = db.TraccionVehiculos.Find(id);
            if (traccionVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(traccionVehiculo);
        }

        // POST: TraccionVehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraccionVehiculo traccionVehiculo = db.TraccionVehiculos.Find(id);
            db.TraccionVehiculos.Remove(traccionVehiculo);
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
