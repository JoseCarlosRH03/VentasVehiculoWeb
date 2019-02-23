using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculoModelDB.Models;

namespace VentasVehiculoWeb.models
{
    public class Modelos
    {
        public Vehiculo Vehiculos { get; set; }
        public ImagenVehiculo Imagenes { get; set; }
        public Marca Marca { get; set; }
    }
}