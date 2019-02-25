using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculoModelDB.Models;

namespace VentasVehiculoWeb.models
{
    public class ModelFactura
    {
        public Vehiculo vehiculo { get; set; }
        public Cliente cliente { get; set; }

    }
}