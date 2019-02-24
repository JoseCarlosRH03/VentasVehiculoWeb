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
using VentasVehiculoWeb.models;
using System.Threading.Tasks;

namespace VentasVehiculoWeb.Controllers
{
    public class HomeController : Controller
    {
        SessionData session = new SessionData();

        private Modelos modelos;

        private List<Modelos> modelosList = new List<Modelos>();

        private VentasVehiculoDBEntities db = new VentasVehiculoDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListadoVehiculos()
        {
            var vehiculos = db.Vehiculos.Include(v => v.AsientosVehiculo).Include(v => v.CombustibleVehiculo).Include(v => v.EstadoVehiculo).Include(v => v.Modelo).Include(v => v.Suplidore).Include(v => v.TipoVehiculo);

            foreach (var item in vehiculos.ToList())
            {

                ImagenVehiculo imagenVeh = db.ImagenVehiculos.Find(item.ID);

                Marca marca = db.Marcas.Find(item.Modelo.Id_Marca);

                modelos = new Modelos
                {
                    Vehiculos = item,
                    Imagenes = imagenVeh,
                    Marca = marca,

                };

                modelosList.Add(modelos);
            }
            return View(modelosList);
        }



        //login

        public ActionResult IndexLogin()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Usuarios()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Usuarios(UserLogin datos)
        {


            if (ModelState.IsValid)
            {
                if (datos.Login() == true)
                {
                    session.SetSession(datos.UserId, datos.UserName);
                    ViewBag.User = session.GetSession("UserName");
                    return RedirectToAction("ListadoVehiculos");
                }
                else
                {
                    ViewBag.message = "Error";
                    return RedirectToAction("SinIn", "Home");

                }
            }
            else
            {
                return View("Usuarios");
            }
        }

        public ActionResult LoignOut()
        {
            session.DestroySession();
            return RedirectToAction("ListadoVehiculos");
        }

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

        [HttpPost]
        public ActionResult ComprarVehiculo(int? id)
        {
            var user = session.GetSession("UserName");
            var idUser = session.GetSession("Userid");

            if (user != null || user != "")
            {
               Cliente clienteObj = db.Clientes.Find(id);

                if(clienteObj != null)
                {
                    return View();
                }else
                {
                    return RedirectToAction("Create", "Clientes");
                }
            }
            else
            {
                return RedirectToAction("Usuarios");
            }


        }
    } 
}