
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
    
public partial class Modelo
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Modelo()
    {

        this.Vehiculos = new HashSet<Vehiculo>();

    }


    public int ID { get; set; }

    public string Nombre { get; set; }

    public int Id_Marca { get; set; }

    public int Id_Traccion { get; set; }



    public virtual Marca Marca { get; set; }

    public virtual TraccionVehiculo TraccionVehiculo { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Vehiculo> Vehiculos { get; set; }

}

}
