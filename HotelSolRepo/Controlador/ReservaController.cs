using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using HotelSolRepo.Modelo;  

namespace HotelSolRepo.Controlador
{
    public class ReservaController
    {
        private string rutaArchivoXml = @"ruta\al\archivo\reservas.xml";

        // Método para comprobar disponibilidad de habitaciones
        public bool ComprobarDisponibilidad(DateTime fechaInicio, DateTime fechaFin)
        {
            XDocument doc = XDocument.Load(rutaArchivoXml);
            // Implementar lógica para comprobar disponibilidad
            return true;  // Devuelve true si hay disponibilidad, de lo contrario false
        }

        // Método para registrar un nuevo cliente
        public void RegistrarCliente(Cliente nuevoCliente)
        {
            // Implementar lógica para registrar un nuevo cliente en el archivo XML
        }

        // Método para hacer una nueva reserva
        public void HacerReserva(Reserva nuevaReserva)
        {
            // Implementar lógica para añadir una nueva reserva al archivo XML
        }

        // Otros métodos adicionales como cancelar reserva, etc.
    }
}
