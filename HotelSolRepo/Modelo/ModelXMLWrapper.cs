using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace HotelSolRepo.Modelo
{
    [XmlRoot("FacturasList")]
    public class FacturasListXmlWrapper
    {
        [XmlElement("Facturas")]
        public List<FacturasXmlWrapper> Facturas { get; set; }
    }
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
        public Nullable<double> Cargos { get; set; }

        [XmlElement("Impuestos")]
        public Nullable<double> Impuestos { get; set; }

        [XmlElement("Fecha", DataType = "dateTime")]
        public Nullable<DateTime> Fecha { get; set; }

        [XmlElement("FechaCreacion", DataType = "dateTime")]
        public Nullable<DateTime> FechaCreacion { get; set; }

        [XmlElement("TipoFactura")]
        public string TipoFactura { get; set; }
        [XmlArray("Clientes")]
        [XmlArrayItem("Cliente")]
        public List<ClientesXmlWrapper> Clientes { get; set; }
        [XmlArray("Empleados")]
        [XmlArrayItem("Empleado")]
        public List<EmpleadosXmlWrapper> Empleados { get; set; }
    }

    [XmlRoot("ClientesList")]
    public class ClientesListXmlWrapper
    {
        [XmlElement("Clientes")]
        public List<ClientesXmlWrapper> Clientes { get; set; }
    }
    [Serializable]
    public class ClientesXmlWrapper
    {
        [XmlElement("NIF")]
        public string NIF { get; set; }

        [XmlElement("Nombre")]
        public string Nombre { get; set; }

        [XmlElement("CorreoElectronico")]
        public string CorreoElectronico { get; set; }

        [XmlElement("Telefono")]
        public string Telefono { get; set; }
        [XmlElement("Contraseña")]
        public string Contraseña { get; set; }

        [XmlElement("ProgramaFidelizacionID")]
        public Nullable<int> ProgramaFidelizacionID { get; set; }
        [XmlArray("ProgramasFidelizacion")]
        [XmlArrayItem("ProgramaFidelizacion")]
        public List<ProgramasFidelizacionXmlWrapper> ProgramasFidelizacion { get; set; }
        [XmlArray("Reservas")]
        [XmlArrayItem("Reserva")]
        public List<ReservasXmlWrapper> Reservas { get; set; }
        [XmlArray("Facturas")]
        [XmlArrayItem("Factura")]
        public List<FacturasXmlWrapper> Facturas { get; set; }
    }

    [XmlRoot("EmpleadosList")]
    public class EmpleadosListXmlWrapper
    {
        [XmlElement("Empleados")]
        public List<EmpleadosXmlWrapper> Empleados { get; set; }
    }
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
        [XmlArray("Reservas")]
        [XmlArrayItem("Reserva")]
        public List<ReservasXmlWrapper> Reservas { get; set; }
        [XmlArray("Facturas")]
        [XmlArrayItem("Factura")]
        public List<FacturasXmlWrapper> Facturas { get; set; }
        [XmlArray("TareasEmpleados")]
        [XmlArrayItem("TareasEmpleados")]
        public List<TareasEmpleadosXmlWrapper> TareasEmpleados { get; set; }
    }

    [XmlRoot("ProgramasFidelizacionList")]
    public class ProgramasFidelizacionListXmlWrapper
    {
        [XmlElement("ProgramasFidelizacion")]
        public List<ProgramasFidelizacionXmlWrapper> ProgramasFidelizacion { get; set; }
    }
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
        [XmlArray("Clientes")]
        [XmlArrayItem("Cliente")]
        public List<ClientesXmlWrapper> Clientes { get; set; }
    }

    [XmlRoot("ReservasList")]
    public class ReservasListXmlWrapper
    {
        [XmlElement("Reservas")]
        public List<ReservasXmlWrapper> Reservas { get; set; }
    }

    [Serializable]
    public class ReservasXmlWrapper
    {
        [XmlElement("ReservaID")]
        public int ReservaID { get; set; }

        [XmlElement("TipoReserva")]
        public string TipoReserva { get; set; }  // Nuevo campo

        [XmlElement("NIF")]
        public string NIF { get; set; }

        [XmlElement("HabitacionID")]
        public Nullable<int> HabitacionID { get; set; }

        [XmlElement("EmpleadoID")]
        public Nullable<int> EmpleadoID { get; set; }

        [XmlElement("FechaInicio", DataType = "dateTime")]
        public Nullable<DateTime> FechaInicio { get; set; }

        [XmlElement("FechaFin", DataType = "dateTime")]
        public Nullable<DateTime> FechaFin { get; set; }

        [XmlElement("OpcionesPension")]
        public string OpcionesPension { get; set; }

        [XmlElement("EstadoReserva")]
        public string EstadoReserva { get; set; }

        [XmlElement("FechaCreacion", DataType = "dateTime")]
        public Nullable<DateTime> FechaCreacion { get; set; }

        [XmlElement("CheckInConfirmado", DataType = "dateTime")]
        public Nullable<DateTime> CheckInConfirmado { get; set; }

        [XmlElement("CheckOutConfirmado", DataType = "dateTime")]
        public Nullable<DateTime> CheckOutConfirmado { get; set; }

        [XmlArray("Habitaciones")]
        [XmlArrayItem("Habitacion")]
        public List<HabitacionesXmlWrapper> Habitaciones { get; set; }
        [XmlArray("Clientes")]
        [XmlArrayItem("Cliente")]
        public List<ClientesXmlWrapper> Clientes { get; set; }
        [XmlArray("Empleados")]
        [XmlArrayItem("Empleado")]
        public List<EmpleadosXmlWrapper> Empleados { get; set; }
    }

    [XmlRoot("HabitacionesList")]
    public class HabitacionesListXmlWrapper
    {
        [XmlElement("Habitaciones")]
        public List<HabitacionesXmlWrapper> Habitaciones { get; set; }

    }

    [Serializable]
    public class HabitacionesXmlWrapper
    {
        [XmlElement("HabitacionID")]
        public int HabitacionID { get; set; }

        [XmlElement("Tipo")]
        public string Tipo { get; set; }  // Modificado para incluir "Sencilla", "Doble", "Suite"

        [XmlElement("Caracteristicas")]
        public string Caracteristicas { get; set; }

        [XmlElement("Tarifa")]
        public Nullable<double> Tarifa { get; set; }

        [XmlElement("EstadoActual")]
        public string EstadoActual { get; set; }

        [XmlElement("Ocupado_desde", DataType = "dateTime")]
        public Nullable<DateTime> Ocupado_desde { get; set; }
        [XmlElement("Ocupado_hasta", DataType = "dateTime")]
        public Nullable<DateTime> Ocupado_hasta { get; set; }
        [XmlElement("CodigoHabitacion")]
        public string CodigoHabitacion { get; set; }

        [XmlElement("NumeroHabitaciones")]
        public Nullable<int> NumeroHabitaciones { get; set; }

        [XmlArray("Reservas")]
        [XmlArrayItem("Reserva")]
        public List<ReservasXmlWrapper> Reservas { get; set; }
        [XmlArray("HabitacionesSencillas")]
        [XmlArrayItem("HabitacionSencilla")]
        public List<HabitacionesSencillasXmlWrapper> HabitacionesSencillas { get; set; }
        [XmlArray("HabitacionesDobles")]
        [XmlArrayItem("HabitacionDoble")]
        public List<HabitacionesDoblesXmlWrapper> HabitacionesDobles { get; set; }

        [XmlArray("HabitacionesSuite")]
        [XmlArrayItem("HabitacionSuite")]
        public List<HabitacionesSuiteXmlWrapper> HabitacionesSuite { get; set; }
    }

    [Serializable]
    [XmlRoot("HabitacionesDobles")]
    public class HabitacionesDoblesXmlWrapper
    {
        [XmlElement("HabitacionID")]
        public int HabitacionID { get; set; }

        [XmlElement("CamasDobles")]
        public Nullable<int> CamasDobles { get; set; }
        [XmlArray("Habitaciones")]
        [XmlArrayItem("Habitacion")]
        public List<HabitacionesXmlWrapper> Habitaciones { get; set; }
    }

    [Serializable]
    [XmlRoot("HabitacionesSencillas")]
    public class HabitacionesSencillasXmlWrapper
    {
        [XmlElement("HabitacionID")]
        public int HabitacionID { get; set; }

        [XmlElement("CamaSencilla")]
        public Nullable<int> CamaSencilla { get; set; }
        [XmlArray("Habitaciones")]
        [XmlArrayItem("Habitacion")]
        public List<HabitacionesXmlWrapper> Habitaciones { get; set; }
    }

    [Serializable]
    [XmlRoot("HabitacionesSuite")]
    public class HabitacionesSuiteXmlWrapper
    {
        [XmlElement("HabitacionID")]
        public int HabitacionID { get; set; }

        [XmlElement("SalaDeEstar")]
        public Nullable<bool> SalaDeEstar { get; set; }

        [XmlElement("Minibar")]
        public Nullable<bool> Minibar { get; set; }
        [XmlArray("Habitaciones")]
        [XmlArrayItem("Habitacion")]
        public List<HabitacionesXmlWrapper> Habitaciones { get; set; }
    }

    [XmlRoot("TareasEmpleadosList")]
    public class TareasEmpleadosListXmlWrapper
    {
        [XmlElement("TareasEmpleados")]
        public List<TareasEmpleadosXmlWrapper> TareasEmpleados { get; set; }
    }

    [Serializable]
    public class TareasEmpleadosXmlWrapper
    {
        [XmlElement("TareaID")]
        public int TareaID { get; set; }

        [XmlElement("EmpleadoID")]
        public int EmpleadoID { get; set; }

        [XmlElement("Descripcion")]
        public string Descripcion { get; set; }

        [XmlElement("Fecha", DataType = "dateTime")]
        public Nullable<DateTime> Fecha { get; set; }
        [XmlArray("Empleados")]
        [XmlArrayItem("Empleado")]
        public List<EmpleadosXmlWrapper> Empleados { get; set; }
    }
}