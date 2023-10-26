using System;
using System.Collections.Generic;
using System.Linq;
using HotelSolRepo.Modelo;

namespace HotelSolRepo.Controlador
{
    public class ClienteController
    {
        // Agrega un nuevo cliente al sistema
        public bool AgregarCliente(Clientes nuevoCliente)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                db.Clientes.Add(nuevoCliente);
                db.SaveChanges();
            }
            return true;
        }

        // Obtiene una lista de todos los clientes
        public List<Clientes> ObtenerClientes()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Clientes.ToList();
            }
        }

        // Obtiene un cliente específico por NIF
        public Clientes ObtenerClientePorNIF(string nif)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Clientes.FirstOrDefault(c => c.NIF == nif);
            }
        }

        // Actualiza la información de un cliente existente
        public bool ActualizarCliente(Clientes clienteActualizado)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var clienteExistente = db.Clientes.FirstOrDefault(c => c.NIF == clienteActualizado.NIF);
                if (clienteExistente != null)
                {
                    clienteExistente.Nombre = clienteActualizado.Nombre;
                    // Actualizar otros campos aquí
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        // Elimina un cliente del sistema
        public bool EliminarCliente(string nif)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var clienteExistente = db.Clientes.FirstOrDefault(c => c.NIF == nif);
                if (clienteExistente != null)
                {
                    db.Clientes.Remove(clienteExistente);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}

