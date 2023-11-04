using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace HotelSolRepo.Modelo
{
    [Serializable]
    [XmlRoot("Facturas")]
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
}
    [Serializable]
    [XmlRoot("Clientes")]
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
    }
    [Serializable]
    [XmlRoot("Empleados")]
    public class EmpleadosXmlWrapper
    {
        [XmlElement("EmpleadoID")]
        public int EmpleadoID { get; set; }

        [XmlElement("Nombre")]
        public string Nombre { get; set; }

        [XmlElement("Apellidos")]
        public string Apellidos { get; set; }

        [XmlElement("CorreoElectronico")]
        public string CorreoElectronico { get; set; }

        [XmlElement("Telefono")]
        public string Telefono { get; set; }

        [XmlElement("FechaNacimiento", DataType = "dateTime")]
        public Nullable<DateTime> FechaNacimiento { get; set; }

        [XmlElement("FechaContratacion", DataType = "dateTime")]
        public Nullable<DateTime> FechaContratacion { get; set; }

        [XmlElement("Puesto")]
        public string Puesto { get; set; }

        [XmlElement("Salario")]
        public Nullable<double> Salario { get; set; }

        [XmlElement("HorasSemanales")]
        public Nullable<int> HorasSemanales { get; set; }

        [XmlElement("Turno")]
        public string Turno { get; set; }
    }

 

    [Serializable]
    [XmlRoot("ProgramasFidelizacion")]
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

        [XmlElement("ClienteNombre")]  // Nuevo campo
        public string ClienteNombre { get; set; }

        [XmlElement("ClienteApellido")]  // Nuevo campo
        public string ClienteApellido { get; set; }

        [XmlArray("Habitaciones")]
        [XmlArrayItem("Habitacion")]
        public List<HabitacionesXmlWrapper> Habitaciones { get; set; }

        [XmlElement("EmpleadoID")]
        public Nullable<int> EmpleadoID { get; set; }

        [XmlElement("FechaInicio", DataType = "dateTime")]
        public Nullable<DateTime> FechaInicio { get; set; }

        [XmlElement("FechaFin", DataType = "dateTime")]
        public Nullable<DateTime> FechaFin { get; set; }

        [XmlElement("OpcionesPension")]
        public string OpcionesPension { get; set; }

        [XmlElement("Estado")]
        public string Estado { get; set; }

        [XmlElement("FechaCreacion", DataType = "dateTime")]
        public Nullable<DateTime> FechaCreacion { get; set; }
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
        [XmlElement("TipoPension")]
        public string TipoPension { get; set; }

        [XmlElement("NumeroHabitaciones")]
        public int NumeroHabitaciones { get; set; }
    }

    [Serializable]
    [XmlRoot("HabitacionesDobles")]
    public class HabitacionesDoblesXmlWrapper
    {
        [XmlElement("HabitacionID")]
        public int HabitacionID { get; set; }

        [XmlElement("CamasDobles")]
        public Nullable<int> CamasDobles { get; set; }
    }


    [Serializable]
    [XmlRoot("HabitacionesSencillas")]
    public class HabitacionesSencillasXmlWrapper
    {
        [XmlElement("HabitacionID")]
        public int HabitacionID { get; set; }

        [XmlElement("CamaSencilla")]
        public Nullable<int> CamaSencilla { get; set; }
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
    }


    [Serializable]
    [XmlRoot("TareasEmpleados")]
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

        [XmlElement("Estado")]
        public string Estado { get; set; }
    }
}