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
    
    public partial class HabitacionesSuite
    {
        public int HabitacionID { get; set; }
        public Nullable<bool> SalaDeEstar { get; set; }
        public Nullable<bool> Minibar { get; set; }
    
        public virtual Habitaciones Habitaciones { get; set; }
    }
}
