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
    
    public partial class Direcciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direcciones()
        {
            this.Clientes = new HashSet<Clientes>();
            this.Proveedores = new HashSet<Proveedores>();
        }
    
        public int DireccionID { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Puerta { get; set; }
        public string Piso { get; set; }
        public string CodigoPostal { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clientes> Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
