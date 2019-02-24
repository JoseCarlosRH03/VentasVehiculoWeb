using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentasVehiculoWeb.models;
using VentaVehiculoModelDB.Models;

namespace VentasVehiculoWeb.Controllers
{
    public class UsuariosController : Controller
    {
        private string controlador;
        private string metodo;

        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NombreUsuario,PasswordUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Create", "Clientes");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NombreUsuario,PasswordUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
        [ValidateAntiForgeryToken]
        public ActionResult Validar([Bind(Include = "ID,NombreUsuario,PasswordUsuario")] Usuario usuario)
        {  
            if (ModelState.IsValid)
            {
                
                using (var db = new VentasVehiculoDBEntities())
                {

                    var datos = from s in db.Usuarios
                                where s.NombreUsuario == usuario.NombreUsuario && s.PasswordUsuario == usuario.PasswordUsuario
                                select s;

                    if (datos == null || datos.Count() == 0)
                    {
                        metodo = "Usuarios"; controlador = "Home";
                    }
                    else
                    {
                        foreach (var item in datos.ToList())
                        {
                            if (item.PasswordUsuario == usuario.PasswordUsuario && item.NombreUsuario == usuario.NombreUsuario)
                            {
                                SessionData sessionObj = new SessionData();
                                sessionObj.SetSession(item.ID, usuario.NombreUsuario);

                                metodo = "ListadoVehiculos"; controlador = "Home";  
                            }
                            else
                            {
                                metodo = "Usuarios"; controlador = "Home"; 
                            }
                        }
                    }
                }

            }
            else { metodo = "Usuarios"; controlador = "Home"; }

            return RedirectToAction(metodo,controlador );

        }

        //login
        SessionData session = new SessionData();
        // GET: User
        public ActionResult Users()
        {
            ViewBag.User = session.GetSession("UserName");
            if (ViewBag.User == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Close()
        {
            session.DestroySession();
            return RedirectToAction("Users", "User");
        }
    }

}
