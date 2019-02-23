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
    
    public class ImagenVehiculoesController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: ImagenVehiculoes
        public ActionResult Index()
        {
            var imagenVehiculos = db.ImagenVehiculos.Include(i => i.Vehiculo);
            return View(imagenVehiculos.ToList());
        }

        // GET: ImagenVehiculoes/Details/5
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

        // GET: ImagenVehiculoes/Create
        
        public ActionResult CreateImagenes()
        {
            
            ViewBag.Id_Vehiculo = new SelectList(db.Vehiculos, "ID", "ID");
            return View();
        }

        // POST: ImagenVehiculoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file /*string Id_Vehiculo [Bind(Include = "ID,RutaImagen,Id_Vehiculo")] ImagenVehiculo imagenVehiculo*/)
        {
            try
            {

                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Imagenes/" + ImageName);
                file.SaveAs(physicalPath);

                ImagenVehiculo objImangenVehiculo = new ImagenVehiculo
                {
                    Id_Vehiculo = int.Parse(Request.Form["Id_Vehiculo"]),
                    RutaImagen = ImageName
                };

                if (ModelState.IsValid)
                {
                    db.ImagenVehiculos.Add(objImangenVehiculo);
                    db.SaveChanges();
                    return RedirectToAction("../Create/Vehiculos");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("../Create/Vehiculos");
            }

            return RedirectToAction("../Create/Vehiculos");

        }

        // GET: ImagenVehiculoes/Edit/5
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

        // POST: ImagenVehiculoes/Edit/5
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

        // GET: ImagenVehiculoes/Delete/5
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

        // POST: ImagenVehiculoes/Delete/5
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
