
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
    
public partial class Facturas
{

    public int FacturaID { get; set; }

    public string NIF { get; set; }

    public Nullable<int> EmpleadoID { get; set; }

    public string Detalles { get; set; }

    public Nullable<double> Cargos { get; set; }

    public Nullable<double> Impuestos { get; set; }

    public Nullable<System.DateTime> Fecha { get; set; }

    public Nullable<System.DateTime> FechaCreacion { get; set; }

    public string TipoFactura { get; set; }



    public virtual Clientes Clientes { get; set; }

    public virtual Empleados Empleados { get; set; }

}

}
