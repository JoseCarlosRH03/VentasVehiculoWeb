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
    public class FacturasOrdenesController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: FacturasOrdenes
        public ActionResult Index()
        {
            var facturasOrdenes = db.FacturasOrdenes.Include(f => f.Empleado).Include(f => f.Orden);
            return View(facturasOrdenes.ToList());
        }

        // GET: FacturasOrdenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturasOrdene facturasOrdene = db.FacturasOrdenes.Find(id);
            if (facturasOrdene == null)
            {
                return HttpNotFound();
            }
            return View(facturasOrdene);
        }

        // GET: FacturasOrdenes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Empleado = new SelectList(db.Empleados, "ID", "Nombre");
            ViewBag.Id_Orden = new SelectList(db.Ordens, "ID", "ID");
            return View();
        }

        // POST: FacturasOrdenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Fecha,Id_Empleado,Id_Orden,TipoPago,Cambio")] FacturasOrdene facturasOrdene)
        {
            if (ModelState.IsValid)
            {
                db.FacturasOrdenes.Add(facturasOrdene);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Empleado = new SelectList(db.Empleados, "ID", "Nombre", facturasOrdene.Id_Empleado);
            ViewBag.Id_Orden = new SelectList(db.Ordens, "ID", "ID", facturasOrdene.Id_Orden);
            return View(facturasOrdene);
        }

        // GET: FacturasOrdenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturasOrdene facturasOrdene = db.FacturasOrdenes.Find(id);
            if (facturasOrdene == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Empleado = new SelectList(db.Empleados, "ID", "Nombre", facturasOrdene.Id_Empleado);
            ViewBag.Id_Orden = new SelectList(db.Ordens, "ID", "ID", facturasOrdene.Id_Orden);
            return View(facturasOrdene);
        }

        // POST: FacturasOrdenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Fecha,Id_Empleado,Id_Orden,TipoPago,Cambio")] FacturasOrdene facturasOrdene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturasOrdene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Empleado = new SelectList(db.Empleados, "ID", "Nombre", facturasOrdene.Id_Empleado);
            ViewBag.Id_Orden = new SelectList(db.Ordens, "ID", "ID", facturasOrdene.Id_Orden);
            return View(facturasOrdene);
        }

        // GET: FacturasOrdenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturasOrdene facturasOrdene = db.FacturasOrdenes.Find(id);
            if (facturasOrdene == null)
            {
                return HttpNotFound();
            }
            return View(facturasOrdene);
        }

        // POST: FacturasOrdenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacturasOrdene facturasOrdene = db.FacturasOrdenes.Find(id);
            db.FacturasOrdenes.Remove(facturasOrdene);
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
