//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentaVehiculoModelDB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvetarioVehiculo
    {
        public int ID { get; set; }
        public int Cantidad { get; set; }
        public int Id_Vehiculo { get; set; }
    
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
