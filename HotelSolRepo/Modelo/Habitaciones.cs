
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace HotelSolRepo.Modelo
{

using System;
    using System.Collections.Generic;
    
public partial class Habitaciones
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Habitaciones()
    {

        this.Reservas = new HashSet<Reservas>();

        this.ReservaHabitaciones = new HashSet<ReservaHabitaciones>();

    }


    public int HabitacionID { get; set; }

    public string Tipo { get; set; }

    public string Caracteristicas { get; set; }

    public Nullable<double> Tarifa { get; set; }

    public string EstadoActual { get; set; }

    public Nullable<System.DateTime> Ocupado_desde { get; set; }

    public Nullable<System.DateTime> Ocupado_hasta { get; set; }

    public string CodigoHabitacion { get; set; }



    public virtual HabitacionesDobles HabitacionesDobles { get; set; }

    public virtual HabitacionesSencillas HabitacionesSencillas { get; set; }

    public virtual HabitacionesSuite HabitacionesSuite { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Reservas> Reservas { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ReservaHabitaciones> ReservaHabitaciones { get; set; }

}

}
