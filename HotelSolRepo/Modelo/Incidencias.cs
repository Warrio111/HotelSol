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
    
    public partial class Incidencias
    {
        public int IncidenciaID { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaReporte { get; set; }
        public Nullable<int> HabitacionID { get; set; }
    
        public virtual Habitaciones Habitaciones { get; set; }
    }
}
