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
    public class ImagenVehiculosController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: ImagenVehiculos
        public ActionResult Index()
        {
            var imagenVehiculos = db.ImagenVehiculos.Include(i => i.Vehiculo);
            return View(imagenVehiculos.ToList());
        }

        // GET: ImagenVehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagenVehiculo imagenVehiculo = db.ImagenVehiculos.Find(id);
            if (imagenVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(imagenVehiculo);
        }

        // GET: ImagenVehiculos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color");
            return View();
        }

        // POST: ImagenVehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RutaImagen,Id_Vehiculo")] ImagenVehiculo imagenVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.ImagenVehiculos.Add(imagenVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color", imagenVehiculo.Id_Vehiculo);
            return View(imagenVehiculo);
        }

        // GET: ImagenVehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagenVehiculo imagenVehiculo = db.ImagenVehiculos.Find(id);
            if (imagenVehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color", imagenVehiculo.Id_Vehiculo);
            return View(imagenVehiculo);
        }

        // POST: ImagenVehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RutaImagen,Id_Vehiculo")] ImagenVehiculo imagenVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagenVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "Color", imagenVehiculo.Id_Vehiculo);
            return View(imagenVehiculo);
        }

        // GET: ImagenVehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagenVehiculo imagenVehiculo = db.ImagenVehiculos.Find(id);
            if (imagenVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(imagenVehiculo);
        }

        // POST: ImagenVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagenVehiculo imagenVehiculo = db.ImagenVehiculos.Find(id);
            db.ImagenVehiculos.Remove(imagenVehiculo);
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
