//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelSolRepo.BBDD
{
    using System;
    using System.Collections.Generic;
    
    public partial class HabitacionesSencillas
    {
        public int HabitacionID { get; set; }
        public Nullable<int> CamaSencilla { get; set; }
    
        public virtual Habitaciones Habitaciones { get; set; }
    }
}
