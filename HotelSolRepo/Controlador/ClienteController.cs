using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using HotelSolRepo.Modelo;  

namespace HotelSolRepo.Controlador
{
    public class ClienteController
    {
        private string rutaArchivoXmlClientes = @"ruta\al\archivo\clientes.xml";

        // Método para registrar un nuevo cliente
        public void RegistrarCliente(Cliente nuevoCliente)
        {
            XDocument doc = XDocument.Load(rutaArchivoXmlClientes);
            // Implementar lógica para añadir un nuevo cliente al archivo XML
        }

        // Método para actualizar la información de un cliente existente
        public void ActualizarCliente(Cliente clienteActualizado)
        {
            // Implementar lógica para actualizar la información del cliente en el archivo XML
        }

        // Método para eliminar un cliente
        public void EliminarCliente(string clienteId)
        {
            // Implementar lógica para eliminar un cliente del archivo XML
        }

        // Método para obtener información de un cliente específico
        public Cliente ObtenerCliente(string clienteId)
        {
            // Implementar lógica para obtener la información de un cliente específico del archivo XML
            return new Cliente(); // Devuelve un objeto Cliente con la información recuperada
        }

        // Otros métodos adicionales según sea necesario
    }
}
