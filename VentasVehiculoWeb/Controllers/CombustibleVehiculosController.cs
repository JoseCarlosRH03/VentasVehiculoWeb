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
    public class CombustibleVehiculosController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: CombustibleVehiculos
        public ActionResult Index()
        {
            return View(db.CombustibleVehiculos.ToList());
        }

        // GET: CombustibleVehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CombustibleVehiculo combustibleVehiculo = db.CombustibleVehiculos.Find(id);
            if (combustibleVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(combustibleVehiculo);
        }

        // GET: CombustibleVehiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CombustibleVehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tipo")] CombustibleVehiculo combustibleVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.CombustibleVehiculos.Add(combustibleVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(combustibleVehiculo);
        }

        // GET: CombustibleVehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CombustibleVehiculo combustibleVehiculo = db.CombustibleVehiculos.Find(id);
            if (combustibleVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(combustibleVehiculo);
        }

        // POST: CombustibleVehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tipo")] CombustibleVehiculo combustibleVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(combustibleVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(combustibleVehiculo);
        }

        // GET: CombustibleVehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CombustibleVehiculo combustibleVehiculo = db.CombustibleVehiculos.Find(id);
            if (combustibleVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(combustibleVehiculo);
        }

        // POST: CombustibleVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CombustibleVehiculo combustibleVehiculo = db.CombustibleVehiculos.Find(id);
            db.CombustibleVehiculos.Remove(combustibleVehiculo);
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
