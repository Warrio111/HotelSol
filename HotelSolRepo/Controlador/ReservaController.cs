using HotelSolRepo.Modelo;
using System;
using System.Xml.Linq;

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
        public void RegistrarCliente(Clientes nuevoCliente)
        {
            ClienteController clienteController = new ClienteController();
            clienteController.AgregarCliente(nuevoCliente);
        }

        // Método para hacer una nueva reserva
        public void HacerReserva(Reservas nuevaReserva)
        {
            // Implementar lógica para añadir una nueva reserva al archivo XML o la base de datos
        }

        // Otros métodos adicionales como cancelar reserva, etc.
    }
}

