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
    public class OrdensController : Controller
    {
        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: Ordens
        public ActionResult Index()
        {
            var ordens = db.Ordens.Include(o => o.Cliente).Include(o => o.EstadoOrden);
            return View(ordens.ToList());
        }

        // GET: Ordens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Ordens.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // GET: Ordens/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(db.Clientes, "ID", "Nombre");
            ViewBag.Id_EstadoOrden = new SelectList(db.EstadoOrdens, "ID", "Nombre");
            return View();
        }

        // POST: Ordens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Id_Cliente,Id_Empleado,Id_TipoOrden,Id_EstadoOrden,Fecha,SubTotal,Itbis,Total")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Ordens.Add(orden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.Clientes, "ID", "Nombre", orden.Id_Cliente);
            ViewBag.Id_EstadoOrden = new SelectList(db.EstadoOrdens, "ID", "Nombre", orden.Id_EstadoOrden);
            return View(orden);
        }

        // GET: Ordens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Ordens.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.Clientes, "ID", "Nombre", orden.Id_Cliente);
            ViewBag.Id_EstadoOrden = new SelectList(db.EstadoOrdens, "ID", "Nombre", orden.Id_EstadoOrden);
            return View(orden);
        }

        // POST: Ordens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Id_Cliente,Id_Empleado,Id_TipoOrden,Id_EstadoOrden,Fecha,SubTotal,Itbis,Total")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.Clientes, "ID", "Nombre", orden.Id_Cliente);
            ViewBag.Id_EstadoOrden = new SelectList(db.EstadoOrdens, "ID", "Nombre", orden.Id_EstadoOrden);
            return View(orden);
        }

        // GET: Ordens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Ordens.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orden orden = db.Ordens.Find(id);
            db.Ordens.Remove(orden);
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
