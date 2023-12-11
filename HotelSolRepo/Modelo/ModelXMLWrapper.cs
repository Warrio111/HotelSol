using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace HotelSolRepo.Modelo
{

    // Representa la entidad Direcciones en formato XML.
    [Serializable]
    public class DireccionesXmlWrapper
    {
        [XmlElement("DireccionID")]
        public int DireccionID { get; set; }

        [XmlElement("Calle")]
        public string Calle { get; set; }

        [XmlElement("Numero")]
        public string Numero { get; set; }

        [XmlElement("Puerta")]
        public string Puerta { get; set; }

        [XmlElement("Piso")]
        public string Piso { get; set; }

        [XmlElement("CodigoPostal")]
        public string CodigoPostal { get; set; }

        [XmlElement("Provincia")]
        public string Provincia { get; set; }

        [XmlElement("Pais")]
        public string Pais { get; set; }
    }

    // Representa la entidad Clientes en formato XML.
    [Serializable]
    public class ClientesXmlWrapper
    {
        [XmlElement("NIF")]
        public string NIF { get; set; }

        [XmlElement("Nombre")]
        public string Nombre { get; set; }
        [XmlElement("PrimerApellido")]
        public string PrimerApellido { get; set; }
        [XmlElement("SegundoApellido")]
        public string SegundoApellido { get; set; }

        [XmlElement("DireccionID")]
        public int DireccionID { get; set; }

        [XmlElement("CorreoElectronico")]
        public string CorreoElectronico { get; set; }

        [XmlElement("Telefono")]
        public string Telefono { get; set; }

        [XmlElement("ProgramaFidelizacionID")]
        public Nullable<int> ProgramaFidelizacionID { get; set; }

        [XmlElement("Contraseña")]
        public string Contraseña { get; set; }

        [XmlArray("ProgramasFidelizacion")]
        [XmlArrayItem("ProgramaFidelizacion")]
        public List<ProgramasFidelizacionXmlWrapper> ProgramasFidelizacion { get; set; }
        [XmlArray("Reservas")]
        [XmlArrayItem("Reserva")]
        public List<ReservasXmlWrapper> Reservas { get; set; }
        [XmlArray("Facturas")]
        [XmlArrayItem("Factura")]
        public List<FacturasXmlWrapper> Facturas { get; set; }

        [XmlArray("Direcciones")]
        [XmlArrayItem("Direccion")]
        public List<DireccionesXmlWrapper> Direcciones { get; set; }
    }

    // Representa la entidad Empleados en formato XML.
    [Serializable]
    public class EmpleadosXmlWrapper
    {
        [XmlElement("EmpleadoID")]
        public int EmpleadoID { get; set; }

        [XmlElement("Nombre")]
        public string Nombre { get; set; }

        [XmlElement("Rol")]
        public string Rol { get; set; }

        [XmlElement("Horario")]
        public string Horario { get; set; }
    }

    // Representa la entidad Habitaciones en formato XML.
    [Serializable]
    public class HabitacionesXmlWrapper
    {
        [XmlElement("HabitacionID")]
        public int HabitacionID { get; set; }

        [XmlElement("Tipo")]
        public string Tipo { get; set; }

        [XmlElement("Caracteristicas")]
        public string Caracteristicas { get; set; }

        [XmlElement("Tarifa")]
        public Nullable<float> Tarifa { get; set; }

        [XmlElement("EstadoActual")]
        public string EstadoActual { get; set; }

        [XmlElement("Ocupado_desde", DataType = "dateTime")]
        public Nullable<DateTime> Ocupado_desde { get; set; }

        [XmlElement("Ocupado_hasta", DataType = "dateTime")]
        public Nullable<DateTime> Ocupado_hasta { get; set; }

        [XmlElement("CodigoHabitacion")]
        public string CodigoHabitacion { get; set; }
    }

    [Serializable]
    public class HabitacionesDoblesXmlWrapper
    {
        [XmlElement("HabitacionID")]
        public int HabitacionID { get; set; }

        [XmlElement("CamasDobles")]
        public int CamasDobles { get; set; }
    }

    [Serializable]
    public class HabitacionesSencillasXmlWrapper
    {
        [XmlElement("HabitacionID")]
        public int HabitacionID { get; set; }

        [XmlElement("CamaSencilla")]
        public int CamaSencilla { get; set; }
    }

    [Serializable]
    public class HabitacionesSuiteXmlWrapper
    {
        [XmlElement("HabitacionID")]
        public int HabitacionID { get; set; }

        [XmlElement("SalaDeEstar")]
        public bool SalaDeEstar { get; set; }

        [XmlElement("Minibar")]
        public bool Minibar { get; set; }
    }


    // Representa la entidad Facturas en formato XML.
    [Serializable]
    public class FacturasXmlWrapper
    {
        [XmlElement("FacturaID")]
        public int FacturaID { get; set; }

        [XmlElement("NIF")]
        public string NIF { get; set; }

        [XmlElement("EmpleadoID")]
        public Nullable<int> EmpleadoID { get; set; }

        [XmlElement("Detalles")]
        public string Detalles { get; set; }

        [XmlElement("Cargos")]
        public Nullable<float> Cargos { get; set; }

        [XmlElement("Impuestos")]
        public Nullable<float> Impuestos { get; set; }

        [XmlElement("Fecha", DataType = "date")]
        public Nullable<DateTime> Fecha { get; set; }

        [XmlElement("FechaCreacion", DataType = "dateTime")]
        public Nullable<DateTime> FechaCreacion { get; set; }

        [XmlElement("TipoFactura")]
        public string TipoFactura { get; set; }
        [XmlArray("Reservas")]
        [XmlArrayItem("Reserva")]
        public List<ReservasXmlWrapper> Reservas { get; set; }
        [XmlArray("Clientes")]
        [XmlArrayItem("Cliente")]
        public List<ClientesXmlWrapper> Clientes { get; set; }
        [XmlArray("Habitaciones")]
        [XmlArrayItem("Habitacion")]
        public List<HabitacionesXmlWrapper> Habitaciones { get; set; }
    }

    // Representa la entidad Reservas en formato XML.
    [Serializable]
    public class ReservasXmlWrapper
    {
        [XmlElement("ReservaID")]
        public int ReservaID { get; set; }

        [XmlElement("NIF")]
        public string NIF { get; set; }

        [XmlElement("EmpleadoID")]
        public Nullable<int> EmpleadoID { get; set; }

        [XmlElement("FechaInicio", DataType = "date")]
        public Nullable<DateTime> FechaInicio { get; set; }

        [XmlElement("FechaFin", DataType = "date")]
        public Nullable<DateTime> FechaFin { get; set; }

        [XmlElement("EstadoReserva")]
        public string EstadoReserva { get; set; }

        [XmlElement("CheckInConfirmado", DataType = "dateTime")]
        public Nullable<DateTime> CheckInConfirmado { get; set; }

        [XmlElement("CheckOutConfirmado", DataType = "dateTime")]
        public Nullable<DateTime> CheckOutConfirmado { get; set; }

        [XmlElement("FacturaID")]
        public Nullable<int> FacturaID { get; set; }

        [XmlElement("FechaCreacion", DataType = "dateTime")]
        public Nullable<DateTime> FechaCreacion { get; set; }

        [XmlElement("TipoReserva")]
        public string TipoReserva { get; set; }
    }

    // Representa la entidad ProgramasFidelizacion en formato XML.
    [Serializable]
    public class ProgramasFidelizacionXmlWrapper
    {
        [XmlElement("ProgramaFidelizacionID")]
        public int ProgramaFidelizacionID { get; set; }

        [XmlElement("Nombre")]
        public string Nombre { get; set; }

        [XmlElement("Puntos")]
        public Nullable<int> Puntos { get; set; }

        [XmlElement("Beneficios")]
        public string Beneficios { get; set; }
    }

    // Representa la entidad TareasEmpleados en formato XML.
    [Serializable]
    public class TareasEmpleadosXmlWrapper
    {
        [XmlElement("TareaID")]
        public int TareaID { get; set; }

        [XmlElement("EmpleadoID")]
        public int EmpleadoID { get; set; }

        [XmlElement("Descripcion")]
        public string Descripcion { get; set; }

        [XmlElement("Fecha", DataType = "date")]
        public Nullable<DateTime> Fecha { get; set; }
    }

    // Representa la entidad ReservaHabitaciones en formato XML.
    [Serializable]
    public class ReservaHabitacionesXmlWrapper
    {
        [XmlElement("ReservaHabitacionID")] 
        public int ReservaHabitacionID { get; set; }

        [XmlElement("ReservaID")]
        public Nullable<int> ReservaID { get; set; }

        [XmlElement("HabitacionID")]
        public Nullable<int> HabitacionID { get; set; }

        [XmlElement("TipoPension")]
        public string TipoPension { get; set; }

        [XmlElement("FechaInicio", DataType = "date")]
        public Nullable<DateTime> FechaInicio { get; set; }

        [XmlElement("FechaFin", DataType = "date")]
        public Nullable<DateTime> FechaFin { get; set; }

        [XmlElement("Precio")]
        public Nullable<double> Precio { get; set; }
    }
    [XmlRoot("DireccionesList")]
    public class DireccionesListXmlWrapper
    {
        [XmlElement("Direcciones")]
        public List<DireccionesXmlWrapper> Direcciones { get; set; }
    }

    public class ClientesListXmlWrapper         
    {
        [XmlElement("Clientes")]
        public List<ClientesXmlWrapper> Clientes { get; set; }
    }

    public class EmpleadosListXmlWrapper
    {
        [XmlElement("Empleado")]
        public List<EmpleadosXmlWrapper> Empleados { get; set; }
    }

    public class HabitacionesListXmlWrapper
    {
        [XmlElement("Habitacion")]
        public List<HabitacionesXmlWrapper> Habitaciones { get; set; }
    }

    public class HabitacionesDoblesListXmlWrapper
    {
        [XmlElement("HabitacionDoble")]
        public List<HabitacionesDoblesXmlWrapper> HabitacionesDobles { get; set; }
    }

    public class HabitacionesSencillasListXmlWrapper
    {
        [XmlElement("HabitacionSencilla")]
        public List<HabitacionesSencillasXmlWrapper> HabitacionesSencillas { get; set; }
    }

    public class HabitacionesSuiteListXmlWrapper
    {
        [XmlElement("HabitacionSuite")]
        public List<HabitacionesSuiteXmlWrapper> HabitacionesSuite { get; set; }
    }

    public class FacturasListXmlWrapper
    {
        [XmlElement("Factura")]
        public List<FacturasXmlWrapper> Facturas { get; set; }
    }

    public class ReservasListXmlWrapper
    {
        [XmlElement("Reserva")]
        public List<ReservasXmlWrapper> Reservas { get; set; }
    }

    public class ProgramasFidelizacionListXmlWrapper
    {
        [XmlElement("ProgramaFidelizacion")]
        public List<ProgramasFidelizacionXmlWrapper> ProgramasFidelizacion { get; set; }
    }

    public class TareasEmpleadosListXmlWrapper
    {
        [XmlElement("TareaEmpleado")]
        public List<TareasEmpleadosXmlWrapper> TareasEmpleados { get; set; }
    }

    public class ReservaHabitacionesListXmlWrapper
    {
        [XmlElement("ReservaHabitacion")]
        public List<ReservaHabitacionesXmlWrapper> ReservaHabitaciones { get; set; }
    }
    [Serializable]
    public class ReservaCompletaXmlWrapper
    {
        public ClientesXmlWrapper Cliente { get; set; }
        public DireccionesXmlWrapper Direccion { get; set; }
        public List<ReservaHabitacionesXmlWrapper> ReservaHabitaciones { get; set; }
        public ReservasXmlWrapper Reserva { get; set; }
        public FacturasXmlWrapper Factura { get; set; }
    }

    [Serializable]
    public class IncidenciasXmlWrapper
    {
        [XmlElement("IncidenciaID")]
        public int IncidenciaID { get; set; }

        [XmlElement("Descripcion")]
        public string Descripcion { get; set; }

        [XmlElement("FechaReporte", DataType = "dateTime")]
        public DateTime FechaReporte { get; set; }

        [XmlElement("HabitacionID")]
        public Nullable<int> HabitacionID { get; set; }
    }
    [XmlRoot("IncidenciasList")]
    public class IncidenciasListXmlWrapper
    {
        [XmlElement("Incidencia")]
        public List<IncidenciasXmlWrapper> Incidencias { get; set; }
    }
    [Serializable]
    public class ProductosXmlWrapper
    {
        [XmlElement("ProductoID")]
        public int ProductoID { get; set; }

        [XmlElement("Nombre")]
        public string Nombre { get; set; }

        [XmlElement("Precio")]
        public decimal Precio { get; set; }

        [XmlElement("Cantidad")]
        public int Cantidad { get; set; }

        [XmlElement("FacturaID")]
        public Nullable<int> FacturaID { get; set; }

    }

    [XmlRoot("ProductosList")]
    public class ProductosListXmlWrapper
    {
        [XmlElement("Producto")]
        public List<ProductosXmlWrapper> Productos { get; set; }
    }
    [Serializable]
    public class ProveedoresXmlWrapper
    {
        [XmlElement("NIF")]
        public string NIF { get; set; }

        [XmlElement("Empresa")]
        public string Empresa { get; set; }

        [XmlElement("Contacto")]
        public string Contacto { get; set; }

        [XmlElement("CorreoElectronico")]
        public string CorreoElectronico { get; set; }

        [XmlElement("TipoProveedor")]
        public string TipoProveedor { get; set; }

        [XmlElement("CondicionesDePago")]
        public string CondicionesDePago { get; set; }

        [XmlElement("DireccionID")]
        public Nullable<int> DireccionID { get; set; }

    }

    [XmlRoot("ProveedoresList")]
    public class ProveedoresListXmlWrapper
    {
        [XmlElement("Proveedor")]
        public List<ProveedoresXmlWrapper> Proveedores { get; set; }
    }
    [Serializable]
    public class ServiciosXmlWrapper
    {
        [XmlElement("ServicioID")]
        public int ServicioID { get; set; }

        [XmlElement("Nombre")]
        public string Nombre { get; set; }

        [XmlElement("Precio")]
        public decimal Precio { get; set; }

        [XmlElement("Cantidad")]
        public int Cantidad { get; set; }

        [XmlElement("FacturaID")]
        public Nullable<int> FacturaID { get; set; }
    }

    [XmlRoot("ServiciosList")]
    public class ServiciosListXmlWrapper
    {
        [XmlElement("Servicio")]
        public List<ServiciosXmlWrapper> Servicios { get; set; }
    }
}