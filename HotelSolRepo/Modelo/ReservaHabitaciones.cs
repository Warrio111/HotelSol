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
    
    public partial class ReservaHabitaciones
    {
        public int ReservaHabitacionID { get; set; }
        public Nullable<int> ReservaID { get; set; }
        public Nullable<int> HabitacionID { get; set; }
        public string TipoPension { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<double> Precio { get; set; }
    
        public virtual Habitaciones Habitaciones { get; set; }
        public virtual Reservas Reservas { get; set; }
    }
}
