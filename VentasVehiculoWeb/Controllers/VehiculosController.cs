using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using VentaVehiculoModelDB.Models;


namespace VentasVehiculoWeb.Controllers
{
    public class VehiculosController : Controller
    {
       
        private string controlador = "";
        private string funcion = "";
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: Vehiculos
        public ActionResult Index(int? id)
        {
            var vehiculos = db.Vehiculos.Include(v => v.AsientosVehiculo).Include(v => v.CombustibleVehiculo).Include(v => v.EstadoVehiculo).Include(v => v.Modelo).Include(v => v.Suplidore).Include(v => v.TipoVehiculo);
            return View(vehiculos.ToList());
        }

        // GET: Vehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Asiento = new SelectList(db.AsientosVehiculos, "ID", "ID");
            ViewBag.Id_Combustible = new SelectList(db.CombustibleVehiculos, "ID", "Tipo");
            ViewBag.Id_Estado = new SelectList(db.EstadoVehiculos, "ID", "Estado");
            ViewBag.Id_Modelo = new SelectList(db.Modelos, "ID", "Nombre");
            ViewBag.Id_Suplidor = new SelectList(db.Suplidores, "ID", "NombreEmpresa");
            ViewBag.Id_TipoVehiculo = new SelectList(db.TipoVehiculos, "ID", "Tipo");
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Precio,Kilometraje,Color,Año,Id_Combustible,Id_TipoVehiculo,Id_Asiento,Id_Estado,Id_Modelo,Id_Suplidor")] Vehiculo vehiculo)
        {
             var mensaje = 0;

            if (ModelState.IsValid)
            {
                try
                {
                    db.Vehiculos.Add(vehiculo);
                    db.SaveChanges();
                    mensaje = vehiculo.ID;
                }

                catch (DbEntityValidationException e)
                {
                    mensaje = 0;
                }

            }
            else
            {
                mensaje = 0;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string d = serializer.Serialize(mensaje);
            return Json(d);  
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Asiento = new SelectList(db.AsientosVehiculos, "ID", "ID", vehiculo.Id_Asiento);
            ViewBag.Id_Combustible = new SelectList(db.CombustibleVehiculos, "ID", "Tipo", vehiculo.Id_Combustible);
            ViewBag.Id_Estado = new SelectList(db.EstadoVehiculos, "ID", "Estado", vehiculo.Id_Estado);
            ViewBag.Id_Modelo = new SelectList(db.Modelos, "ID", "Nombre", vehiculo.Id_Modelo);
            ViewBag.Id_Suplidor = new SelectList(db.Suplidores, "ID", "NombreEmpresa", vehiculo.Id_Suplidor);
            ViewBag.Id_TipoVehiculo = new SelectList(db.TipoVehiculos, "ID", "Tipo", vehiculo.Id_TipoVehiculo);
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Precio,Kilometraje,Color,Año,Id_Combustible,Id_TipoVehiculo,Id_Asiento,Id_Estado,Id_Modelo,Id_Suplidor")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Asiento = new SelectList(db.AsientosVehiculos, "ID", "ID", vehiculo.Id_Asiento);
            ViewBag.Id_Combustible = new SelectList(db.CombustibleVehiculos, "ID", "Tipo", vehiculo.Id_Combustible);
            ViewBag.Id_Estado = new SelectList(db.EstadoVehiculos, "ID", "Estado", vehiculo.Id_Estado);
            ViewBag.Id_Modelo = new SelectList(db.Modelos, "ID", "Nombre", vehiculo.Id_Modelo);
            ViewBag.Id_Suplidor = new SelectList(db.Suplidores, "ID", "NombreEmpresa", vehiculo.Id_Suplidor);
            ViewBag.Id_TipoVehiculo = new SelectList(db.TipoVehiculos, "ID", "Tipo", vehiculo.Id_TipoVehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            db.Vehiculos.Remove(vehiculo);
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

        [HttpPost]
        public JsonResult ModeloMarca(int valor)
        {

            using (var db = new VentasVehiculoDBEntities())
            {

                var datos = from s in db.Modelos
                            where s.Id_Marca == valor
                            select new { Id = s.ID, Name = s.Nombre, Traccion = s.Id_Traccion };

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string d = serializer.Serialize(datos);
                return Json(d);
            }
        }

        [HttpPost]
        public JsonResult Marca()
        {
            using (var db = new VentasVehiculoDBEntities())
            {
                var datos = from s in db.Marcas select new { Id = s.ID, Name = s.Nombre };
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string d = serializer.Serialize(datos);
                return Json(d);
            }
        }


        [HttpPost]
        public JsonResult Traccion()
        {

            using (var db = new VentasVehiculoDBEntities())
            {

                var datos = from s in db.TraccionVehiculos
                            select new { Id = s.ID, Nombre = s.Traccion };

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string d = serializer.Serialize(datos);
                return Json(d);
            }
        }

    }
}
